using PrimusFlex.Data;
using PrimusFlex.Data.Common;
using PrimusFlex.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PrimusFlex.Infrastructure.Data.Helpers
{
    public static class ConstructionSites
    {
        private static IDbRepository<ConstructionSite> constructionSites = new DbRepository<ConstructionSite>(new ApplicationDbContext());

        public static IOrderedEnumerable<SelectListItem> SetDropDownListsFrom(string columnName, string selectedItem = null)
        {
            List<SelectListItem> dropDownList = new List<SelectListItem>();

            var sites = constructionSites.All().ToList();

            foreach (var s in sites)
            {
                if (columnName == "PostCodes")
                {
                    dropDownList.Add(new SelectListItem()
                    {
                        Text = s.PostCode,
                        Value = s.Id.ToString()
                    });
                }
                else if(columnName == "Addresses" || columnName == "")
                {
                    dropDownList.Add(new SelectListItem()
                    {
                        Text = s.Address,
                        Value = s.Id.ToString()
                    });
                }
            }

            if (selectedItem != null)
            {
                foreach (var item in dropDownList)
                {
                    if (item.Text == selectedItem)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }

            return dropDownList.OrderBy(x => x.Text);
        }
    }
}
