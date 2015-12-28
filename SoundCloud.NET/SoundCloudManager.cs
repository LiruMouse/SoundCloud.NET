using Newtonsoft.Json;
using RestSharp;
using SoundCloud.NET.Attributes;
using SoundCloud.NET.Models;
using System.Reflection;
using System.Text;

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
        /// <param name="userAgent">Your user agent, if you have a unique one</param>
        public SoundCloudManager(string clientId, string userAgent = "")
        {
            // Eigenschaften zuweisen
            ClientID = clientId;

            // RestClient einrichten
            RestClient = new RestClient("https://api.soundcloud.com")
            {
                UserAgent =  $"{userAgent} SoundCloud.NET (https://valentingerlach.de:4443/valentin/SoundCloud.NET)".TrimStart(),
                Timeout = 3000,
                FollowRedirects = true,
                Encoding = Encoding.UTF8
            };

            // Default Parameter setzen
            RestClient.AddDefaultParameter("client_id", ClientID, ParameterType.QueryString);
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
            return ResolveUrl<App>(soundcloudUrl);
        }

        /// <summary>
        /// Gets a SoundCloud app, identified by its numeric ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public App GetApp(int id)
        {
            // Request ausführen und App liefern
            return ResolveId<App>("apps", id);
        }

        /// <summary>
        /// Gets a SoundCloud playlist, identified by its permalink URL
        /// </summary>
        /// <param name="soundcloudUrl"></param>
        /// <returns></returns>
        public Playlist GetPlaylist(string soundcloudUrl)
        {
            // Request ausführen und Playlist liefern
            return ResolveUrl<Playlist>(soundcloudUrl);
        }

        /// <summary>
        /// Gets a SoundCloud playlist, identified by its numeric ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Playlist GetPlaylist(int id)
        {
            // Request ausführen und Playlist liefern
            return ResolveId<Playlist>("playlists", id);
        }

        /// <summary>
        /// Gets a SoundCloud Track, identified by its permalink URL
        /// </summary>
        /// <param name="soundcloudUrl"></param>
        /// <returns></returns>
        public Track GetTrack(string soundcloudUrl)
        {
            // Request ausführen und Track liefern
            return ResolveUrl<Track>(soundcloudUrl);
        }

        /// <summary>
        /// Gets a SoundCloud Track, identified by its numeric ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Track GetTrack(int id)
        {
            // Request ausführen und Track liefern
            return ResolveId<Track>("tracks", id);
        }

        /// <summary>
        /// Gets a SoundCloud user, identified by its permalink URL
        /// </summary>
        /// <param name="soundcloudUrl"></param>
        /// <returns></returns>
        public User GetUser(string soundcloudUrl)
        {
            // Request ausführen und User liefern
            return ResolveUrl<User>(soundcloudUrl);
        }

        /// <summary>
        /// Gets a SoundCloud user, identified by its numeric ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            // Request ausführen und User liefern
            return ResolveId<User>("users", id);
        }

        /// <summary>
        /// Search for an app by providing a set of parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public App[] SearchApp(SearchParameters parameters)
        {
            return Search<App>("apps", parameters);
        }

        /// <summary>
        /// Search for an app by providing a search string
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public App[] SearchApp(string searchString)
        {
            return SearchApp(new SearchParameters(searchString));
        }

        /// <summary>
        /// Search for a playlist by providing a set of parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Playlist[] SearchPlaylist(SearchParameters parameters)
        {
            return Search<Playlist>("playlists", parameters);
        }

        /// <summary>
        /// Search for a playlist by providing a search string
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public Playlist[] SearchPlaylist(string searchString)
        {
            return SearchPlaylist(new SearchParameters(searchString));
        }

        /// <summary>
        /// Search for a track by providing a set of parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Track[] SearchTrack(SearchParameters parameters)
        {
            return Search<Track>("tracks", parameters);
        }

        /// <summary>
        /// Search for a track by providing a search string
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public Track[] SearchTrack(string searchString)
        {
            return SearchTrack(new SearchParameters(searchString));
        }

        /// <summary>
        /// Search for an user by providing a set of parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public User[] SearchUser(SearchParameters parameters)
        {
            return Search<User>("users", parameters);
        }

        /// <summary>
        /// Search for an user by providing a search string
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public User[] SearchUser(string searchString)
        {
            return SearchUser(new SearchParameters(searchString));
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
            IRestResponse response = RestClient.Execute(request);

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
            IRestResponse response = RestClient.Execute(request);

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
            return Execute<T>(request);
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

            // Request ausführen und Model liefern
            return Execute<T>(request);
        }

        /// <summary>
        /// Sucht nach einer API Ressource
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subresource"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        internal T[] Search<T>(string subresource, SearchParameters param) where T : BaseModel
        {
            // Request anlegen
            RestRequest request = new RestRequest(subresource, Method.GET);

            // Parameter lesen
            foreach (PropertyInfo property in typeof(SearchParameters).GetProperties())
            {
                // Attribute lesen
                foreach (UrlParameterProperty attr in property.GetCustomAttributes(typeof(UrlParameterProperty)))
                {
                    // Wenn Property gesetzt, zu Parametern hinzufügen
                    if (property.GetValue(param) != null)
                    {
                        request.AddQueryParameter(attr.ParameterName, property.GetValue(param).ToString());
                    }
                }
            }

            // Request ausführen und Model liefern
            return ExecuteCollection<T>(request);
        }

        #endregion Internal Methods

    }
}
