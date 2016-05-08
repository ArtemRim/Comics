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

        public ActionResult  CreateComics()
        {

            return View();
        }




        [HttpPost]
        public JsonResult InsertPageTemplate(List<Part> pageTemplate)
        {
            var pagetem = new PageTemplate
            {
                URL = "http://res.cloudinary.com/dhye3oycy/image/upload/v1462581218/zswcdi2tl0djaue937as.jpg"
            };
            db.PageTemplates.Create(pagetem);
            db.Parts.CreateList(pageTemplate, pagetem);
            db.Save();
            var temp = db.Parts.GetAllForPage(pagetem.Id);
            return Json("OK", "application/json", Encoding.UTF8);
        }

        public ActionResult ComicsEditor()
        {
            Templates templates = new Templates
            {
                DialogTemplates = db.DialogTemplates.GetAll(),
                PageTemplates = db.PageTemplates.GetAll()
            };
            return View(templates);
        }

        public ActionResult Load()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetPageTemplate(int id)
        {
            List<Part> parts = db.Parts.GetAllForPage(id);
            return Json(parts, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; 
                {
                    CloudStorage storage = new CloudStorage(Resources.Resource.CloudName, Resources.Resource.ApiKey, Resources.Resource.ApiSecret);
                    var URL = storage.Upload(file);
                    return Json(URL, "application/json", Encoding.UTF8);
                }
            }
            return Json("Exception", "application/json", Encoding.UTF8);
        }


        [HttpGet]
        public JsonResult GetTags(string term)
        {        
            List<String> tags = db.Tags.GetAutoComplete(term);           
            return Json(tags, JsonRequestBehavior.AllowGet);
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