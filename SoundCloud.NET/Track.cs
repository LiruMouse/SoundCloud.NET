using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.NET
{
    /// <summary>
    /// Stellt einen SoundCloud Track dar
    /// </summary>
    public class Track
    {

        #region Private Constructors

        /// <summary>
        /// Privater Kontruktor
        /// </summary>
        private Track()
        {

        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        /// Artwork URL
        /// </summary>
        [JsonProperty("artwork_url")]
        public string ArtworkUrl { get; internal set; }

        /// <summary>
        /// Beats per minute
        /// </summary>
        [JsonProperty("bpm")]
        public int BPM { get; internal set; }

        /// <summary>
        /// Gibt an, ob Kommentare abgegeben werden können
        /// </summary>
        [JsonProperty("commentable")]
        public bool Commentable { get; internal set; }

        /// <summary>
        /// Anzahl der Kommentare
        /// </summary>
        [JsonProperty("comment_count")]
        public int CommentCount { get; internal set; }

        /// <summary>
        /// Erstelldatum des Tracks
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; internal set; }

        /// <summary>
        /// Beschreibung des Tracks
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; internal set; }

        /// <summary>
        /// Gibt an, ob der Track heruntergeladen werden kann
        /// </summary>
        [JsonProperty("downloadable")]
        public bool Downloadable { get; internal set; }

        /// <summary>
        /// Anzahl der Downloads
        /// </summary>
        [JsonProperty("download_count")]
        public int DownloadCount { get; internal set; }

        /// <summary>
        /// Länge des Tracks in Sekunden
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; internal set; }

        /// <summary>
        /// Embeddable By
        /// </summary>
        [JsonProperty("embeddable_by")]
        public string EmbeddableBy { get; internal set; }

        /// <summary>
        /// Anzahl der Favorisierungen
        /// </summary>
        [JsonProperty("favoritings_count")]
        public int FavoritingsCount { get; internal set; }

        /// <summary>
        /// Genre
        /// </summary>
        [JsonProperty("genre")]
        public string Genre { get; internal set; }

        /// <summary>
        /// ID des Tracks
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Label ID
        /// </summary>
        [JsonProperty("label_id")]
        public string LabelId { get; internal set; }

        /// <summary>
        /// Label Name
        /// </summary>
        [JsonProperty("label_name")]
        public string LabelName { get; internal set; }

        /// <summary>
        /// Letzte Änderung
        /// </summary>
        [JsonProperty("last_modified")]
        public DateTime LastModified { get; internal set; }

        /// <summary>
        /// Lizenz
        /// </summary>
        [JsonProperty("license")]
        public string License { get; internal set; }

        /// <summary>
        /// Eindeutiger Trackname
        /// </summary>
        [JsonProperty("permalink")]
        public string Permalink { get; internal set; }

        /// <summary>
        /// SoundCloud URL des Tracks
        /// </summary>
        [JsonProperty("permalink_url")]
        public string PermalinkUrl { get; internal set; }

        /// <summary>
        /// Anzahl der Wiedergaben
        /// </summary>
        [JsonProperty("playback_count")]
        public int PlaybackCount { get; internal set; }

        /// <summary>
        /// Purchase Title
        /// </summary>
        [JsonProperty("purchase_title")]
        public string PurchaseTitle { get; internal set; }

        /// <summary>
        /// Purchase URL
        /// </summary>
        [JsonProperty("purchase_url")]
        public string PurchaseUrl { get; internal set; }

        /// <summary>
        /// Sharing
        /// </summary>
        [JsonProperty("sharing")]
        public string Sharing { get; internal set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonProperty("state")]
        public string State { get; internal set; }

        /// <summary>
        /// Gibt an, ob der Track streambar ist
        /// </summary>
        [JsonProperty("streamable")]
        public bool Streamable { get; internal set; }

        /// <summary>
        /// Stream URL
        /// </summary>
        [JsonProperty("stream_url")]
        public string StreamUrl { get; internal set; }

        /// <summary>
        /// Liste von Tags
        /// </summary>
        [JsonProperty("tag_list")]
        public string TagList { get; internal set; }

        /// <summary>
        /// Titel des Tracks
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; internal set; }

        /// <summary>
        /// API URL
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; internal set; }

        /// <summary>
        /// Benutzer, der den Track hochgeladen hat
        /// </summary>
        [JsonProperty("user")]
        public User User { get; internal set; }

        /// <summary>
        /// Waveform URL
        /// </summary>
        [JsonProperty("waveform_url")]
        public string WaveformUrl { get; internal set; }

        #endregion Public Properties

        #region Internal Properties

        internal SoundCloudManager SoundCloudManager { get; set; }

        #endregion Internal Properties

        #region Public Methods

        /// <summary>
        /// Gibt den vollen Benutzer des Tracks zurück (seperater Request)
        /// </summary>
        /// <returns></returns>
        public User GetUser()
        {
            return this.SoundCloudManager.GetUser(this.Id);
        }

        #endregion Public Methods

    }
}
