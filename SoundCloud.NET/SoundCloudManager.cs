using SoundCloud.NET.Authentication;
using System;
using System.Collections.Generic;
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
            // ClientId setzen
            this.ClientId = clientId;
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

    }
}
