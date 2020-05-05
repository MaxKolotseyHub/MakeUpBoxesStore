﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Models.DbEntities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public string State { get; set; }
        public virtual List<PurchaseProduct> Products { get; set; }
        public Purchase()
        {
            Products = new List<PurchaseProduct>();
        }
    }
}