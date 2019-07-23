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
            Expression expression = new Expression();
            expression.Log = new Dictionary<string, string>();
            //Expression.Log.Add("Hello", "World");
            ViewBag.ExpressionLog = expression.Log;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string inputField)
        {
            var a = inputField;
            Expression expression = new Expression();
            expression.Log = new Dictionary<string, string>();
            expression.Log.Add(inputField, "Incorrect expression");
            ViewBag.ExpressionLog = expression.Log;
            return View();
        }
    }
}