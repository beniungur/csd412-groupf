using System;
using System.ComponentModel.DataAnnotations;

namespace Plant_Management_System.Models
{
    // This Class defines objects that will store plant trade events
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
            this.TradeDate = DateTime.Now;
        }
    }
}
