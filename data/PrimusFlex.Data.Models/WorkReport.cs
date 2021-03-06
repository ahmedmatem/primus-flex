﻿namespace PrimusFlex.Data.Models
{
    using System;

    using Common.Models;
    using Types;

    public class WorkReport : BaseModel<int>
    {
        public int EmployeeId { get; set; }

        public int ConstructionSiteId { get; set; }

        public DateTime Date { get; set; }

        public int WeekNumber { get; set; }

        public KitchenName KitchenName { get; set; }

        public string Plot { get; set; }

        public WorkType WorkType { get; set; }

        public decimal Price { get; set; }

        public string Note { get; set; }

        // Naviagtion properties

        public virtual Employee Employee { get; set; }

        public virtual ConstructionSite ConstructionSite { get; set; }
    }
}
