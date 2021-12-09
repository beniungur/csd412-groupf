using System;
using System.ComponentModel.DataAnnotations;

namespace Plant_Management_System.Models
{
    // This Class defines objects that will store wish list objects
    public class WishList
    {
        public int WishListId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        public string PlantName { get; set; }
        public double Budget { get; set; }
        public AppUser User { get; set; }
    }
}
