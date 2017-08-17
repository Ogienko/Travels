using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travels.Common.DAL {

    [Table("users")]
    public class User {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("birth_date")]
        public int BirthDate { get; set; }
    }
}