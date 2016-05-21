namespace PrimusFlex.Web.Areas.Employee.Controllers
{
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
    }
}