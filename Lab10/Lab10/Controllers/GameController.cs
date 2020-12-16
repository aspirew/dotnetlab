using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.Controllers
{
    public class GameController : Controller
    {
        private static int? n = null;
        private static int? random = null;
        public IActionResult Set(int x)
        {
            n = x;
            ViewBag.Message = $"Ustawiono liczbe n na {n}";
            return View("Game");
        }

        public IActionResult Draw()
        {
            if (n != null)
            {
                random = (new Random()).Next((int)n);
                ViewBag.Message = "Wylosowano nową liczbę!";
            }
            else
                ViewBag.Message = "Należy najpierw określić zakres";

            return View("Game");
        }
        public IActionResult Guess(int x)
        {
            if (random != null)
            {
                if (x == random)
                    ViewBag.Message = "Brawo! Odgadłeś prawidłową liczbę!";
                else if (x > random)
                    ViewBag.Message = "Podana liczba jest za duża";
                else
                    ViewBag.Message = "Podana liczba jest za mała";
            }
            else
                ViewBag.Message = "Należy najpierw wylosować liczbę";

            return View("Game");
        }

    }
}
