using Comics.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comics.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult CultureEn()
        {
            SaveCookieLanguage(Resources.Resource.En);
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }

        public ActionResult CultureRu()
        {
            SaveCookieLanguage(Resources.Resource.Ru);
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }


        public void SaveCookieLanguage(String language)
        {
            HttpCookie cookie = Request.Cookies[Resources.Resource.Language];
            if (cookie != null)
                cookie.Value = language;
            else
                cookie = CreateCookie(language);
            Response.Cookies.Add(cookie);
        }


        private HttpCookie CreateCookie(String language)
        {
            HttpCookie cookie = new HttpCookie(Resources.Resource.Language);
            cookie.HttpOnly = false;
            cookie.Value = language;
            cookie.Expires = DateTime.Now.AddYears(1);
            return cookie;
        }

    }
}