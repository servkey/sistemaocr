using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudOCR.Models;

namespace CloudOCR.Controllers
{
    public class UcrController : Controller
    {
        private UcrContext db = new UcrContext();

        // GET: /Ucr/
        public ActionResult Index()
        {
            return View(db.ucrs.ToList());
        }

        // GET: /Ucr/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ucr ucr = db.ucrs.Find(id);
            if (ucr == null)
            {
                return HttpNotFound();
            }
            return View(ucr);
        }

        // GET: /Ucr/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Ucr/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="userID,nUsuario,password,email")] ucr ucr)
        {
            if (ModelState.IsValid)
            {
                db.ucrs.Add(ucr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ucr);
        }

        // GET: /Ucr/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ucr ucr = db.ucrs.Find(id);
            if (ucr == null)
            {
                return HttpNotFound();
            }
            return View(ucr);
        }

        // POST: /Ucr/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="userID,nUsuario,password,email")] ucr ucr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ucr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ucr);
        }

        // GET: /Ucr/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ucr ucr = db.ucrs.Find(id);
            if (ucr == null)
            {
                return HttpNotFound();
            }
            return View(ucr);
        }

        // POST: /Ucr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ucr ucr = db.ucrs.Find(id);
            db.ucrs.Remove(ucr);
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
