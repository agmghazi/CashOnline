using CashOnline.Models.Dao;
using CashOnline.Web.Areas.Admin.Models;
using CashOnline.Web.Common;
using System.Web.Mvc;

namespace CashOnline.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //var dao = new UserDao();
                var result = UserDao.Login(model.UserName, model.PassWord);
                if (result)
                {
                    var user = UserDao.GetById(model.UserName);
                    var userSession = new UserLogin
                    {
                        UserName = user.UserName,
                        UserId = user.ID
                    };
                    Session.Add(CommonConstants.UserSession, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("error", "كلمه المرور أو اسم المستخدم غير صحيح");
                }
            }
            return View("Index");
        }
    }
}