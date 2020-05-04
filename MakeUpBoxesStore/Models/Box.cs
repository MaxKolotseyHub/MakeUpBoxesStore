using MakeUpBoxesStore.Models.DbEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Models
{
    public class Box
    {
        public Box()
        {
            ProductCount = new Dictionary<Product, int>();
        }
        public int Id { get; set; }
        [Display(Name="Название")]
        [Required(ErrorMessage ="Заполните поле")]
        public string Name { get; set; }
        public Dictionary<Product,int> ProductCount { get; set; }
    }
}