namespace PrimusFlex.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    using PrimusFlex.Data.Common.Models;

    public class MissingItem : BaseModel<int>
    {
        public int EmployeeId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Count { get; set; }

        // Navigation properties

        public virtual Employee Employee { get; set; }
    }
}
