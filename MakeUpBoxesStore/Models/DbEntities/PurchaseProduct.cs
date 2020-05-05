using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Models.DbEntities
{
    public class PurchaseProduct
    {
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
        [Display(Name = "Производитель")]
        [Required]
        public string Producer { get; set; }
    }
}