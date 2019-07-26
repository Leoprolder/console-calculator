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
        public ActionResult Index()
        {
            ViewBag.ExpressionLog = new List<KeyValuePair<String, String>>();
            Expression expression = new Expression();
            return View();
        }

        [HttpPost]
        public ActionResult Index(string inputField)
        {
            Expression expression = new Expression(inputField);
            string answer;
            try
            {
                answer = expression.Calculate().ToString();
            }
            catch (Exception ex)
            {
                answer = $"Wrong input, {ex.Message}";
            }

            if (Session["log"] == null)
            {
                List<KeyValuePair<String, String>> log = new List<KeyValuePair<String, String>>();
                log.Add(new KeyValuePair<string, string>(inputField, answer));
                Session.Add("log", log);
            }
            else
            {
                List<KeyValuePair<String, String>> tempDict = Session["log"] as List<KeyValuePair<String, String>>;
                tempDict.Add(new KeyValuePair<string, string>(inputField, answer));
                Session["log"] = tempDict;
            }
            ViewBag.ExpressionLog = Session["log"] as List<KeyValuePair<String, String>>;
            ViewBag.inputField = "";
            return View();
        }
    }
}