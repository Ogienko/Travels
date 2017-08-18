using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Travels.Common.Models.BaseModels;

namespace Travels.Common.Models {

    [Table("locations")]
    public class Location : LocationBase{

        [Required]
        [JsonProperty("id")]
        public int? Id { get; set; }
    }
}