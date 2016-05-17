namespace PrimusFlex.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using Types;

    public class Employee : BaseModel<int>
    {
        public Employee()
        {
            this.WorkReports = new HashSet<WorkReport>();
        }

        public string UserId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        public BankName BankName { get; set; }

        public string SortCode { get; set; }

        public string Account { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<WorkReport> WorkReports { get; set; }
    }
}
