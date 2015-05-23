using SoundCloud.NET.Authentication;
using SoundCloud.NET.Http;
using SoundCloud.NET.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            Trace.WriteLineIf(Trace.Listeners.Contains(Tracer.Instance), "Tracer hinzugefügt");

            // ClientId setzen
            this.ClientId = clientId;

            Trace.WriteLine("SoundCloudManager initialisiert mit ClientId " + clientId);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// SoundCloud API Client ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// OAuth Token Provider
        /// </summary>
        public ISoundCloudTokenProvider TokenProvider { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Holt Informationen über den angegebenen Benutzer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            Trace.WriteLine("Frage User '" + id + "' an");

            Request req = new Request(string.Format("/users/{0}", id), ParameterType.ClientID, this.ClientId);

            if (req.Execute())
            {
                return req.DeserializeResult<User>();
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
            Trace.WriteLine("Frage User über URL '" + url + "' an");

            Request req = new Request("/resolve", ParameterType.ClientID, this.ClientId);
            req.AddParam("url", url);

            if (req.Execute())
            {
                return req.DeserializeResult<User>();
            }
            else
            {
                return null;
            }
        }

        #endregion Public Methods

    }
}
