using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public enum ListingType
    {
        Facebook, 
        Auction,
        PopUp
    }

    public class SaleEvent
    {
        public int Id { get; set; }

        public Plant PlantForSale { get; set; }

        public double ListPrice { get; set; }

        public ListingType Listing { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateListed { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateSold { get; set; }

        public AppUser Buyer { get; set; }

        public AppUser Owner { get; set; }

        public SaleEvent()
        {
            this.PlantForSale = new Plant();
            this.DateListed = DateTime.Now;
        }
    }
}
