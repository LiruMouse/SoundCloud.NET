using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.NET.Models
{
    /// <summary>
    /// Represents a SoundCloud user
    /// </summary>
    public class User : BaseModel
    {
        #region Public Properties

        /// <summary>
        /// Avatar URL
        /// </summary>
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Discogs name
        /// </summary>
        [JsonProperty("discogs_name")]
        public string DiscogsName { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Number of followers
        /// </summary>
        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        /// <summary>
        /// Number of followings
        /// </summary>
        [JsonProperty("followings_count")]
        public int FollowingsCount { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// Numeric ID of the user
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Last modified
        /// </summary>
        [JsonProperty("last_modified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// MySpace name
        /// </summary>
        [JsonProperty("myspace_name")]
        public string MyspaceName { get; set; }

        /// <summary>
        /// Indicates if the user is online at the moment
        /// </summary>
        [JsonProperty("online")]
        public bool Online { get; set; }

        /// <summary>
        /// Permalink
        /// </summary>
        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        /// <summary>
        /// SoundCloud URL
        /// </summary>
        [JsonProperty("permalink_url")]
        public string PermalinkUrl { get; set; }

        /// <summary>
        /// Plan
        /// </summary>
        [JsonProperty("plan")]
        public string Plan { get; set; }

        /// <summary>
        /// Number of playlists the user has created
        /// </summary>
        [JsonProperty("playlist_count")]
        public int PlaylistCount { get; set; }

        /// <summary>
        /// Number of public favorites
        /// </summary>
        [JsonProperty("public_favorites_count")]
        public int PublicFavoritesCount { get; set; }

        /// <summary>
        /// Collection of subscriptions
        /// </summary>
        [JsonProperty("subscriptions")]
        public IList<object> Subscriptions { get; set; }

        /// <summary>
        /// Number of tracks that belong to the user
        /// </summary>
        [JsonProperty("track_count")]
        public int TrackCount { get; set; }

        /// <summary>
        /// SoundCloud API Resource URL
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Website
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }

        /// <summary>
        /// Website title
        /// </summary>
        [JsonProperty("website_title")]
        public string WebsiteTitle { get; set; }

        #endregion Public Properties
    }
}
