using Microsoft.AspNetCore.Mvc;

namespace WereldbouwerAPI.Controllers
{
    public class HomeController : Controller
    {
        private List<string> logger = new List<string>();
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }
    }
}
