using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NonProfitTracker.Models;

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
        NonProfit thisNonProfit = _db.NonProfits.FirstOrDefault(nonProfits => nonProfits.Id == id);
        return View(thisNonProfit);
    }

    public ActionResult Delete(int id)
    {
        var thisNonProfit = _db.NonProfits.FirstOrDefault(nonProfits => nonProfits.Id == id);
        return View(thisNonProfit);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisNonProfit = _db.NonProfits.FirstOrDefault(nonProfit => nonProfit.Id == id);
        _db.NonProfits.Remove(thisNonProfit);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}