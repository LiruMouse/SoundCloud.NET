using Newtonsoft.Json;
using SoundCloud.NET.Models;
using System;

namespace SoundCloud.NET
{
    internal class SearchResults<T> where T : BaseModel
    {
        /// <summary>Results</summary>
        [JsonProperty("collection")]
        public T[] Results { get; set; }

        /// <summary>Next Page</summary>
        [JsonProperty("next_href")]
        public Uri NextPage { get; set; }
    }
}
