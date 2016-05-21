namespace PrimusFlex.Web.Areas.Employee.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Data.Models;
    using Data.Models.Types;

    using Infrastructure.Mapping;
    using AutoMapper;

    public class WorkReportViewModel : IMapFrom<WorkReport>, IMapTo<WorkReport>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int WeekNumber { get; set; }

        [Required]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Required]
        public string Address { get; set; }

        [Display(Name = "Kitchcen")]
        public KitchenName KitchenName { get; set; }

        public string Plot { get; set; }

        [Display(Name = "Work Type")]
        public WorkType WorkType { get; set; }

        public decimal Price { get; set; }

        public string Note { get; set; }



        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<WorkReport, WorkReportViewModel>()
                .ForMember(x => x.PostCode, opt => opt.MapFrom(x => x.ConstructionSite.PostCode));

            configuration.CreateMap<WorkReport, WorkReportViewModel>()
                .ForMember(x => x.Address, opt => opt.MapFrom(x => x.ConstructionSite.Address));
        }
    }
}
