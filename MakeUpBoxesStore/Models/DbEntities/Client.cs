using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Models.DbEntities
{
    public class Client
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Мобильный телефон")]
        [Required]
        public string Phone { get; set; }
        [Display(Name = "Адрес")]
        [Required]
        public string Address { get; set; }
    }
}