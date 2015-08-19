using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.NET.Models
{
    /// <summary>
    /// SoundCloud Track
    /// </summary>
    public class Track : BaseModel
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("commentable")]
        public bool Commentable { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("original_content_size")]
        public int OriginalContentSize { get; set; }

        [JsonProperty("last_modified")]
        public string LastModified { get; set; }

        [JsonProperty("sharing")]
        public string Sharing { get; set; }

        [JsonProperty("tag_list")]
        public string TagList { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("streamable")]
        public bool Streamable { get; set; }

        [JsonProperty("embeddable_by")]
        public string EmbeddableBy { get; set; }

        [JsonProperty("downloadable")]
        public bool Downloadable { get; set; }

        [JsonProperty("purchase_url")]
        public string PurchaseUrl { get; set; }

        [JsonProperty("label_id")]
        public int LabelId { get; set; }

        [JsonProperty("purchase_title")]
        public string PurchaseTitle { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("label_name")]
        public string LabelName { get; set; }

        [JsonProperty("release")]
        public DateTime Release { get; set; }

        [JsonProperty("track_type")]
        public string TrackType { get; set; }

        [JsonProperty("key_signature")]
        public object KeySignature { get; set; }

        [JsonProperty("isrc")]
        public object Isrc { get; set; }

        [JsonProperty("video_url")]
        public string VideoUrl { get; set; }

        [JsonProperty("bpm")]
        public float Bpm { get; set; }

        [JsonProperty("release_year")]
        public int ReleaseYear { get; set; }

        [JsonProperty("release_month")]
        public int ReleaseMonth { get; set; }

        [JsonProperty("release_day")]
        public int ReleaseDay { get; set; }

        [JsonProperty("original_format")]
        public string OriginalFormat { get; set; }

        [JsonProperty("license")]
        public string License { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("permalink_url")]
        public string PermalinkUrl { get; set; }

        [JsonProperty("artwork_url")]
        public string ArtworkUrl { get; set; }

        [JsonProperty("waveform_url")]
        public string WaveformUrl { get; set; }

        [JsonProperty("stream_url")]
        public string StreamUrl { get; set; }

        [JsonProperty("playback_count")]
        public int PlaybackCount { get; set; }

        [JsonProperty("download_count")]
        public int DownloadCount { get; set; }

        [JsonProperty("favoritings_count")]
        public int FavoritingsCount { get; set; }

        [JsonProperty("comment_count")]
        public int CommentCount { get; set; }

        [JsonProperty("attachments_uri")]
        public string AttachmentsUri { get; set; }

        [JsonProperty("policy")]
        public string Policy { get; set; }

        [JsonProperty("monetization_model")]
        public string MonetizationModel { get; set; }

        [JsonProperty("download_url")]
        public string DownloadUrl { get; set; }

        [JsonProperty("created_with")]
        public App CreatedWith { get; set; }
    }
}
