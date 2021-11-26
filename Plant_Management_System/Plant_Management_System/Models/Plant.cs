using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Plant_Management_System.Models
{
    public enum WaterNeed
    {
        High,
        Medium,
        Low
    }
    public enum LightNeed
    {
        High,
        Medium,
        Low
    }
    public enum GrowthMediums
    {
        [Description("Soil")]
        Soil,
        [Description("Aroid-mix")]
        AroidMix,
        [Description("Cactus-Mix")]
        CactusMix,
        [Description("Soilless")]
        Soilless
    }
    public enum PotTypes
    {
        Plastic,
        Terracotta,
        Metal,
        Other
    }
    public enum Rarities
    {
        Rare,
        [Description("Semi-Rare")]
        SemiRare,
        Common
    }
    public enum Availabilities
    {
        [Description("Not For Sale")]
        NFS,
        [Description("For Sale")]
        FS
    }

    public class Plant
    {
        public int PlantId { get; set; }
        public string Name { get; set; }
        public WaterNeed WaterNeeds { get; set; }
        public LightNeed LightNeeds { get; set; }
        public GrowthMediums GrowthMedium { get; set; }
        public PotTypes PotType { get; set; }
        public Rarities Rarity { get; set; }
        public Availabilities Availability { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastRepotted { get; set; }
        public int CareLogId { get; set; }
        public int OwnerId { get; set; }
    }
}
