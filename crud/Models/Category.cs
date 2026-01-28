using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Models
{
    public class Category
    {
        public int Id {get; set;}
        [Required]
        [MinLength(3,ErrorMessage ="Min Length is 3")]
        [MaxLength(10)]
        public string Name {get; set;}
        [Required]
        public string Description {get; set;}

        public List<Product>? Products {get; set;}
    }
}