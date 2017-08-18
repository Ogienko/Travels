using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Travels.Common.Models.BaseModels {

    public class VisitBase {

        [Required]
        [JsonProperty("location")]
        public int? LocationId { get; set; }

        [Required]
        [JsonProperty("user")]
        public int? UserId { get; set; }

        [Required]
        [JsonProperty("visited_at")]
        public int? VisitedAt { get; set; }

        [Required]
        [Range(0, 5)]
        [JsonProperty("mark")]
        public byte? Mark { get; set; }
    }
}