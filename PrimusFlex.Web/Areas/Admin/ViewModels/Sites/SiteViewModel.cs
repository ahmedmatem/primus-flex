namespace PrimusFlex.Web.Areas.Admin.ViewModels.Sites
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Data.Models;
    using Infrastructure.Mapping;
    using Data.Models.Types;

    public class SiteViewModel : IMapFrom<Site>
    {
        public int Name { get; set; }

        public string PostCode { get; set; }

        public string Address { get; set; }

        public KitchenName KitchenName { get; set; }
        
        public bool Confirmed { get; set; }
    }
}
