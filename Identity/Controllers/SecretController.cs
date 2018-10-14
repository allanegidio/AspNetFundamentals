using System.Web.Mvc;

namespace Identity.Controllers
{
    public class SecretController : Controller
    {
        [Authorize(Roles = "admin, sales")]
        public ContentResult Secret()
        {
            return Content("This is a secret...");
        }

        [AllowAnonymous]
        public ContentResult Overt()
        {
            return Content("This is not a secret...");
        }
    }
}