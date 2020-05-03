using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Models.DbEntities
{
    public class Box
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Dictionary<int,int> ProductCount { get; set; }
    }
}