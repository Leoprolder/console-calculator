using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using console_calculator.Models.Evaluation;

namespace console_calculator.Controllers
{
    public class HomeController : Controller
    {
        ControllerContext controllerContext = new ControllerContext();

        public ActionResult Index()
        {
            Expression.Log = new Dictionary<string, string>();
            //Expression.Log.Add("Hello", "World");
            ViewBag.ExpressionLog = Expression.Log;
            return View();
        }

        [HttpGet]
        public ActionResult GetValue(string TextExpression)
        {
            Expression.TextExpression = TextExpression;
            return View("Index");
        }
    }
}