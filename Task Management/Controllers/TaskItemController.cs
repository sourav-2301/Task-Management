using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Management.Models;

namespace Task_Management.Controllers
{
    public class TaskItemController : Controller
    {
        ProjectContext _db;

        public TaskItemController(ProjectContext db)
        {
            _db = db;
        }
        public  async Task<IActionResult>TaskItem(User obj)
        {
            var row=await _db.tbltaskItem.ToListAsync();
            return View(row);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskItem obj)
        {
            try
            {
                await _db.tbltaskItem.AddAsync(obj);          
                await _db.SaveChangesAsync();
                TempData["Message"] = "Insert Success";
            }
            catch (Exception ex)
            {
                TempData["Message"] = " Insert Failed";
            }
            return RedirectToAction("TaskItem");

        }

         public async Task<IActionResult> Delete (int id)
        {
            try
            {
                var taskl = await _db.tbltaskItem.Where(a => a.TaskId == id).FirstOrDefaultAsync();

                
                   _db.tbltaskItem.Remove(taskl);
                    await _db.SaveChangesAsync();
                    TempData["Message"] = "Delete Success";
                
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Task not found";
               
            }
            return RedirectToAction("TaskItem");

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        { 
            var row = await _db.tbltaskItem.Where(a=>a.TaskId == id).FirstOrDefaultAsync();
            return View(row);

        }
        [HttpPost]

        public async Task<IActionResult>Edit(TaskItem obj)
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
            return RedirectToAction("TaskItem");
        }



    }
}
