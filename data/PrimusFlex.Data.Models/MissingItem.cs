﻿namespace PrimusFlex.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using Types;
    using System;
    public class MissingItem : BaseModel<int>
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int ConstructionSiteId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Color { get; set; }

        public int Count { get; set; }

        [Required]
        public int Plot { get; set; }

        [Required]
        public KitchenName KitchenName { get; set; }

        public int WeekNumber { get; set; }

        public string Reason { get; set; }

        // Navigation properties

        public virtual Employee Employee { get; set; }

        public virtual ConstructionSite ConstructionSite { get; set; }
    }
}
