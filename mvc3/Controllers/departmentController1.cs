using Business_acess_lyer.repositories;
using Microsoft.AspNetCore.Mvc;
using Data_access_lyer.models;
using Microsoft.Identity.Client;

namespace mvc3.Controllers
{
    public class departmentController : Controller
    {
        private readonly Idata_repositories datareposatory;
        public departmentController(Idata_repositories _repo)
        {
            datareposatory = _repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = datareposatory.Getall();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(department department)
        {
            if (!ModelState.IsValid) return View(department);


            datareposatory.create(department);
            return RedirectToAction(nameof(Index));


        }
        public IActionResult details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            else
            {
                var department = datareposatory.Get(id.Value);
                if (department is null)
                {
                    return NotFound();
                }
                else
                {
                    return View(department);
                }
            }
        }
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            else
            {
                var department = datareposatory.Get(id.Value);
                if (department is null)
                {
                    return NotFound();
                }
                else
                {
                    return View(department);
                }
            }
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int Id, department department)
        {
            if (Id != department.id) { return BadRequest(); }

            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {

                        datareposatory.update(department);
                        return RedirectToAction(nameof(Index));

                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }

                return View(department);

            }

        }
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            else
            {
                var department = datareposatory.Get(id.Value);
                if (department is null)
                {
                    return NotFound();
                }
                else
                {
                    return View(department);
                }

            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {

            if (!id.HasValue) { return BadRequest(); }
            var repo = datareposatory.Get(id.Value);
            if (repo is null) { return NotFound(); }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {

                        datareposatory.delete(repo);
                        return RedirectToAction(nameof(Index));

                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", ex.Message);
                    }
                }

                return View(repo);
            }

        }
    }
}
