using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public enum ListType
    {
        Facebook,
        Auction,
        PopUp
    }

    public class Sale
    {
        public int SaleId { get; set; }

        public Plant SalePlantId { get; set; }
        //missing this one

        public double ListPrice { get; set; }

        public ListType Listing { get; set; }
        // fix thix, look at alex's view for plant

        public DateTime DateSold { get; set; }

        //public int PersonId { get; set; }

        public User Buyer { get; set; }
        // missing this one
    }
}
