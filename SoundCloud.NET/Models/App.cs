using Newtonsoft.Json;

namespace SoundCloud.NET.Models
{
    /// <summary>
    /// Represents a SoundCloud app
    /// </summary>
    public class App : BaseModel
    {
        #region Public Properties

        /// <summary>
        /// App creator
        /// </summary>
        [JsonProperty("creator")]
        public string Creator { get; set; }

        /// <summary>
        /// App website
        /// </summary>
        [JsonProperty("external_url")]
        public string ExternalUrl { get; set; }

        /// <summary>
        /// Numeric app ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// App name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// SoundCloud App URL
        /// </summary>
        [JsonProperty("permalink_url")]
        public string PermalinkUrl { get; set; }

        /// <summary>
        /// SoundCloud API Resource URL
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }

        #endregion Public Properties
    }
}
