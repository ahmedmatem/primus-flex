namespace PrimusFlex.Web.Areas.Employee.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Infrastructure.Mapping;
    using Infrastructure;
    using Web.Controllers;
    using ViewModels;
    using Models;
    using Data.Common;
    using Data.Models;

    [Authorize(Roles = "Employee")]
    public class ReportsController : BaseController
    {
        private readonly IDbRepository<WorkReport> workReports;
        private readonly IDbRepository<Employee> employees;
        private readonly IDbRepository<ConstructionSite> constructionSites;

        public ReportsController(IDbRepository<WorkReport> workReports,
            IDbRepository<Employee> employees,
            IDbRepository<ConstructionSite> constructionSites)
        {
            this.workReports = workReports;
            this.employees = employees;
            this.constructionSites = constructionSites;
        }

        // GET: Employee/Reports{/Index}
        public ActionResult Index()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());

            var employee = this.employees.All()
                .First(e => e.UserId == user.Id);

            ViewBag.EmployeeName = employee.Name;

            var reports = this.workReports.All()
                .Where(wr => wr.EmployeeId == employee.Id)
                .OrderByDescending(wr => wr.WeekNumber)
                .ThenBy(wr => wr.Date)
                .To<WorkReportViewModel>()
                .ToList();

            ViewBag.WeekSummury = WeekSummury.MakeWeekSummury(reports);

            return View(reports);
        }

        // GET: Employee/Repoerts/CreateWithNewSite
        [HttpGet]
        public ActionResult CreateWithNewSite()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());

            var employee = this.employees.All()
                .First(e => e.UserId == user.Id);

            var model = new WorkReportViewModel()
            {
                EmployeeId = employee.Id,
                Date = DateTime.Now
            };

            return this.View(model);
        }

        // GET: Employee/Reports/Create
        [HttpGet]
        public ActionResult Create()
        {
            var user = this.UserManager.FindById(this.User.Identity.GetUserId());

            var employee = this.employees.All()
                .First(e => e.UserId == user.Id);

            var model = new WorkReportViewModel()
            {
                EmployeeId = employee.Id,
                Date = DateTime.Now
            };

            SetConstructionSiteDropDownLists();

            return this.View(model);
        }

        // POST: Employee/Reports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkReportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var report = this.Mapper.Map<WorkReport>(model);
            report.WeekNumber = DateTimeHelper.GetIso8601WeekOfYear(model.Date);
            
            int siteId = 0;
            if (!int.TryParse(model.PostCode, out siteId))
            {
                // Site not exist. Create new site.
                var constructionSite = new ConstructionSite()
                {
                    PostCode = model.PostCode,
                    Address = model.Address
                };
                this.constructionSites.Add(constructionSite);
                siteId = constructionSite.Id;
            }

            report.ConstructionSiteId = siteId;

            this.workReports.Add(report);
            this.workReports.Save();

            return RedirectToAction("Index");
        }

        // GET: Employee/Reports/Update/Id
        [HttpGet]
        public ActionResult Update(int id)
        {
            var report = this.workReports.GetById(id);

            var model = this.Mapper.Map<WorkReportViewModel>(report);

            var constructionSite = this.constructionSites.GetById(report.ConstructionSiteId);

            SetConstructionSiteDropDownLists(constructionSite.PostCode, constructionSite.Address);
            
            return this.View(model);
        }

        // GET: Employee/Reports/UpdateWithNewSite/Id
        [HttpGet]
        public ActionResult UpdateWithNewSite(int id)
        {
            var report = this.workReports.GetById(id);

            var model = this.Mapper.Map<WorkReportViewModel>(report);

            return this.View(model);
        }

        // POST: Employee/Reports/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(WorkReportViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var report = this.workReports.GetById(model.Id);
            report.Date = model.Date;
            report.KitchenName = model.KitchenName;
            report.Plot = model.Plot;
            report.WorkType = model.WorkType;
            report.Price = model.Price;
            report.Note = model.Note;
            report.WeekNumber = DateTimeHelper.GetIso8601WeekOfYear(model.Date);

            int siteId = 0;
            if (!int.TryParse(model.PostCode, out siteId))
            {
                // Site not exist. Create new site.
                var constructionSite = new ConstructionSite()
                {
                    PostCode = model.PostCode,
                    Address = model.Address
                };
                this.constructionSites.Add(constructionSite);
                siteId = constructionSite.Id;
            }

            report.ConstructionSiteId = siteId;

            this.workReports.Update(report);
            this.workReports.Save();

            return RedirectToAction("Index");
        }

        private void SetConstructionSiteDropDownLists(string postCode = null, string address = null)
        {
            List<SelectListItem> postCodes = new List<SelectListItem>();
            List<SelectListItem> addresses = new List<SelectListItem>();
            var constructionSites = this.constructionSites.All().ToList();
            foreach (var cs in constructionSites)
            {
                postCodes.Add(new SelectListItem()
                {
                    Text = cs.PostCode,
                    Value = cs.Id.ToString()
                });
                addresses.Add(new SelectListItem()
                {
                    Text = cs.Address,
                    Value = cs.Id.ToString()
                });
            }

            foreach (var pc in postCodes)
            {
                if (pc.Text == postCode)
                {
                    pc.Selected = true;
                    break;
                }
            }
            foreach (var a in addresses)
            {
                if (a.Text == postCode)
                {
                    a.Selected = true;
                    break;
                }
            }

            ViewBag.PostCodes = postCodes.OrderBy(x => x.Text);
            ViewBag.Addresses = addresses.OrderBy(x => x.Text);
        }
    }
}