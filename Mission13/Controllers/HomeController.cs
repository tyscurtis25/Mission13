using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }

        //constructor
        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int bowlerTeam)
        {
            var blah = _repo.Bowlers
                .Where(b => b.TeamID == bowlerTeam || bowlerTeam >= 0)
                .ToList();

            return View(blah);
        }

        //FORM SECTION
        [HttpGet]
        public IActionResult AddBowler()
        {
            //ViewBag.Categories = _repo.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if (ModelState.IsValid) //validation for form
            {
                _repo.AddBowler(b);
                _repo.Save(b);

                return View("ConfirmationPage", b);
            }
            else //if invalid
            {
                ViewBag.Categories = _repo.Bowlers.ToList();
                return View(b);
            }
        }

        //EDIT + DELETE SECTION
        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Categories = _repo.Bowlers.ToList();

            var entry = _repo.Bowlers
                .Single(x => x.BowlerID == bowlerid);

            return View("AddBowler", entry);
        }

        [HttpPost]
        public IActionResult Edit(Bowler instance) //instance is just an instance of Movies on the form
        {
            if (ModelState.IsValid)
            {
                _repo.Edit(instance);
                _repo.Save(instance);

                return RedirectToAction("Index");
            }
            else //if invalid
            {
                ViewBag.Categories = _repo.Bowlers.ToList();
                return View(instance);
            }
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var entry = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View(entry);
        }

        [HttpPost]
        public IActionResult Delete(Bowler bowler)
        {
            _repo.Delete(bowler);
            _repo.Save(bowler);

            return RedirectToAction("Index");
        }
    }
}
