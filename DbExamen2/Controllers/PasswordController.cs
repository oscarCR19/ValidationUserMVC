using DbExamen2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace DbExamen2.Controllers
{
	public class PasswordController : Controller
	{
		// GET: PasswordController
		public ActionResult password()
		{
            string email = HttpContext.Session.GetString("userSession");
			ViewBag.session = email;
			 return View();
		}

		public ActionResult ValidatePasswChang(string txtActualPassw, string txtNewPassw1, string txtNewPassw2,string txtInput)
		{
            

            if (String.IsNullOrEmpty(txtActualPassw) || txtActualPassw==txtNewPassw1 ||txtActualPassw==txtNewPassw2 || txtNewPassw1 != txtNewPassw2)
			{
                string email = HttpContext.Session.GetString("userSession");
                ViewBag.message = "Error en el ingreso de la contraseña";
                ViewBag.session = email;
                return View("password");
				
			}
			else
			{
                User user = new User();
                user=Users.Users.GetUsers(txtInput);
				if (Users.Users.ValidatePasswChang(user,SHA256.Sha256.getHashSha256(txtNewPassw2)) == 1)
				{
                    ViewBag.message1 = "Contraseña igual a las ultimas 7 contraseñas, por favor intente con otra";
                    ViewBag.session = txtInput!;
                    return View("password");
				}

                Users.Users.UpdatePassword(user, txtNewPassw2);
            }
            HttpContext.Session.Clear();
            return RedirectToAction("login","Login");
		}

        // GET: PasswordController/Details/5
        public ActionResult Details(int id)
		{
			return View();
		}

		// GET: PasswordController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: PasswordController/Create
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

		// GET: PasswordController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: PasswordController/Edit/5
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

		// GET: PasswordController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PasswordController/Delete/5
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
