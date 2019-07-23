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
            ViewBag.ExpressionLog = expression.Log;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string inputField)
        {
            Expression expression = new Expression(inputField);
            string answer;
            try
            {
                answer = expression.Evaluate().ToString();
            }
            catch
            {
                answer = "Wrong input";
            }
            expression.Log.Add(inputField, answer);
            ViewBag.ExpressionLog = expression.Log;
            return View();
        }
    }
}