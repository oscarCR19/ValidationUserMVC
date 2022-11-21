using DbExamen2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DbExamen2.Controllers
{
    public class DashboardController : Controller
    {
        // GET: DashboarController
        public ActionResult dashboard()
        {
            
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("userSession")))
            {
                string email = HttpContext.Session.GetString("userSession");
                User user= new User();
                user=Users.Users.GetUsers(email);
                ViewBag.Name = user.Name;
                ViewBag.Email = user.Email;
                ViewBag.Photo = user.Photo;
                ViewBag.Datein = user.Datein;
                return View();
            }
            else
            
            return RedirectToAction("login", "Login");
            
        }

        public ActionResult GoToPassword()
        {
            return RedirectToAction("password","Password");
        }

        public ActionResult CloseSession()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("dashboard","Dashboard");
        }

        // GET: DashboarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashboarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashboarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DashboarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
