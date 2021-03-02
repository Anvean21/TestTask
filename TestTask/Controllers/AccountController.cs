using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestTask.Core;
using TestTask.Infrasctructure;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class AccountController : Controller
    {
        EFUnitOfWork eFUnitOfWork;
        public AccountController()
        {
            eFUnitOfWork = new EFUnitOfWork("DefaultConnection");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = eFUnitOfWork.Users.GetAll().FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = eFUnitOfWork.Users.GetAll().FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);

                if (user == null)
                {
                    eFUnitOfWork.Users.Create(new User { Email = model.Name, Password = model.Password, RoleId = 2 });
                    eFUnitOfWork.Save();
                   
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    
                }
                else
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
            }
            return View(model);
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}