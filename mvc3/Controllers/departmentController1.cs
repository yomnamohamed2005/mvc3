using Business_acess_lyer.repositories;
using Microsoft.AspNetCore.Mvc;
using Data_access_lyer.models;
namespace mvc3.Controllers
{
    public class departmentController1 : Controller
    {
        private readonly Idata_repositories datareposatory;
        public departmentController1 (Idata_repositories _repo)
        {
            datareposatory = _repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = datareposatory.Getall();
            return View(result);
        }
    }
}
