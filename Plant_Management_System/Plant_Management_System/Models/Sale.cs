using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public class Sale
    {
        public enum ListType
        {
            Facebook,
            Auction,
            PopUp
        }

        public int SaleId { get; set; }

        public int PlantId { get; set; }

        public double ListPrice { get; set; }

        public ListType Listing { get; set; }

        public DateTime DateSold { get; set; }

        public int PersonId { get; set; }

        public string Buyer { get; set; }
    }
}
