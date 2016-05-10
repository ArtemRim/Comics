using Comics.Filters;
using Comics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using Comics.ViewModel;
using System.Text;
namespace Comics.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        UnitOfWork db = new UnitOfWork();
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
                return RedirectToAction("Main");
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }




        [HttpPost]
        public JsonResult InsertPageTemplate(PartViewModel pageTemplate)
        {
            var pagetem = new PageTemplate
            {
                URL = "http://res.cloudinary.com/dhye3oycy/image/upload/v1462728835/PageTemplate/4.jpg"
            };
            db.PageTemplates.Create(pagetem);
            db.Parts.CreateList(pageTemplate.Parts, pagetem);
            db.Save();
            var temp = db.Parts.GetAllForPage(pagetem.Id);
            return Json("OK", "application/json", Encoding.UTF8);
        }



        public ActionResult Load()
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