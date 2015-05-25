using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Account.Models;

namespace Account.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new User());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogIn()
        {
            return View("SignIn", new User());
        }

        public ActionResult SignIn(User model)
        {
            UserTable user;
            IEnumerable<User> users = null;

            using (var ef = new UserDBEntities4())
            {
                user = ef.UserTable.SingleOrDefault(x => x.Email == model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Email", "Неверный email");
                    return View("SignIn", model);
                }
                else if (user.Password == model.Password)
                {
                    users = GetAllUsers(users);
                }
                else
                {
                    ModelState.AddModelError("Password", "Неверный пароль");
                    return View("SignIn", model);
                }
            }
            return View("Save", users);
        }

        public ActionResult Save(HttpPostedFileBase file, User model)
        {
            if (file == null)
            {
                ModelState.AddModelError("ContentType", "Загрузите картинку!");
                return View("Index", model);
            }
            if (file.ContentType != "image/png" && file.ContentLength < 10000000)
            {
                ModelState.AddModelError("ContentType", "Каритнка должна быть формата PNG и не больше 10MB");
                return View("Index", model);
            }
            
            //получение картинки
            model.Base64String = GetByteArrayString(file);
            model.ContentType = file.ContentType;

            AddUserToDB(model);

            IEnumerable<User> users = null;
            users = GetAllUsers(users);
            
            return View("Save", users);
        }

        private string GetByteArrayString(HttpPostedFileBase file)
        {
            byte[] data;

            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                data = binaryReader.ReadBytes(file.ContentLength);
                return Convert.ToBase64String(data);
            }
        }

        private void AddUserToDB(User model)
        {
            using (var entites = new UserDBEntities4())
            {
                var info = new UserTable()
                {
                    Id = Guid.NewGuid(),
                    Description = model.Description,
                    Email = model.Email,
                    ImageBase64 = model.Base64String,
                    ImageContentType = model.Description,
                    Password = model.Password
                };

                entites.UserTable.Add(info);
                entites.SaveChanges();
            }
        }

        private IEnumerable<User> GetAllUsers(IEnumerable<User> users)
        {
            using (var ef = new UserDBEntities4())
            {
                users = ef.UserTable.Select(x => new User()
                {
                    Email = x.Email,
                    Description = x.Description,
                    ContentType = x.ImageContentType,
                    Base64String = x.ImageBase64
                }).ToList();

            }
            return users;
        }
    }
}