using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Travels.Common.Models.BaseModels {

    public class LocationBase {

        [Required]
        [JsonProperty("place")]
        public string Place { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonProperty("country")]
        public string Country { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonProperty("city")]
        public string City { get; set; }

        [Required]
        [JsonProperty("distance")]
        public int? Distance { get; set; }
    }
}