using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SoundCloud.NET.Models
{
    /// <summary>
    /// Represents a SoundCloud playlist (or "Set")
    /// </summary>
    public class Playlist : BaseModel
    {
        #region Public Properties

        /// <summary>
        /// Cover URL
        /// </summary>
        [JsonProperty("artwork_url")]
        public string ArtworkUrl { get; set; }

        /// <summary>
        /// Created at
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Indicates if the entire playlist is downloadable
        /// </summary>
        [JsonProperty("downloadable")]
        public bool Downloadable { get; set; }

        /// <summary>
        /// Gets the duration in seconds
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// EAN Code
        /// </summary>
        [JsonProperty("ean")]
        public string Ean { get; set; }

        /// <summary>
        /// Embeddable by
        /// </summary>
        [JsonProperty("embeddable_by")]
        public string EmbeddableBy { get; set; }

        /// <summary>
        /// Genre
        /// </summary>
        [JsonProperty("genre")]
        public string Genre { get; set; }

        /// <summary>
        /// Numeric ID of the playlist
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Numeric ID of the label
        /// </summary>
        [JsonProperty("label_id")]
        public int LabelId { get; set; }

        /// <summary>
        /// Label name
        /// </summary>
        [JsonProperty("label_name")]
        public string LabelName { get; set; }

        /// <summary>
        /// Last modified
        /// </summary>
        [JsonProperty("last_modified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// License
        /// </summary>
        [JsonProperty("license")]
        public string License { get; set; }

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
        /// Playlist type
        /// </summary>
        [JsonProperty("playlist_type")]
        public string PlaylistType { get; set; }

        /// <summary>
        /// Purchase title
        /// </summary>
        [JsonProperty("purchase_title")]
        public string PurchaseTitle { get; set; }

        /// <summary>
        /// Purchase URL
        /// </summary>
        [JsonProperty("purchase_url")]
        public string PurchaseUrl { get; set; }

        /// <summary>
        /// Release
        /// </summary>
        [JsonProperty("release")]
        public string Release { get; set; }

        /// <summary>
        /// Day of release
        /// </summary>
        [JsonProperty("release_day")]
        public int ReleaseDay { get; set; }

        /// <summary>
        /// Month of release
        /// </summary>
        [JsonProperty("release_month")]
        public int ReleaseMonth { get; set; }

        /// <summary>
        /// Year of release
        /// </summary>
        [JsonProperty("release_year")]
        public int ReleaseYear { get; set; }

        /// <summary>
        /// Sharing
        /// </summary>
        [JsonProperty("sharing")]
        public string Sharing { get; set; }

        /// <summary>
        /// Indicates if the entire playlist is streamable
        /// </summary>
        [JsonProperty("streamable")]
        public bool Streamable { get; set; }

        /// <summary>
        /// List of tags
        /// </summary>
        [JsonProperty("tag_list")]
        public string TagList { get; set; }

        /// <summary>
        /// Name of the playlist
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Number of tracks in the playlist
        /// </summary>
        [JsonProperty("track_count")]
        public int TrackCount { get; set; }

        /// <summary>
        /// Collection of tracks in the playlist
        /// </summary>
        [JsonProperty("tracks")]
        public IList<Track> Tracks { get; set; }

        /// <summary>
        /// Type of the playlist
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// SoundCloud API Resource URL
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }
        /// <summary>
        /// Creator of the playlist
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        /// Numeric ID of the playlist creator
        /// </summary>
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        #endregion Public Properties
    }
}
