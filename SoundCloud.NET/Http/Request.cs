using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.NET.Http
{
    /// <summary>
    /// Enthält den Typ des Authentifizierungsparameters, der im API Request verwendet wird
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// ClientID
        /// </summary>
        ClientID,

        /// <summary>
        /// OAuthToken
        /// </summary>
        OAuthToken
    }

    /// <summary>
    /// Stellt einen API Request dar.
    /// </summary>
    class Request
    {

        #region Public Constructors

        /// <summary>
        /// Initialisiert einen API Request
        /// </summary>
        /// <param name="resource"></param>
        public Request(string resource)
        {
            // WebClient einrichten
            this.WebClient = new WebClient();
            this.WebClient.QueryString = new NameValueCollection();
            this.WebClient.BaseAddress = "https://api.soundcloud.com";
            this.WebClient.Encoding = Encoding.UTF8;
            this.WebClient.Headers.Add(HttpRequestHeader.UserAgent, "SoundCloud.NET");
            this.WebClient.Proxy = null;
        }

        /// <summary>
        /// Initialisiert einen API Request wahlweise mit ClientId oder OAuth-Token
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="type"></param>
        /// <param name="parameter"></param>
        public Request(string resource, ParameterType type, string parameter) : this(resource)
        {
            switch (type)
            {
                case ParameterType.ClientID:
                    this.QueryString["client_id"] = parameter;
                    break;
                case ParameterType.OAuthToken:
                    this.QueryString["oauth_token"] = parameter;
                    break;
                default:
                    break;
            }
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Auflistung der GET-Parameter
        /// </summary>
        public NameValueCollection QueryString { get { return this.WebClient.QueryString; } set { this.WebClient.QueryString = value; } }

        /// <summary>
        /// API Ressource relativ zu https://api.soundcloud.com
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// Verwendeter WebClient
        /// </summary>
        public WebClient WebClient { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Fügt einen GET-Parameter hinzu
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Request AddParam(string key, string value)
        {
            this.QueryString[key] = value;

            return this;
        }

        /// <summary>
        /// Führt den Request aus und liefert die Antwort als String zurück
        /// </summary>
        /// <returns></returns>
        public string Execute()
        {
            return this.WebClient.DownloadString(this.Resource);
        }

        /// <summary>
        /// Führt den Request aus und deserialisiert die Antwort in den angegebenen Typ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ExecuteObject<T>()
        {
            return JsonConvert.DeserializeObject<T>(this.Execute(), new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        #endregion Public Methods

    }
}
