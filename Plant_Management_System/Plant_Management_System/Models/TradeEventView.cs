using System.Collections.Generic;

namespace Plant_Management_System.Models
{
    // This Class is used to support the Create view for Trade Events
    public class TradeEventView
    {
        public TradeEvent trade { get; set; }
        public AppUser Owner { get; set; }
        public List<AppUser> TraderList { get; set; }
        public List<Plant> PlantList { get; set; }
        public List<Plant> ReceivingPlantList { get; set; }
        public int TradePlant { get; set; }
        public string TraderId { get; set; }
        public int ReceivePlant { get; set; }
        public TradeEventView()
        {
            this.trade = new TradeEvent();
        }
    }
}
