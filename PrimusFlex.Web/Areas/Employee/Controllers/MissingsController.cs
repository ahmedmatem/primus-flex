namespace PrimusFlex.Web.Areas.Employee.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Web.Controllers;
    using Microsoft.AspNet.Identity;

    using Data.Models;
    using Data.Common;
    using Infrastructure.Data.Helpers;
    using ViewModels;
    using Infrastructure;
    using Infrastructure.Mapping;
    [Authorize(Roles = "Employee")]
    public class MissingsController : BaseController
    {
        private readonly IDbRepository<Employee> employees;
        private readonly IDbRepository<ConstructionSite> constructionSites;
        private readonly IDbRepository<MissingItem> missingItems;

        public MissingsController(
            IDbRepository<Employee> employees,
            IDbRepository<ConstructionSite> constructionSites,
            IDbRepository<MissingItem> missingItems)
        {
            this.employees = employees;
            this.constructionSites = constructionSites;
            this.missingItems = missingItems;
        }

        // GET: Employee/Missings
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var employee = this.employees.All()
                .Where(e => e.UserId == userId)
                .FirstOrDefault();

            var model = this.missingItems.All()
                .Where(m => m.EmployeeId == employee.Id)
                .To<MissingItemViewModel>()
                .ToList();

            return View(model);
        }

        // GET: Employee/Missings/Register
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.PostCodes = ConstructionSites.SetDropDownListsFrom("PostCodes");
            ViewBag.Addresses = ConstructionSites.SetDropDownListsFrom("Addresses");

            return this.View();
        }

        // GET: Employee/Missings/RegisterWithNewSite
        [HttpGet]
        public ActionResult RegisterWithNewSite()
        {

            return this.View();
        }

        // POST: Employee/Missings/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(MissingItemViewModel model)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.PostCodes = ConstructionSites.SetDropDownListsFrom("PostCodes", model.PostCode);
                ViewBag.Addresses = ConstructionSites.SetDropDownListsFrom("Addresses", model.Address);

                return this.View(model);
            }

            var user = this.UserManager.FindById(this.User.Identity.GetUserId());

            var employee = this.employees.All()
                .First(e => e.UserId == user.Id);

            var missing = this.Mapper.Map<MissingItem>(model);
            missing.WeekNumber = DateTimeHelper.GetIso8601WeekOfYear(DateTime.Now);

            int siteId = 0;
            if(!int.TryParse(model.PostCode, out siteId))
            {
                // Site not exist. Create it.
                var constructionSite = new ConstructionSite()
                {
                    PostCode = model.PostCode,
                    Address = model.Address
                };
                this.constructionSites.Add(constructionSite);

                siteId = constructionSite.Id;
            }

            missing.ConstructionSiteId = siteId;
            missing.EmployeeId = employee.Id;

            this.missingItems.Add(missing);
            this.missingItems.Save();

            return RedirectToAction("Index");
        }
    }
}