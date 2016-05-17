namespace PrimusFlex.Web.Controllers
{
    using System.Web.Mvc;
    using System.Web;

    using Microsoft.AspNet.Identity.Owin;

    using AutoMapper;
    using Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        protected ApplicationUserManager userManager;

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }
    }
}
