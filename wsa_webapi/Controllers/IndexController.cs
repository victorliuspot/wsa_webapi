using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc;

namespace wsa_webapi.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            var model = new wsa_webapi.Pages.IndexModel();
            if (!string.IsNullOrEmpty(Request.Query["id"]))
            {
                model.ImageUrls.Add(SqlHelper.GetAnnotationImage(Request.Query["id"]));
            }

            return View(model);
        }
    }
}