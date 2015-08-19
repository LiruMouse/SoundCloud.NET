using Newtonsoft.Json;
using RestSharp;
using SoundCloud.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.NET
{
    /// <summary>
    /// Stellt eine Schnittstelle zu SoundCloud bereit
    /// </summary>
    public class SoundCloudManager
    {

        #region Public Constructors

        /// <summary>
        /// Initialisiert einen neuen SoundCloud Manager
        /// </summary>
        /// <param name="clientId"></param>
        public SoundCloudManager(string clientId)
        {
            // Eigenschaften zuweisen
            this.ClientID = clientId;

            // RestClient einrichten
            this.RestClient = new RestClient("https://api.soundcloud.com")
            {
                UserAgent = "SoundCloud.NET (https://valentingerlach.de:4443/valentin/SoundCloud.NET)",
                Timeout = 3000,
                FollowRedirects = true,
                Encoding = Encoding.UTF8
            };

            // Default Parameter setzen
            this.RestClient.AddDefaultParameter("client_id", this.ClientID, ParameterType.QueryString);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Die verwendete Client ID
        /// </summary>
        public string ClientID { get; private set; }

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        /// Der verwendete RestClient
        /// </summary>
        private RestClient RestClient { get; set; }

        #endregion Private Properties

        #region Internal Methods

        /// <summary>
        /// Führt den Request aus und liefert ein einzelnes Objekt
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        internal T Execute<T>(RestRequest request) where T : BaseModel
        {
            // Request ausführen
            IRestResponse response = this.RestClient.Execute(request);

            // Auf Fehler prüfen
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            // Deserialisieren
            T model = JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });

            // Verweise setzen
            model.SoundCloudManager = this;

            // Model ausliefern
            return model;
        }

        /// <summary>
        /// Führt den Request aus und liefert eine Reihe von Objekten
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        internal T[] ExecuteCollection<T>(RestRequest request) where T : BaseModel
        {
            // Request ausführen
            IRestResponse response = this.RestClient.Execute(request);

            // Auf Fehler prüfen
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            // Deserialisieren
            T[] models = JsonConvert.DeserializeObject<T[]>(response.Content, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });

            // Verweise setzen
            foreach (BaseModel model in models)
            {
                model.SoundCloudManager = this;
            }

            // Model ausliefern
            return models;
        }

        #endregion Internal Methods

        /// <summary>
        /// Liefert einen SoundCloud Track, identifiziert durch seine SoundCloud URL
        /// </summary>
        /// <param name="soundcloudUrl"></param>
        /// <returns></returns>
        public Track GetTrack(string soundcloudUrl)
        {
            // Request anlegen
            RestRequest request = new RestRequest("resolve", Method.GET);

            // Parameter setzen
            request.AddParameter("url", soundcloudUrl.Trim());

            // Request ausführen und Track liefern
            return this.Execute<Track>(request);
        }

        /// <summary>
        /// Liefert einen SoundCloud Track, identifiziert durch seine numerische ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Track GetTrack(int id)
        {
            // Request anlegen
            RestRequest request = new RestRequest("tracks/{id}", Method.GET);

            // Parameter setzen
            request.AddUrlSegment("id", id.ToString());

            // Request ausführen und Track liefern
            return this.Execute<Track>(request);
        }

    }
}
