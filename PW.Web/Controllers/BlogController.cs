using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PW.Web.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult PostList()
        {
            return View();
        }

        public ActionResult PublishPost()
        {
            return View();
        }
    }
}