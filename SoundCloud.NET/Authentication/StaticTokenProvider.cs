using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.NET.Authentication
{
    /// <summary>
    /// Stellt einen Token-Provider dar, der zum Debuggen verwendet werden kann
    /// </summary>
    public class StaticTokenProvider : ISoundCloudTokenProvider
    {
        #region Public Constructors

        /// <summary>
        /// Initialisiert einen Token-Speicher
        /// </summary>
        /// <param name="oath_token"></param>
        public StaticTokenProvider(string oath_token)
        {
            this.Token = oath_token;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gespeicherter Token
        /// </summary>
        public string Token { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gibt einen gültigen SoundCloud OAuth Token zurück
        /// </summary>
        /// <returns>SoundCloud OAuth Token</returns>
        public string GetToken()
        {
            return this.Token;
        }

        #endregion Public Methods

        /// <summary>
        /// Gibt an, ob ein Token zur Verfügung steht
        /// </summary>
        public bool TokenAvailable
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.Token);
            }
        }
    }
}
