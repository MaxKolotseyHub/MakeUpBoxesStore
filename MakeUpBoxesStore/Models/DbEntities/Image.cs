using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Models.DbEntities
{
    public class Image
    {
        public int Id { get; set; }
        [Display(Name = "Путь к изображению")]
        public string Url { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}