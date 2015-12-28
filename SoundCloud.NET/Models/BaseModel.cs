using Newtonsoft.Json;

namespace SoundCloud.NET.Models
{
    /// <summary>
    /// Represents a general SoundCloud API Answer
    /// </summary>
    public abstract class BaseModel
    {

        #region Public Properties

        /// <summary>
        /// Gets the type of the model
        /// </summary>
        [JsonProperty("kind")]
        public string Kind { get; set; }

        #endregion Public Properties

        #region Internal Properties

        /// <summary>
        /// Internal reference to the SoundCloud manager used to get this resource
        /// </summary>
        internal SoundCloudManager SoundCloudManager { get; set; }

        #endregion Internal Properties
    }
}
