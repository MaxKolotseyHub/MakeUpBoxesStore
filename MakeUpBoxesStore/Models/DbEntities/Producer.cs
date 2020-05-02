using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Models.DbEntities
{
    public class Producer
    {

        public Producer()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}