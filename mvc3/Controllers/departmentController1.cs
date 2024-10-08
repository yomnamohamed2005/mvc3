﻿using Business_acess_lyer.repositories;
using Microsoft.AspNetCore.Mvc;
using Data_access_lyer.models;
using Microsoft.Identity.Client;
using Business_acess_lyer.interfaces;
namespace mvc3.Controllers
{
    public class departmentController : Controller
    {
        //private readonly IGenericRepositories<department> repo;
        private readonly Idata_repositories repo;
        public departmentController(Idata_repositories _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = repo.Getall();
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


        repo.create(department);
            return RedirectToAction(nameof(Index));


        }
        public IActionResult details(int? id) => departmentcontrollerhandler(id, nameof(details));

        public IActionResult Edit(int? id) => departmentcontrollerhandler(id, nameof(Edit));


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int Id, department department)
        {
            if (Id != department.id) { return BadRequest(); }

            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {

                        repo.update(department);
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
        public IActionResult Delete(int? id) => departmentcontrollerhandler(id, nameof(Delete));
       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int? id)
        {

            if (!id.HasValue) { return BadRequest(); }
            var repo1 = repo.Get(id.Value);
            if (repo1 is null) { return NotFound(); }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {

                        repo.delete(repo1);
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
        private IActionResult departmentcontrollerhandler(int? id ,string viewname)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            else
            {
                var department = repo.Get(id.Value);
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
    }
}
