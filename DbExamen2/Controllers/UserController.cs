using DbExamen2.Models;
using DbExamen2.Users;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using Image = System.Drawing.Image;

namespace DbExamen2.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult user()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveUser(string txtName,
                                     string txtEmail,
                                     string txtPassword,
                                     IFormFile photo)
        {
            

            string fileName = txtEmail + ".jpg";
            string photoPath =@"\wwwroot\"+@"\img\"+ fileName;

            if(photo != null)
            using (var stream= new FileStream(Directory.GetCurrentDirectory()+ photoPath, FileMode.Create))
            {
                photo.CopyTo(stream);
               
            }



            User user = new User() {
                Name = txtName,
                Email = txtEmail,
                Password = SHA256.Sha256.getHashSha256(txtPassword),
                Photo = "/img/" + fileName,
                Datein = DateTime.Now,
                };
            if (Users.Users.ValidateEmail(user) != 0)
            {
               ViewBag.alerta = "Email se encuentra registrado";
                return View("user");
            }
            else
            {

                Users.Users.InsertUser(user);
                ViewBag.alerta = "Usuario registrado con éxito";
                return View("user");
            }
            
            return View();
        }

        public ActionResult GoLogin()
        {
            return RedirectToAction("login","Login");
        }


        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
