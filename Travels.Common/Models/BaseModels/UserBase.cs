using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Travels.Common.Models.BaseModels {

    public class UserBase {

        [Required]
        [MaxLength(100)]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(1)]
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [Required]
        [Range(-1262304000, 915148800)]
        [JsonProperty("birth_date")]
        public int BirthDate { get; set; }
    }
}