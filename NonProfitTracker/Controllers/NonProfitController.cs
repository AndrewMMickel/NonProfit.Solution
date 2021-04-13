using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NonProfitTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NonProfitTracker.Controllers
{
    public class NonProfitsController : Controller
    {
        private readonly NonProfitTrackerContext _db;

        public NonProfitsController(NonProfitTrackerContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<NonProfit> model = _db.NonProfits.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.NonProfitId = new SelectList(_db.NonProfits, "NonProfitId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(NonProfit nonProfit)
        {
            _db.NonProfits.Add(nonProfit);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            NonProfit thisNonProfit = _db.NonProfits.FirstOrDefault(nonProfits => nonProfits.NonProfitId == id);
            return View(thisNonProfit);
        }

        public ActionResult Edit(int id)
        {
            NonProfit thisNonProfit = _db.NonProfits.FirstOrDefault(NonProfit => NonProfit.NonProfitId == id);
            ViewBag.NonProfitId = new SelectList(_db.NonProfits, "NonProfitId", "Name");
            return View(thisNonProfit);
        }

        [HttpPost]
        public ActionResult Edit(NonProfit NonProfit)
        {
            _db.Entry(NonProfit).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            NonProfit thisNonProfit = _db.NonProfits.FirstOrDefault(nonProfits => nonProfits.NonProfitId == id);
            return View(thisNonProfit);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NonProfit thisNonProfit = _db.NonProfits.FirstOrDefault(nonProfit => nonProfit.NonProfitId == id);
            _db.NonProfits.Remove(thisNonProfit);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}