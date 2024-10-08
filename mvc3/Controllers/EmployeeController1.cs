using Business_acess_lyer.interfaces;
using Data_access_lyer.models;
using Microsoft.AspNetCore.Mvc;
using Business_acess_lyer.repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoMapper;
using mvc3.viewmodels;
using System.Reflection;


namespace mvc3.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _mapper;
        public EmployeeController(IUnitofwork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public IActionResult Index(string ? searchvalue)
        {
            // ViewData["message"] = "hello view1";
            // ViewData["message"] = new employee { name = "yomna";
            // ViewBag.message = new employee { name = "mona" };
            var emp = Enumerable.Empty<employee>();
            if(string.IsNullOrEmpty(searchvalue))
             emp = _unitofwork.employees.getallwithdepartment();
            else
                emp = _unitofwork.employees.Getall();
            var emp1 = _mapper.Map<IEnumerable<employee>,IEnumerable<Employeeviewmodel>>(emp);
            return View(emp1);
        }
        public IActionResult Create()

        {
            var department = _unitofwork.data.Getall();
            SelectList list = new SelectList(department,"id","name");
            ViewBag.department = list;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employeeviewmodel employeevm)
        {
            if (!ModelState.IsValid) return View(employeevm);

            var employee1 = _mapper.Map<Employeeviewmodel, employee>(employeevm);
            _unitofwork.employees.create(employee1);
            _unitofwork.SaveChanges();
            return RedirectToAction(nameof(Index));


        }
        public IActionResult details(int? id) => Employeecontrollerhandler(id, nameof(details));
        public IActionResult Edit(int? id) => Employeecontrollerhandler(id, nameof(Edit));
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id , Employeeviewmodel employeevm)
        {
            if (id != employeevm.Id) return BadRequest();
            if(ModelState.IsValid)
            {
                try

                {
                    var employee1 = _mapper.Map<Employeeviewmodel,employee>(employeevm);
                    _unitofwork.employees.update(employee1);
                    if (_unitofwork.SaveChanges()> 0)
                        TempData["message"] = "update successfully";

                    
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(employeevm);
        }
        public IActionResult Delete(int? id) => Employeecontrollerhandler(id, nameof(Delete));
        [HttpPost, ActionName("Delete")]
        public IActionResult confirmdelete(int ?id)
        {
            if (!id.HasValue) { return BadRequest(); }
            var repo1 = _unitofwork.employees.Get(id.Value);
            if (repo1 is null) { return NotFound(); }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {

                        _unitofwork.employees.delete(repo1);
                        _unitofwork.SaveChanges();
                        return RedirectToAction(nameof(Index));

                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }

                return View(repo1);
            }
        }
        private IActionResult Employeecontrollerhandler(int? id, string viewname)
        {
            if (viewname == nameof(Edit))
            {
                var department = _unitofwork.data.Getall();
                SelectList list = new SelectList(department, "id", "name");
                ViewBag.department = list;
            }
            if (!id.HasValue)
            {
                return BadRequest();
            }
            else
            {
                var Employee = _unitofwork.employees.Get(id.Value);
                if (Employee is null)
                {
                    return NotFound();
                }
                else
                {
                    var empvm = _mapper.Map<Employeeviewmodel>(Employee);
                    return View(empvm);
                }
            }
        }
    }
}
