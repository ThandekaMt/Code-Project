using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using timesheets_TDK_app;

namespace timesheets_TDK_app.Controllers
{
    public class TimeslotsController : Controller
    {
        private TimesheetsEntities db = new TimesheetsEntities();

        // GET: Timeslots
        public ActionResult Index()
        {
            var timeslots = db.Timeslots.Include(t => t.Project).Include(t => t.User);
            return View(timeslots.ToList());
        }

        // GET: Timeslots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timeslot timeslot = db.Timeslots.Find(id);
            if (timeslot == null)
            {
                return HttpNotFound();
            }
            return View(timeslot);
        }

        // GET: Timeslots/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username");
            return View();
        }

        // POST: Timeslots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeslotId,ProjectId,UserId,Date,HoursCaptured")] Timeslot timeslot)
        {
            if (ModelState.IsValid)
            {
                db.Timeslots.Add(timeslot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name", timeslot.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", timeslot.UserId);
            return View(timeslot);
        }

        // GET: Timeslots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timeslot timeslot = db.Timeslots.Find(id);
            if (timeslot == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name", timeslot.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", timeslot.UserId);
            return View(timeslot);
        }

        // POST: Timeslots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeslotId,ProjectId,UserId,Date,HoursCaptured")] Timeslot timeslot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeslot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "Name", timeslot.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", timeslot.UserId);
            return View(timeslot);
        }

        // GET: Timeslots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timeslot timeslot = db.Timeslots.Find(id);
            if (timeslot == null)
            {
                return HttpNotFound();
            }
            return View(timeslot);
        }

        // POST: Timeslots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timeslot timeslot = db.Timeslots.Find(id);
            db.Timeslots.Remove(timeslot);
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
    }
}
