using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Models.DbEntities
{
    public class Category
    {
            public Category()
            {
                Products = new List<Product>();
            }
            public int Id { get; set; }
            [Display(Name = "Название")]
            [Required]
            public string Title { get; set; }
            public virtual List<Product> Products { get; set; }
        }
}