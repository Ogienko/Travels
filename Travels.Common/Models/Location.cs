using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travels.Common.Models {

    [Table("locations")]
    public class Location {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("place")]
        public string Place { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("distance")]
        public int Distance { get; set; }
    }
}