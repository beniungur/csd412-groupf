using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public class TradeEvent
    {
        public int Id { get; set; }

        public AppUser Owner { get; set; }

        public Plant PlantToTrade { get; set; }

        public AppUser TradeTo { get; set; }

        public Plant PlantToReceive { get; set; }

        [DataType(DataType.Date)]
        public DateTime TradeDate { get; set; } 

        public TradeEvent()
        {
            //this.PlantToTrade = new Plant();
            //this.TradeDate = DateTime.Now;
        }
    }
}
