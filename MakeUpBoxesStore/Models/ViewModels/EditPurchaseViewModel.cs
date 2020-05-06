using MakeUpBoxesStore.Models.DbEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Models.ViewModels
{
    public class EditPurchaseViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Имя клиента")]
        [Required]
        public string ClientName { get; set; }
        [Display(Name = "Адрес клиента")]
        [Required]
        public string ClientAddress { get; set; }
        [Display(Name = "Телефон клиента")]
        [Required]
        public string ClientPhone { get; set; }
        [Display(Name = "Статус заказа")]
        [Required]
        public string State { get; set; }
        public List<PurchaseProduct> Products{ get; set; }
    }
}