using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ModelCore.Entities
{
    public class Products
    {
        #region Properties

        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public Categories Categories { get; set; }

        #endregion
    }
}
