namespace PrimusFlex.Web.Areas.Employee.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Infrastructure.Mapping;
    using Data.Models.Types;

    public class MissingItemViewModel : IMapFrom<MissingItem>, IMapTo<MissingItem>
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int ConstructionSiteId { get; set; }

        [Required]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int Width { get; set; }
        
        public int Height { get; set; }

        public string Color { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int Plot { get; set; }

        [Required]
        public KitchenName KitchenName { get; set; }

        public string Reason { get; set; }
    }
}
