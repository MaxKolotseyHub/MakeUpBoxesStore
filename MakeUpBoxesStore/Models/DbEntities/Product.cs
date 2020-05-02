using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Models.DbEntities
{
    public class Product
    {

        public Product()
        {
            Images = new List<Image>();
        }
        public int Id { get; set; }
        [Display(Name = "Название")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Количество")]
        [Required]
        public int Count { get; set; }
        [Display(Name = "Цена")]
        [Required]
        public double Price { get; set; }
        [Display(Name = "Описание")]
        [Required]
        public string Description { get; set; }
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Image> Images { get; set; }
    }
}