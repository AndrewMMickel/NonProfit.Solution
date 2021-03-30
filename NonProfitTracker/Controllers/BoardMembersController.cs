using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NonProfitTracker.Models;

namespace NonProfitTracker.Controllers
{
    public class BoardMembersController : Controller
    {
        private readonly NonProfitTrackerContext _db;

        public BoardMembersController(NonProfitTrackerContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<BoardMember> model = _db.BoardMembers.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BoardMember boardMember)
        {
            _db.BoardMembers.Add(boardMember);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            BoardMember thisNonProfit = _db.BoardMembers.FirstOrDefault(boardMembers => boardMembers.Id == id);
            return View(thisNonProfit);
        }

        public ActionResult Delete(int id)
        {
            var thisNonProfit = _db.BoardMembers.FirstOrDefault(boardMembers => boardMembers.Id == id);
            return View(thisNonProfit);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisNonProfit = _db.BoardMembers.FirstOrDefault(boardMember => boardMember.Id == id);
            _db.BoardMembers.Remove(thisNonProfit);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}