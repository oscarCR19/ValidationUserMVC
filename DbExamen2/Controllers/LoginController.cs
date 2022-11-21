using DbExamen2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;


namespace DbExamen2.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult login()
        {
            return View();
        }

        public ActionResult ValidateUser(string txtEmail,string txtPassword)
        {
            User user = new User()
            {
               Email = txtEmail,
                Password = SHA256.Sha256.getHashSha256(txtPassword),
            };

            if(Users.Users.ValidateUser(user) > 0)
            {
                HttpContext.Session.SetString("userSession", user.Email);
                return RedirectToAction("dashboard", "Dashboard");
            }

            
            if (Users.Users.ValidateUser(user) == 0)
                ViewBag.mensaje = "Error en los credenciales ingresadas";




            return View("login");
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
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

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
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

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
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
