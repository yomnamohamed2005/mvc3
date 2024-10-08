using Microsoft.AspNetCore.Mvc;
using servicelifetime.Models;
using servicelifetime.services;
using System.Diagnostics;
using System.Text;

namespace servicelifetime.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISingleton singleton;
        private readonly ISingleton singleton2;
        private readonly IScopoed scopoed;
        private readonly IScopoed scopoed2;
        private readonly ITransient transient;
        private readonly ITransient transient2;
        public HomeController(ISingleton singleton,ISingleton singleton2,IScopoed scopoed,IScopoed scopoed2,ITransient transient,ITransient transient2)
        {
            this.singleton = singleton;
            this.singleton2 = singleton2;
            this.scopoed = scopoed;
            this.scopoed2 = scopoed2;
            this.transient = transient;
            this.transient2 = transient2;

        }
        public string Index()
             
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"singleton =:{singleton.getguid()}");
            sb.AppendLine($"singleton2 =:{singleton2.getguid()}");
            sb.AppendLine($"scopoed ={scopoed.getguid()}");
            sb.AppendLine($"scopoed2 ={scopoed2.getguid()}");
            sb.AppendLine($"transient = {transient.getguid()}");
            sb.AppendLine($"transient2 = {transient2.getguid()}");
            return sb.ToString();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
