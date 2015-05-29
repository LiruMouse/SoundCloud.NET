using Newtonsoft.Json;
using SoundCloud.NET.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundCloud.NET
{
    /// <summary>
    /// Repräsentiert einen SoundCloud Benutzer
    /// </summary>
    public class User
    {

        #region Private Constructors

        /// <summary>
        /// Privater Konstruktor
        /// </summary>
        private User()
        {

        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        /// URL zum Avatar
        /// </summary>
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; internal set; }

        /// <summary>
        /// Stadt
        /// </summary>
        [JsonProperty("city")]
        public string City { get; internal set; }

        /// <summary>
        /// Land
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; internal set; }

        /// <summary>
        /// Beschreibung
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; internal set; }

        /// <summary>
        /// Discogs Name
        /// </summary>
        [JsonProperty("discogs_name")]
        public string DiscogsName { get; internal set; }

        /// <summary>
        /// Vorname
        /// </summary>
        [JsonProperty("first_name")]
        public string Firstname { get; internal set; }

        /// <summary>
        /// Anzahl der Follower
        /// </summary>
        [JsonProperty("followers_count")]
        public int FollowersCount { get; internal set; }

        /// <summary>
        /// Anzahl an Benutzern, denen der Benutzer folgt
        /// </summary>
        [JsonProperty("followings_count")]
        public int FollowingsCount { get; internal set; }

        /// <summary>
        /// Voller Name
        /// </summary>
        [JsonProperty("full_name")]
        public string Fullname { get; internal set; }

        /// <summary>
        /// ID des Benutzers
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        /// Letzte Änderung
        /// </summary>
        [JsonProperty("last_modified")]
        public DateTime LastModified { get; internal set; }

        /// <summary>
        /// Nachname
        /// </summary>
        [JsonProperty("last_name")]
        public string Lastname { get; internal set; }

        /// <summary>
        /// MySpace Name
        /// </summary>
        [JsonProperty("myspace_name")]
        public string MySpaceName { get; internal set; }

        /// <summary>
        /// Online Status
        /// </summary>
        [JsonProperty("online")]
        public bool Online { get; internal set; }

        /// <summary>
        /// URL-Slug des Benutzers
        /// </summary>
        [JsonProperty("permalink")]
        public string Permalink { get; internal set; }

        /// <summary>
        /// SoundCloud URL
        /// </summary>
        [JsonProperty("permalink_url")]
        public string PermalinkUrl { get; internal set; }

        /// <summary>
        /// SoundCloud Abonnement
        /// </summary>
        [JsonProperty("plan")]
        public string Plan { get; internal set; }

        /// <summary>
        /// Anzahl öffentlicher Playlisten
        /// </summary>
        [JsonProperty("playlist_count")]
        public int PlaylistCount { get; internal set; }

        /// <summary>
        /// Anzahl öffentlicher Favoriten
        /// </summary>
        [JsonProperty("public_favorites_count")]
        public int PublicFavoritesCount { get; internal set; }

        /// <summary>
        /// Anzahl öffentlicher Tracks
        /// </summary>
        [JsonProperty("track_count")]
        public int TrackCount { get; internal set; }

        /// <summary>
        /// API URL
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; internal set; }

        /// <summary>
        /// Nutzername
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; internal set; }
        /// <summary>
        /// Webseite
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; internal set; }

        /// <summary>
        /// Webseiten Titel
        /// </summary>
        [JsonProperty("website_title")]
        public string WebsiteTitle { get; internal set; }

        #endregion Public Properties

        #region Internal Properties

        internal SoundCloudManager SoundCloudManager { get; set; }

        #endregion Internal Properties

        #region Public Methods

        /// <summary>
        /// Listet die Tracks des Nutzers auf
        /// </summary>
        /// <returns></returns>
        public Track[] GetTracks()
        {
            // Logging
            Trace.WriteLine("Frage Tracks von User '" + this.Id + "' an");

            // Request vorbereiten
            Request req = new Request(string.Format("/users/{0}/tracks", this.Id), this.SoundCloudManager);

            // Request ausführen
            if (req.Execute())
            {
                // Tracks deserialisieren
                Track[] tracks = req.DeserializeResult<Track[]>();

                // Verweis auf den SoundCloud Manager hinzufügen
                foreach (Track track in tracks)
                {
                    track.SoundCloudManager = this.SoundCloudManager;
                }

                return tracks;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Listet die Playlists des Nutzers auf
        /// </summary>
        /// <returns></returns>
        public Set[] GetPlaylists()
        {
            // Logging
            Trace.WriteLine("Frage Playlists von User '" + this.Id + "' an");

            // Request vorbereiten
            Request req = new Request(string.Format("/users/{0}/playlists", this.Id), this.SoundCloudManager);

            // Request ausführen
            if (req.Execute())
            {
                // Playlists deserialisieren
                Set[] sets = req.DeserializeResult<Set[]>();

                // Verweis auf den SoundCloud Manager hinzufügen
                foreach (Set set in sets)
                {
                    set.SoundCloudManager = this.SoundCloudManager;

                    // Verweis auf den SoundCloud Manager hinzufügen
                    foreach (Track t in set.Tracks)
                    {
                        t.SoundCloudManager = this.SoundCloudManager;
                    }
                }

                return sets;
            }
            else
            {
                return null;
            }
        }

        #endregion Public Methods

    }
}
