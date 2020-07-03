using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsManagement.Models;

namespace NewsManagement.Controllers
{
    public class BackstageController : Controller
    {
        public ActionResult Index()
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult NewsAdd()
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                if (user.type == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Backstage");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult NewsManagement()
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                if (user.type == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Backstage");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult CategoryManagement()
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                if (user.type == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Backstage");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult CommentManagement()
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                if (user.type == 1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Backstage");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public JsonResult getUserInfo()
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                DbNewsDataContext db = new DbNewsDataContext();
                var query = from t in db.user
                            where t.id == user.id
                            select new User
                            {
                                id = t.id,
                                username = t.username,
                                nickname = t.nickname,
                                type = t.type
                            };
                User userQuery = (User)query.First();
                return Json(Result.success(userQuery));
            }
            else
            {
                return Json(Result.fail());
            }
        }
        [HttpPost]
        public JsonResult addUser(user requestData)
        {
            requestData.nickname = requestData.username;
            requestData.type = 0;
            DbNewsDataContext db = new DbNewsDataContext();
            db.user.InsertOnSubmit(requestData);
            db.SubmitChanges();
            return Json(Result.success());
        }
        [HttpPost]
        public JsonResult setUserNickname(User requestData)
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                DbNewsDataContext db = new DbNewsDataContext();
                var query = from t in db.user
                            where t.id == user.id
                            select t;
                foreach (user item in query)
                {
                    item.nickname = requestData.nickname;
                    db.SubmitChanges();
                }
                return Json(Result.success());
            }
            else
            {
                return Json(Result.fail());
            }
        }
        [HttpPost]
        public JsonResult setUserPassword(User requestData)
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                DbNewsDataContext db = new DbNewsDataContext();
                var query = from t in db.user
                            where t.id == user.id
                            select t;
                foreach (user item in query)
                {
                    item.password = requestData.password;
                    db.SubmitChanges();
                }
                return Json(Result.success());
            }
            else
            {
                return Json(Result.fail());
            }
        }
        [HttpPost]
        public JsonResult getCategoryList()
        {
            DbNewsDataContext db = new DbNewsDataContext();
            var query = from t in db.category
                        select new Category
                        {
                            id = t.id,
                            name = t.name,
                        };
            List<Category> categoryList = query.ToList();
            return Json(Result.success(categoryList));
        }
        [HttpPost]
        public JsonResult addCategory(category category)
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                if (user.type == 1)
                {
                    DbNewsDataContext db = new DbNewsDataContext();
                    db.category.InsertOnSubmit(category);
                    db.SubmitChanges();
                    return Json(Result.success());
                }
                else
                {
                    return Json(Result.fail());
                }
            }
            else
            {
                return Json(Result.fail());
            }
        }
        [HttpPost]
        public JsonResult delCategory(category category)
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                if (user.type == 1)
                {
                    DbNewsDataContext db = new DbNewsDataContext();
                    var query = from t in db.category
                                where t.id == category.id
                                select t;
                    foreach (category item in query)
                    {
                        db.category.DeleteOnSubmit(item);
                    }
                    db.SubmitChanges();
                    return Json(Result.success());
                }
                else
                {
                    return Json(Result.fail());
                }
            }
            else
            {
                return Json(Result.fail());
            }
        }
        [HttpPost]
        public JsonResult getNewsList(News news)
        {
            DbNewsDataContext db = new DbNewsDataContext();
            if (news.categoryId > 0)
            {
                var query = from t in db.news
                            where t.categoryId == news.categoryId
                            select new News
                            {
                                id = t.id,
                                title = t.title,
                                summary = t.summary,
                                date = (DateTime)t.date,
                                categoryName = t.category.name,
                                userNickname = t.user.nickname
                            };
                List<News> newsList = query.ToList();
                return Json(Result.success(newsList));
            }
            else
            {
                var query = from t in db.news
                            select new News
                            {
                                id = t.id,
                                title = t.title,
                                summary = t.summary,
                                date = (DateTime)t.date,
                                categoryName = t.category.name,
                                userNickname = t.user.nickname
                            };
                List<News> newsList = query.ToList();
                return Json(Result.success(newsList));
            }
        }
        [HttpPost]
        public JsonResult getNews(News news)
        {
            DbNewsDataContext db = new DbNewsDataContext();
            if (news.id > 0)
            {
                var query = from t in db.news
                            where t.id == news.id
                            select new News
                            {
                                id = t.id,
                                title = t.title,
                                summary = t.summary,
                                content = t.content,
                                date = (DateTime)t.date,
                                categoryName = t.category.name,
                                userNickname = t.user.nickname
                            };
                News newsList = query.First();
                return Json(Result.success(newsList));
            }
            else
            {
                return Json(Result.fail());
            }
        }
        [HttpPost]
        public JsonResult addNews(news news)
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                if (user.type == 1)
                {
                    news.userId = user.id;
                    news.date = DateTime.Now;
                    DbNewsDataContext db = new DbNewsDataContext();
                    db.news.InsertOnSubmit(news);
                    db.SubmitChanges();
                    return Json(Result.success());
                }
                else
                {
                    return Json(Result.fail());
                }
            }
            else
            {
                return Json(Result.fail());
            }
        }
        [HttpPost]
        public JsonResult delNews(news news)
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                if (user.type == 1)
                {
                    DbNewsDataContext db = new DbNewsDataContext();
                    var query = from t in db.news
                                where t.id == news.id
                                select t;
                    foreach (news item in query)
                    {
                        db.news.DeleteOnSubmit(item);
                    }
                    db.SubmitChanges();
                    return Json(Result.success());
                }
                else
                {
                    return Json(Result.fail());
                }
            }
            else
            {
                return Json(Result.fail());
            }
        }
        [HttpPost]
        public JsonResult getCommentList(Comment comment)
        {
            DbNewsDataContext db = new DbNewsDataContext();
            if (comment.newsId > 0)
            {
                var query = from t in db.comment
                            where t.newsId == comment.newsId && t.status == comment.status
                            select new Comment
                            {
                                id = t.id,
                                status = (int)t.status,
                                content = t.content,
                                date = (DateTime)t.date,
                                newsTitle = t.news.title,
                                userNickname = t.user.nickname
                            };
                List<Comment> commentList = query.ToList();
                return Json(Result.success(commentList));
            }
            else
            {
                var query = from t in db.comment
                            select new Comment
                            {
                                id = t.id,
                                status = (int)t.status,
                                content = t.content,
                                date = (DateTime)t.date,
                                newsTitle = t.news.title,
                                userNickname = t.user.nickname
                            };
                List<Comment> commentList = query.ToList();
                return Json(Result.success(commentList));
            }
        }
        [HttpPost]
        public JsonResult addComment(comment comment)
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                comment.userId = user.id;
                comment.status = 0;
                comment.date = DateTime.Now;
                DbNewsDataContext db = new DbNewsDataContext();
                db.comment.InsertOnSubmit(comment);
                db.SubmitChanges();
                return Json(Result.success());
            }
            else
            {
                return Json(Result.fail());
            }
        }
        [HttpPost]
        public JsonResult setCommentStatus(comment comment)
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                if (user.type == 1)
                {
                    DbNewsDataContext db = new DbNewsDataContext();
                    var query = from t in db.comment
                                where t.id == comment.id
                                select t;
                    foreach (comment item in query)
                    {
                        item.status = 1;
                        db.SubmitChanges();
                    }
                    return Json(Result.success());
                }
                else
                {
                    return Json(Result.fail());
                }
            }
            else
            {
                return Json(Result.fail());
            }
        }
        [HttpPost]
        public JsonResult delComment(comment comment)
        {
            User user = (User)Session["user"];
            if (user != null)
            {
                if (user.type == 1)
                {
                    DbNewsDataContext db = new DbNewsDataContext();
                    var query = from t in db.comment
                                where t.id == comment.id
                                select t;
                    foreach (comment item in query)
                    {
                        db.comment.DeleteOnSubmit(item);
                    }
                    db.SubmitChanges();
                    return Json(Result.success());
                }
                else
                {
                    return Json(Result.fail());
                }
            }
            else
            {
                return Json(Result.fail());
            }
        }
    }
}