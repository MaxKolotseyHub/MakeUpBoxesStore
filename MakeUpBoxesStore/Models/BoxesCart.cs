using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Models
{
    public class BoxesCart
    { 
        private static BoxesCart instance;
        public static BoxesCart GetInstance()
        {
            if (instance == null)
                instance = new BoxesCart();
            return instance;
        }

        public BoxesCart()
        {
            Boxes = new List<Box>();
        }
        private List<Box> Boxes;
        public List<Box> GetBoxes()
        {
            return Boxes;
        }
        public void Delete(int id)
        {
            var box = Boxes.FirstOrDefault(x=>x.Id== id);
            if(box != null)
            {
                Boxes.Remove(box);
            }
        }
        public bool Add(Box box)
        {
            if (Boxes.FirstOrDefault(x => x.Name.Equals(box.Name)) != null)
                return false;
            else
            {
                int id = 0;
                if (Boxes.Count != 0) 
                id = Boxes.Select(x => x.Id).Max() + 1;
                box.Id = id;
                Boxes.Add(box);
                return true;
            }
        }
    }
}