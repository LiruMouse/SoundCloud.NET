using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.NET.Authentication
{
    /// <summary>
    /// Stellt einen SoundCloud OAuth Token bereit
    /// </summary>
    public interface ISoundCloudTokenProvider
    {
        /// <summary>
        /// Gibt einen gültigen SoundCloud OAuth Token zurück
        /// </summary>
        /// <returns>SoundCloud OAuth Token</returns>
        string GetToken();
    }
}
