﻿namespace PrimusFlex.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Web.Controllers;

    public class SitesController : BaseController
    {
        // GET: Admin/Sites
        public ActionResult Index()
        {
            return View();
        }
    }
}