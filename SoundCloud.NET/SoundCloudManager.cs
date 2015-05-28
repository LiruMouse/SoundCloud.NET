using Newtonsoft.Json.Linq;
using SoundCloud.NET.Authentication;
using SoundCloud.NET.Http;
using SoundCloud.NET.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.NET
{
    /// <summary>
    /// Stellt eine Schnittstelle zur SoundCloud API bereit
    /// </summary>
    public class SoundCloudManager
    {

        #region Public Constructors

        /// <summary>
        /// Initialisiert einen neuen SoundCloudManager
        /// </summary>
        /// <param name="clientId">SoundCloud API Client ID</param>
        public SoundCloudManager(string clientId)
        {
            // Logging
            Trace.WriteLineIf(Trace.Listeners.Contains(Tracer.Instance), "Tracer hinzugefügt");

            // ClientId setzen
            this.ClientId = clientId;

            // Logging
            Trace.WriteLine("SoundCloudManager initialisiert mit ClientId " + clientId);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// SoundCloud API Client ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gibt an, ob ein Token zur Verfügung steht
        /// </summary>
        public bool TokenAvailable
        {
            get
            {
                return (this.TokenProvider != null && this.TokenProvider.TokenAvailable);
            }
        }

        /// <summary>
        /// OAuth Token Provider
        /// </summary>
        public ISoundCloudTokenProvider TokenProvider { get; set; }

        #endregion Public Properties

        #region Public Methods

        public static void write(string url)
        {
            string json = new WebClient().DownloadString(url);

            json = JObject.Parse(json).ToString(Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText("json.json", json);
        }

        /// <summary>
        /// Holt Informationen über den angegebenen Track
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Track GetTrack(int id)
        {
            // Logging
            Trace.WriteLine("Frage Track '" + id + "' an");

            // API Request vorbereiten
            Request req = new Request(string.Format("/tracks/{0}", id), ParameterType.ClientID, this.ClientId);

            // API Request ausführen
            if (req.Execute())
            {
                // API Response deserialisieren
                Track track = req.DeserializeResult<Track>();
                track.SoundCloudManager = this;

                return track;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Holt Informationen über den angegebenen Track anhand der Track-URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Track GetTrack(string url)
        {
            // Logging
            Trace.WriteLine("Frage Track über URL '" + url + "' an");

            // API Request vorbereiten
            Request req = new Request("/resolve", ParameterType.ClientID, this.ClientId);
            req.AddParam("url", url);

            // API Request ausführen
            if (req.Execute())
            {
                // API Response deserialisieren
                Track track = req.DeserializeResult<Track>();
                track.SoundCloudManager = this;

                return track;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Holt Informationen über den angegebenen Benutzer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            // Logging
            Trace.WriteLine("Frage User '" + id + "' an");

            // API Request vorbereiten
            Request req = new Request(string.Format("/users/{0}", id), ParameterType.ClientID, this.ClientId);

            // API Request ausführen
            if (req.Execute())
            {
                // API Response deserialisieren
                User user = req.DeserializeResult<User>();
                user.SoundCloudManager = this;

                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Holt Informationen über den angegebenen Benutzer anhand der Benutzer-URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public User GetUser(string url)
        {
            // Logging
            Trace.WriteLine("Frage User über URL '" + url + "' an");

            // API Request vorbereiten
            Request req = new Request("/resolve", ParameterType.ClientID, this.ClientId);
            req.AddParam("url", url);

            // API Request ausführen
            if (req.Execute())
            {
                // API Response deserialisieren
                User user = req.DeserializeResult<User>();
                user.SoundCloudManager = this;

                return user;
            }
            else
            {
                return null;
            }
        }

        #endregion Public Methods

    }
}
