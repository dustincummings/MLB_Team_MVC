
using MLB_Teams.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MLB_Teams.Controllers
{
    public class MLBController : Controller
    {
        private MLB_TeamsDBContext db = new MLB_TeamsDBContext();

        // GET: MLB
        public ActionResult Index()
        {
            return View(db.MLB_Teams.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Name, City, StadiumName, FirstYear")] MLBTeam mLB_Teams)
        {
            if (ModelState.IsValid)
            {
                db.MLB_Teams.Add(mLB_Teams);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mLB_Teams);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MLBTeam mLb_Teams = db.MLB_Teams.Find(id);
            if(mLb_Teams == null)
            {
                return HttpNotFound();
            }
            return View(mLb_Teams);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MLBTeam mLBTeam = db.MLB_Teams.Find(id);
            db.MLB_Teams.Remove(mLBTeam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MLBTeam mLBTeams = db.MLB_Teams.Find(id);
            if(mLBTeams == null)
            {
                return HttpNotFound();
            }
            return View(mLBTeams);
        }
    }
}