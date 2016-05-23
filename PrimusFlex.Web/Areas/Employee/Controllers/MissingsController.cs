namespace PrimusFlex.Web.Areas.Employee.Controllers
{
    using Infrastructure.Data.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Web.Controllers;

    [Authorize(Roles = "Employee")]
    public class MissingsController : BaseController
    {
        // GET: Employee/Missings
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/Missings/Register
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.PostCodes = ConstructionSites.SetDropDownListsFrom("PostCodes");
            ViewBag.Addresses = ConstructionSites.SetDropDownListsFrom("Addresses");

            return this.View();
        }
    }
}