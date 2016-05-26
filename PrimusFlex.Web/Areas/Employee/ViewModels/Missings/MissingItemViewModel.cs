namespace PrimusFlex.Web.Areas.Employee.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Infrastructure.Mapping;
    using Data.Models.Types;
    using AutoMapper;

    public class MissingItemViewModel : IMapFrom<MissingItem>, IMapTo<MissingItem>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        
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

        public int WeekNumber { get; set; }
        
        public DateTime Date { get; set; }


        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<MissingItem, MissingItemViewModel>()
                .ForMember(x => x.Date, opt => opt.MapFrom(x => x.CreatedOn));

            configuration.CreateMap<MissingItem, MissingItemViewModel>()
                .ForMember(x => x.PostCode, opt => opt.MapFrom(x => x.ConstructionSite.PostCode));

            configuration.CreateMap<MissingItem, MissingItemViewModel>()
                .ForMember(x => x.Address, opt => opt.MapFrom(x => x.ConstructionSite.Address));
        }
    }
}
