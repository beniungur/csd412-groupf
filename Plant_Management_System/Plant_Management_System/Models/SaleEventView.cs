using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public class SaleEventView
    {
        public SaleEvent sale { get; set; }

        public List<AppUser> BuyerList { get; set; }

        public List<Plant> PlantList { get; set; }

        public int SalePlant { get; set; }
        public string BuyerId { get; set; }
       

        public SaleEventView()
        {
            this.sale = new SaleEvent();
        }
    }
}
