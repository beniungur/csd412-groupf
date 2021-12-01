using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Management_System.Models
{
    public class Trade
    {
        public int TradeId { get; set; }

        public int PlantId { get; set; }

        public int PersonId { get; set; }

        public string ReceivingPlant { get; set; }
    }
}
