using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.Controllers
{
    public class ToolController : Controller
    {

        private static (double?, double?) calculateQuadratic(double a, double b, double c)
        {
            if (a != 0)
            {
                double delta = Math.Pow(b, 2) - 4 * a * c;
                if (delta < 0) return (null, null);
                else if (delta == 0) return (-b / 2 * a, null);
                else return (-b - Math.Sqrt(delta) / 2 * a, -b + Math.Sqrt(delta) / 2 * a);
            }
            else if (b != 0)
            {
                return (-c / b, null);
            }
            else if (c == 0) return (double.MaxValue, double.MaxValue);
            else return (null, null);

        }
        private static (string, string) formatResult(double? res)
        {
            if (res == null) return ("Brak rozwiazania", "#FF0000");
            else if (res == double.MaxValue) return ("Nieskonczona ilosc rozwiazan", "#00FFFF");
            else if (res > -0.00001 && res < 0.00001 && res != 0) return (res?.ToString("E5"), "#007700");
            else return (res?.ToString("F5"), "#00FF00");
        }

        // GET: ToolController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Solve(int a, int b, int c)
        {
            var result = calculateQuadratic(a, b, c);
            var format1 = formatResult(result.Item1);
            var format2 = formatResult(result.Item2);

            ViewBag.Result1 = format1.Item1;
            ViewBag.Result1Color = format1.Item2;
            ViewBag.Result2 = format2.Item1;
            ViewBag.Result2Color = format2.Item2;
            return View();
        }

    }
}
