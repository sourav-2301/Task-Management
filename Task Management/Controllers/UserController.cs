using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Task_Management.Models;

namespace Task_Management.Controllers
{
    public class UserController : Controller
    {
        ProjectContext _db;
        public UserController(ProjectContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User obj)
        {
            var row = await _db.tblUser.Where(a => a.Name == obj.Name && a.Email == obj.Email && a.Password == obj.Password && a.Role == obj.Role).FirstOrDefaultAsync();
            if (row == null)
            {
                ViewBag.Message = " invalid user";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("UserEmail", obj.Email);
                if (obj.Role != "Project Manager")
                {
                    ViewBag.Message = " access denied";
                    return View();

                }
                return RedirectToAction("Welcome");

            }

        }
         public async Task<IActionResult> Welcome()
        {
            string email_session = HttpContext.Session.GetString("UserEmail");
            if (email_session == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var details =await _db.tblUser.Where(a=>a.Email == email_session).FirstOrDefaultAsync(); 
                return View(details);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
