using Microsoft.AspNetCore.Mvc;
using MVC_Demo2.Models;
using MVC_Demo2.Services;

namespace MVC_Demo2.Controllers
{
    public class EmpController : Controller
    {
        private readonly IEmployeeRepo IEmployeeRepo;
        

        public EmpController(IEmployeeRepo IEmployeeRepo)
        {
            this.IEmployeeRepo = IEmployeeRepo;
        }
        public IActionResult Index()
        {
            var emp = IEmployeeRepo.GetAllEmployees();
            return View(emp);
        }
        public IActionResult Details(int id)
        {
            var emp = IEmployeeRepo.GetEmployee(id);
            return View(emp);
        }

        public IActionResult Update(int id)
        {
            var emp = IEmployeeRepo.GetEmployee(id);
            return View(emp);
        }
        public IActionResult Delete(int id)
        {
            var model = IEmployeeRepo.Delete(id);
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]

        public ActionResult DeleteData(int id)
        {
            try
            {
                var model = IEmployeeRepo.Delete(id);
                return View(model);
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            var emp = IEmployeeRepo.GetEmployee(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult Edit(int id, Employee updatedEmp)
        {
            if (id != updatedEmp.Eid)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                IEmployeeRepo.Update(updatedEmp);
                return RedirectToAction(nameof(Index));
            }

            return View(updatedEmp);
        }


    }
}
