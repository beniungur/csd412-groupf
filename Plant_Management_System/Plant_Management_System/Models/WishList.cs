using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public class WishList
    {
        public int WishListId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        public string PlantName { get; set; }

        public double Budget { get; set; }
    }
}
