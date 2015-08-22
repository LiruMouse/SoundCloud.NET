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
    /// Provides an interface to the SoundCloud API
    /// </summary>
    public class SoundCloudManager
    {

        #region Public Constructors

        /// <summary>
        /// Creates a new instance of the SoundCloud Manager
        /// </summary>
        /// <param name="clientId">Your client ID</param>
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
        /// Client ID used by this manager
        /// </summary>
        public string ClientID { get; private set; }

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        /// RestClient used by this manager
        /// </summary>
        private RestClient RestClient { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        /// Gets a SoundCloud app, identified by its permalink URL
        /// </summary>
        /// <param name="soundcloudUrl"></param>
        /// <returns></returns>
        public App GetApp(string soundcloudUrl)
        {
            // Request anlegen
            RestRequest request = new RestRequest("resolve", Method.GET);

            // Parameter setzen
            request.AddParameter("url", soundcloudUrl.Trim());

            // Request ausführen und App liefern
            return this.Execute<App>(request);
        }

        /// <summary>
        /// Gets a SoundCloud app, identified by its numeric ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public App GetApp(int id)
        {
            // Request anlegen
            RestRequest request = new RestRequest("apps/{id}", Method.GET);

            // Parameter setzen
            request.AddUrlSegment("id", id.ToString());

            // Request ausführen und App liefern
            return this.Execute<App>(request);
        }

        /// <summary>
        /// Gets a SoundCloud playlist, identified by its permalink URL
        /// </summary>
        /// <param name="soundcloudUrl"></param>
        /// <returns></returns>
        public Playlist GetPlaylist(string soundcloudUrl)
        {
            // Request anlegen
            RestRequest request = new RestRequest("resolve", Method.GET);

            // Parameter setzen
            request.AddParameter("url", soundcloudUrl.Trim());

            // Request ausführen und Playlist liefern
            return this.Execute<Playlist>(request);
        }

        /// <summary>
        /// Gets a SoundCloud playlist, identified by its numeric ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Playlist GetPlaylist(int id)
        {
            // Request anlegen
            RestRequest request = new RestRequest("playlists/{id}", Method.GET);

            // Parameter setzen
            request.AddUrlSegment("id", id.ToString());

            // Request ausführen und Playlist liefern
            return this.Execute<Playlist>(request);
        }

        /// <summary>
        /// Gets a SoundCloud Track, identified by its permalink URL
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
        /// Gets a SoundCloud Track, identified by its numeric ID
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

        /// <summary>
        /// Gets a SoundCloud user, identified by its permalink URL
        /// </summary>
        /// <param name="soundcloudUrl"></param>
        /// <returns></returns>
        public User GetUser(string soundcloudUrl)
        {
            // Request anlegen
            RestRequest request = new RestRequest("resolve", Method.GET);

            // Parameter setzen
            request.AddParameter("url", soundcloudUrl.Trim());

            // Request ausführen und User liefern
            return this.Execute<User>(request);
        }

        /// <summary>
        /// Gets a SoundCloud user, identified by its numeric ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            // Request anlegen
            RestRequest request = new RestRequest("users/{id}", Method.GET);

            // Parameter setzen
            request.AddUrlSegment("id", id.ToString());

            // Request ausführen und User liefern
            return this.Execute<User>(request);
        }

        #endregion Public Methods

        #region Internal Methods

        /// <summary>
        /// Executes the request and serializes the result
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
        /// Executes the request and serializes the result as a collection
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

    }
}
