using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NonProfitTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            BoardMember thisBoardMember = _db.BoardMembers.FirstOrDefault(boardMembers => boardMembers.BoardMemberId == id);
            return View(thisBoardMember);
        }

        public ActionResult Edit(int id)
        {
            BoardMember thisBoardMember = _db.BoardMembers.Include(BoardMember => BoardMember.NonProfit).FirstOrDefault(BoardMember => BoardMember.BoardMemberId == id);
            return View(thisBoardMember);
        }
        [HttpPost]
        public ActionResult Edit(BoardMember BoardMember)
        {
            _db.Entry(BoardMember).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            BoardMember thisBoardMember = _db.BoardMembers.FirstOrDefault(boardMembers => boardMembers.BoardMemberId == id);
            return View(thisBoardMember);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisBoardMember = _db.BoardMembers.FirstOrDefault(boardMember => boardMember.BoardMemberId == id);
            _db.BoardMembers.Remove(thisBoardMember);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}