using Newtonsoft.Json;
using System;

namespace SoundCloud.NET.Models
{
    /// <summary>
    /// Represents a SoundCloud track
    /// </summary>
    public class Track : BaseModel
    {
        #region Public Properties

        /// <summary>
        /// Cover URL
        /// </summary>
        [JsonProperty("artwork_url")]
        public string ArtworkUrl { get; set; }

        /// <summary>
        /// Attachments URL
        /// </summary>
        [JsonProperty("attachments_uri")]
        public string AttachmentsUri { get; set; }

        /// <summary>
        /// Beats per Minute
        /// </summary>
        [JsonProperty("bpm")]
        public float Bpm { get; set; }

        /// <summary>
        /// Indicates if comments are allowed
        /// </summary>
        [JsonProperty("commentable")]
        public bool Commentable { get; set; }

        /// <summary>
        /// Number of comments
        /// </summary>
        [JsonProperty("comment_count")]
        public int CommentCount { get; set; }

        /// <summary>
        /// Created at
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// App used to create the track
        /// </summary>
        [JsonProperty("created_with")]
        public App CreatedWith { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Indicates if the track is downloadable
        /// </summary>
        [JsonProperty("downloadable")]
        public bool Downloadable { get; set; }

        /// <summary>
        /// Number of downloads
        /// </summary>
        [JsonProperty("download_count")]
        public int DownloadCount { get; set; }

        /// <summary>
        /// URL zum Download
        /// </summary>
        [JsonProperty("download_url")]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Duration in seconds
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Embeddable by
        /// </summary>
        [JsonProperty("embeddable_by")]
        public string EmbeddableBy { get; set; }

        /// <summary>
        /// Number of likes
        /// </summary>
        [JsonProperty("favoritings_count")]
        public int FavoritingsCount { get; set; }

        /// <summary>
        /// Genre
        /// </summary>
        [JsonProperty("genre")]
        public string Genre { get; set; }

        /// <summary>
        /// Numeric ID of the track
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// ISRC
        /// </summary>
        [JsonProperty("isrc")]
        public object Isrc { get; set; }

        /// <summary>
        /// Key signature
        /// </summary>
        [JsonProperty("key_signature")]
        public object KeySignature { get; set; }

        /// <summary>
        /// Numeric ID of the track
        /// </summary>
        [JsonProperty("label_id")]
        public int LabelId { get; set; }

        /// <summary>
        /// Name of the label
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
        /// Monetization model
        /// </summary>
        [JsonProperty("monetization_model")]
        public string MonetizationModel { get; set; }

        /// <summary>
        /// Size of the uploaded file
        /// </summary>
        [JsonProperty("original_content_size")]
        public int OriginalContentSize { get; set; }

        /// <summary>
        /// Format of the uploaded file
        /// </summary>
        [JsonProperty("original_format")]
        public string OriginalFormat { get; set; }

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
        /// Number of playbacks
        /// </summary>
        [JsonProperty("playback_count")]
        public int PlaybackCount { get; set; }

        /// <summary>
        /// Policy
        /// </summary>
        [JsonProperty("policy")]
        public string Policy { get; set; }

        /// <summary>
        /// Purchase Title
        /// </summary>
        [JsonProperty("purchase_title")]
        public string PurchaseTitle { get; set; }

        /// <summary>
        /// Purchase Url
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
        /// Year of Release
        /// </summary>
        [JsonProperty("release_year")]
        public int ReleaseYear { get; set; }

        /// <summary>
        /// Sharing
        /// </summary>
        [JsonProperty("sharing")]
        public string Sharing { get; set; }

        /// <summary>
        /// State
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Indicates if the track is streamable
        /// </summary>
        [JsonProperty("streamable")]
        public bool Streamable { get; set; }

        /// <summary>
        /// MP3 Stream URL
        /// </summary>
        [JsonProperty("stream_url")]
        public string StreamUrl { get; set; }

        /// <summary>
        /// List of tags
        /// </summary>
        [JsonProperty("tag_list")]
        public string TagList { get; set; }

        /// <summary>
        /// Track title
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Track type
        /// </summary>
        [JsonProperty("track_type")]
        public string TrackType { get; set; }

        /// <summary>
        /// SoundCloud API Resource URL
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Creator of the track
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        /// Numeric ID of the creator
        /// </summary>
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Music video URL
        /// </summary>
        [JsonProperty("video_url")]
        public string VideoUrl { get; set; }

        /// <summary>
        /// Waveform URL
        /// </summary>
        [JsonProperty("waveform_url")]
        public string WaveformUrl { get; set; }

        #endregion Public Properties
    }
}
