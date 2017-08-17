using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travels.Common.DAL {

    [Table("visits")]
    public class Visit {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("location")]
        public int LocationId { get; set; }

        [JsonProperty("user")]
        public int UserId { get; set; }

        [JsonProperty("visited_at")]
        public int VisitedAt { get; set; }

        [JsonProperty("mark")]
        public byte Mark { get; set; }
    }
}