using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelCore.Entities
{
    public class Categories
    {
        #region Contruct

        public Categories() 
            => Products = new List<Products>();

        #endregion

        #region Properties

        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        
        //products list by categories
        public List<Products> Products { get; set; }
        
        #endregion
    }
}
