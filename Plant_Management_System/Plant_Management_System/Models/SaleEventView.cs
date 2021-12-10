using System.Collections.Generic;

namespace Plant_Management_System.Models
{
    //This Class is used to support the create view for SaleEvents
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
