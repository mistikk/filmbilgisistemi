using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilmSistemi.Models;
using System.IO;
using FilmSistemi.Areas.Admin.Models;

namespace FilmSistemi.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        private FilmSistemiEntities db = new FilmSistemiEntities();

        // GET: Admin/Slider
        public ActionResult Index()
        {
            return View(db.Simage.ToList());
        }

        // GET: Admin/Slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Simage simage = db.Simage.Find(id);
            if (simage == null)
            {
                return HttpNotFound();
            }
            return View(simage);
        }

        // GET: Admin/Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        const string imageWay = "~/Content/slider";
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SliderModel model)
        {
            if (ModelState.IsValid)
            {
                string fileN = string.Empty;
                if (model.İmage != null)
                {
                    fileN = model.İmage.FileName;
                    var way =Path.Combine( Server.MapPath(imageWay), fileN);
                    model.İmage.SaveAs(way);
                    
                }
                

                Simage slider = new Simage();
            
                slider.MovieId = model.MovieId;
                slider.İmage = fileN;
                db.Simage.Add(slider);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Admin/Slider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Simage simage = db.Simage.Find(id);
            if (simage == null)
            {
                return HttpNotFound();
            }
            return View(simage);
        }

        // POST: Admin/Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sid,İmage,MovieId")] Simage simage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(simage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(simage);
        }

        // GET: Admin/Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Simage simage = db.Simage.Find(id);
            if (simage == null)
            {
                return HttpNotFound();
            }
            return View(simage);
        }

        // POST: Admin/Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Simage simage = db.Simage.Find(id);
            db.Simage.Remove(simage);
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
