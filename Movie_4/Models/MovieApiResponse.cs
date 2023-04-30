using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_4.Models
{
    public class MovieApiResponse
    {
        [JsonProperty("Search")]
        public Cinema[] Movies { get; set; }
        [JsonProperty("totalResults")]
        public string TotalResults { get; set; }
        public string Response { get; set; }
    }
}
