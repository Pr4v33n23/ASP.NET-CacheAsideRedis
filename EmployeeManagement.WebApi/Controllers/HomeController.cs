
using System.Web.Mvc;

namespace EmployeeManagement.WebApi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return new RedirectResult("~/swagger/ui/index");
        }
    }
}