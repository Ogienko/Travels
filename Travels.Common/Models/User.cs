using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using Travels.Common.Models.BaseModels;

namespace Travels.Common.Models {

    [Table("users")]
    public class User: UserBase {

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}