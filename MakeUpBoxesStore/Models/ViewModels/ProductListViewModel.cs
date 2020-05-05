using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Models.ViewModels
{
    public class ProductListViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Название")]
        public string Title { get; set; }
        [Display(Name ="Производитель")]
        public string Producer { get; set; }
        [Display(Name ="Количество")]
        public int  Count { get; set; }
        [Display(Name ="Цена")]
        public double Price { get; set; }
    }
}