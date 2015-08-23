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
            // Request ausführen und App liefern
            return this.ResolveUrl<App>(soundcloudUrl);
        }

        /// <summary>
        /// Gets a SoundCloud app, identified by its numeric ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public App GetApp(int id)
        {
            // Request ausführen und App liefern
            return this.ResolveId<App>("apps", id);
        }

        /// <summary>
        /// Gets a SoundCloud playlist, identified by its permalink URL
        /// </summary>
        /// <param name="soundcloudUrl"></param>
        /// <returns></returns>
        public Playlist GetPlaylist(string soundcloudUrl)
        {
            // Request ausführen und Playlist liefern
            return this.ResolveUrl<Playlist>(soundcloudUrl);
        }

        /// <summary>
        /// Gets a SoundCloud playlist, identified by its numeric ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Playlist GetPlaylist(int id)
        {
            // Request ausführen und Playlist liefern
            return this.ResolveId<Playlist>("playlists", id);
        }

        /// <summary>
        /// Gets a SoundCloud Track, identified by its permalink URL
        /// </summary>
        /// <param name="soundcloudUrl"></param>
        /// <returns></returns>
        public Track GetTrack(string soundcloudUrl)
        {
            // Request ausführen und Track liefern
            return this.ResolveUrl<Track>(soundcloudUrl);
        }

        /// <summary>
        /// Gets a SoundCloud Track, identified by its numeric ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Track GetTrack(int id)
        {
            // Request ausführen und Track liefern
            return this.ResolveId<Track>("tracks", id);
        }

        /// <summary>
        /// Gets a SoundCloud user, identified by its permalink URL
        /// </summary>
        /// <param name="soundcloudUrl"></param>
        /// <returns></returns>
        public User GetUser(string soundcloudUrl)
        {
            // Request ausführen und User liefern
            return this.ResolveUrl<User>(soundcloudUrl);
        }

        /// <summary>
        /// Gets a SoundCloud user, identified by its numeric ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            // Request ausführen und User liefern
            return this.ResolveId<User>("users", id);
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

        /// <summary>
        /// Resolves a numeric ID to an API resource
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subresource"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        internal T ResolveId<T>(string subresource, int id) where T : BaseModel
        {
            // Request anlegen
            RestRequest request = new RestRequest("{subresource}/{id}", Method.GET);

            // Parameter setzen
            request.AddUrlSegment("id", id.ToString());
            request.AddUrlSegment("subresource", subresource);

            // Request ausführen und Model liefern
            return this.Execute<T>(request);
        }

        /// <summary>
        /// Resolves a SoundCloud URL to an API resource
        /// </summary>
        /// <param name="soundcloudUrl"></param>
        /// <returns></returns>
        internal T ResolveUrl<T>(string soundcloudUrl) where T : BaseModel
        {
            // Request anlegen
            RestRequest request = new RestRequest("resolve", Method.GET);

            // Parameter setzen
            request.AddParameter("url", soundcloudUrl.Trim());

            // Request ausführen und Playlist liefern
            return this.Execute<T>(request);
        }

        #endregion Internal Methods
    }
}
