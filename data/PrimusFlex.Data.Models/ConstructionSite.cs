namespace PrimusFlex.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    using PrimusFlex.Data.Common.Models;
    
    public class ConstructionSite : BaseModel<int>
    {
        public ConstructionSite()
        {
            this.WorkReports = new HashSet<WorkReport>();
        }
        
        public string PostCode { get; set; }

        public string Address { get; set; }

        // Navigation properties

        public virtual ICollection<WorkReport> WorkReports { get; set; }
    }
}
