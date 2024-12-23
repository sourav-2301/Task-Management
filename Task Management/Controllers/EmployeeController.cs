using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Management.Models;

namespace Task_Management.Controllers
{
    public class EmployeeController : Controller
    {
        ProjectContext _db; //refference
        public EmployeeController(ProjectContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Employee(User obj)  
        {
            var emp = await _db.tblemployee.ToListAsync();
            return View(emp);                     
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee obj)
        {
            try
            {
                await _db.tblemployee.AddAsync(obj);         
                await _db.SaveChangesAsync();
                TempData["Message"] = "Insert Success";
            }
            catch (Exception ex)
            {
                TempData["Message"] = " Insert Failed";
            }
            return RedirectToAction("Employee");

        }

        public async Task<IActionResult> Delete (int id)
        {
            try
            {
                var empl = await _db.tblemployee.Where(a => a.EmpId == id).FirstOrDefaultAsync();

                
                   _db.tblemployee.Remove(empl);
                    await _db.SaveChangesAsync();
                    TempData["Message"] = "Delete Success";
                
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Employee not found";
               
            }
            return RedirectToAction("Employee");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        { 
            var row = await _db.tblemployee.Where(a=>a.EmpId == id).FirstOrDefaultAsync();
            return View(row);

        }
        [HttpPost]

        public async Task<IActionResult>Edit(Employee obj)
        {

            try
            {
                _db.Entry(obj).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                TempData["Message"] = "Update Successfull";

            }
            catch (Exception ex)
            {
                TempData["Message"] = "Update Failed";
            }
            return RedirectToAction("Employee");
        }




    }
}
