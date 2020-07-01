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
                var result = UserDao.Login(model.UserName, Encryptor.Md5Hash(model.PassWord));
                if (result == 1)
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
                else if (result == -1)
                {
                    ModelState.AddModelError("", "تم وقف الحساب الخاص بكم مؤقتا");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "اسم المستخدم غير صحيح");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "كلمه المرور غير صحيحه");
                }
            }
            return View("Index");
        }
    }
}