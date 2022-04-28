using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SearchFunctionalityMVC.Models;

namespace SearchFunctionalityMVC.Controllers
{
    public class emloyeeTBsController : Controller
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();

        // GET: emloyeeTBs
        public ActionResult Index(string searchBy, string Search)
        {
            if(searchBy == "Name" )
            {   //coment code for fullname  and 2nd for starting word search....
                //var data=db.emloyeeTBs.Where(model => model.name == Search).FirstOrDefault();
                var data = db.emloyeeTBs.Where(model => model.name.StartsWith(Search)).ToList();
                return View(data);
            }
          else
            {
                var data = db.emloyeeTBs.ToList();
                return View(data);
            }
            //return View(db.emloyeeTBs.ToList());
        }

        // GET: emloyeeTBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emloyeeTB emloyeeTB = db.emloyeeTBs.Find(id);
            if (emloyeeTB == null)
            {
                return HttpNotFound();
            }
            return View(emloyeeTB);
        }

        // GET: emloyeeTBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: emloyeeTBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,gender,age,description")] emloyeeTB emloyeeTB)
        {
            if (ModelState.IsValid)
            {
                db.emloyeeTBs.Add(emloyeeTB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emloyeeTB);
        }

        // GET: emloyeeTBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emloyeeTB emloyeeTB = db.emloyeeTBs.Find(id);
            if (emloyeeTB == null)
            {
                return HttpNotFound();
            }
            return View(emloyeeTB);
        }

        // POST: emloyeeTBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,gender,age,description")] emloyeeTB emloyeeTB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emloyeeTB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emloyeeTB);
        }

        // GET: emloyeeTBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            emloyeeTB emloyeeTB = db.emloyeeTBs.Find(id);
            if (emloyeeTB == null)
            {
                return HttpNotFound();
            }
            return View(emloyeeTB);
        }

        // POST: emloyeeTBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            emloyeeTB emloyeeTB = db.emloyeeTBs.Find(id);
            db.emloyeeTBs.Remove(emloyeeTB);
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
