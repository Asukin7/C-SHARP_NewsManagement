using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using NewsManagement.Models;

namespace NewsManagement.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult login(User user)
        {
            DbNewsDataContext db = new DbNewsDataContext();
            IQueryable<User> query = from t in db.user
                                     where t.username == user.username && t.password == user.password
                                     select new User
                                     {
                                         id = t.id,
                                         username = t.username,
                                         nickname = t.nickname,
                                         type = t.type
                                     };
            List<User> userList = query.ToList();
            if (userList.Count() == 1)
            {
                userList[0].password = null;
                Session.Add("user", userList[0]);
                Session.Add("type", userList[0].type);
                return Json(Result.success());
            }
            else
            {
                return Json(Result.fail());
            }
        }
    }

}