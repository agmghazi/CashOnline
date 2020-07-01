using CashOnline.Web.Common;
using System.Web.Mvc;
using System.Web.Routing;

namespace CashOnline.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        ////this code for add multi language in your app
        //protected override void Initialize(RequestContext requestContext)
        //{
        //    base.Initialize(requestContext);
        //    if (Session[CommonConstants.CurrentCulture] != null)
        //    {
        //        Thread.CurrentThread.CurrentCulture =
        //            new CultureInfo(Session[CommonConstants.CurrentCulture].ToString());
        //        Thread.CurrentThread.CurrentCulture =
        //            new CultureInfo(Session[CommonConstants.CurrentCulture].ToString());
        //    }
        //    else
        //    {
        //        Session[CommonConstants.CurrentCulture] = "ar";
        //        Thread.CurrentThread.CurrentCulture = new CultureInfo("ar");
        //        Thread.CurrentThread.CurrentCulture = new CultureInfo("ar");
        //    }
        //}
        ////this code for add multi language in your app
        //public ActionResult ChangeCulture(string ddCulture, string returnUrl)
        //{
        //    Thread.CurrentThread.CurrentCulture = new CultureInfo(ddCulture);
        //    Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddCulture);

        //    Session[CommonConstants.CurrentCulture] = ddCulture;
        //    return Redirect(returnUrl);

        //}
        //this code for create custom session
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.CurrentCulture] as UserLogin;
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }
        //for custom message in your app
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "Success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

    }
}