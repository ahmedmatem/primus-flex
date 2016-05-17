namespace PrimusFlex.Web.Areas.Admin.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    using Data.Models;

    using Infrastructure.Mapping;

    public class EmployeeViewModel : IMapFrom<Employee>, IMapTo<Employee>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
    }
}