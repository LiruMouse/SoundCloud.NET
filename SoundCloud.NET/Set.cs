using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.NET
{
    /// <summary>
    /// Stellt eine SoundCloud Playlist dar
    /// </summary>
    public class Set
    {

        #region Private Constructors

        /// <summary>
        /// Privater Konstruktor
        /// </summary>
        private Set()
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
        /// Erstellzeitpunkt der Playlist
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; internal set; }

        /// <summary>
        /// Beschreibung
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; internal set; }

        /// <summary>
        /// Gibt an, ob alle Tracks in der Playlist herunterladbar sind
        /// </summary>
        [JsonProperty("downloadable")]
        public bool Downloadable { get; internal set; }

        /// <summary>
        /// Dauer der Playlist in Sekunden
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; internal set; }

        /// <summary>
        /// Embeddable By
        /// </summary>
        [JsonProperty("embeddable_by")]
        public string EmbeddableBy { get; internal set; }

        /// <summary>
        /// Genre
        /// </summary>
        [JsonProperty("genre")]
        public string Genre { get; internal set; }

        /// <summary>
        /// Playlist ID
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Label ID
        /// </summary>
        [JsonProperty("label_id")]
        public int LabelId { get; internal set; }

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
        /// URL-Slug der Playlist
        /// </summary>
        [JsonProperty("permalink")]
        public string Permalink { get; internal set; }

        /// <summary>
        /// SoundCloud URL der Playlist
        /// </summary>
        [JsonProperty("permalink_url")]
        public string PermalinkUrl { get; internal set; }

        /// <summary>
        /// Playlist Typ
        /// </summary>
        [JsonProperty("playlist_type")]
        public string PlaylistType { get; internal set; }

        /// <summary>
        /// Purchase Title
        /// </summary>
        [JsonProperty("purchase_title")]
        public string PurchaseTitle { get; internal set; }

        /// <summary>
        /// Purchase Url
        /// </summary>
        [JsonProperty("purchase_url")]
        public string PurchaseUrl { get; internal set; }

        /// <summary>
        /// Sharing
        /// </summary>
        [JsonProperty("sharing")]
        public string Sharing { get; internal set; }

        /// <summary>
        /// Gibt an, ob alle Tracks in der Playlist streambar sind
        /// </summary>
        [JsonProperty("streamable")]
        public bool Streamable { get; internal set; }

        /// <summary>
        /// Tag Liste
        /// </summary>
        [JsonProperty("tag_list")]
        public string TagList { get; internal set; }

        /// <summary>
        /// Titel der Playlist
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; internal set; }

        /// <summary>
        /// Anzahl der Tracks in der Playlist
        /// </summary>
        [JsonProperty("track_count")]
        public int TrackCount { get; internal set; }

        /// <summary>
        /// Tracks in der Playlist
        /// </summary>
        [JsonProperty("tracks")]
        public Track[] Tracks { get; internal set; }

        /// <summary>
        /// API URL
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; internal set; }

        /// <summary>
        /// Ersteller der Playlist
        /// </summary>
        [JsonProperty("user")]
        public User User { get; internal set; }

        #endregion Public Properties

        #region Internal Properties

        internal SoundCloudManager SoundCloudManager { get; set; }

        #endregion Internal Properties

        #region Public Methods

        /// <summary>
        /// Gibt den vollen Benutzer der Playlist zurück (seperater Request)
        /// </summary>
        /// <returns></returns>
        public User GetUser()
        {
            return this.SoundCloudManager.GetUser(this.Id);
        }

        #endregion Public Methods

    }
}
