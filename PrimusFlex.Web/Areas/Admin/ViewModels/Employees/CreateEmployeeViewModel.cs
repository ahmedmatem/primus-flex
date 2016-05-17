namespace PrimusFlex.Web.Areas.Admin.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    using Infrastructure.Mapping;

    using Data.Models.Types;
    using Data.Models;

    public class CreateEmployeeViewModel : IMapFrom<Employee>, IMapTo<Employee>
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        // Bank details

        [Required]
        public BankName BankName { get; set; }

        [Required]
        public string SortCode { get; set; }

        [Required]
        public string Account { get; set; }
    }
}
