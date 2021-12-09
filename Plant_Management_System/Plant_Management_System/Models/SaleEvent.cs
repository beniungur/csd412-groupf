using System;
using System.ComponentModel.DataAnnotations;

namespace Plant_Management_System.Models
{
    public enum ListingType
    {
        Facebook, 
        Auction,
        PopUp
    }

    //// SaleEvent defines objects that will store plant sale activities
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
           this.DateListed = DateTime.Now;
           this.DateSold = DateTime.Now;
        }
    }
}
