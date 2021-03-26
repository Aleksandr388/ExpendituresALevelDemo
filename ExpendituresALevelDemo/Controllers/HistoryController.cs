using ExpendituresALevelDemo.Models.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpendituresALevelDemo.Controllers
{
    public class HistoryController : Controller
    {
        // GET: History
        public ActionResult MyHistories()
        {
            var model = new HistoryViewModel { Id = 3, Name = "Open history page", CreateDate = DateTime.Now };

            return View("~/Views/History/MyHistories.cshtml", model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}