using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNet6Vjezba.Models;

namespace ASPNet6Vjezba.Controllers
{
    public class TrucksController : Controller
    {
        private TruckContext db = new TruckContext();

        // GET: Trucks
        public ActionResult Index(string search, float? consumptionfrom,float? consumptionto,bool? available,
           int? traveledkilometersfrom,int? traveledkilometersto,int? capacityfrom,int? capacityto,float? heightfrom,
           float? heightto)
        {
            var list = db.Trucks.ToList();
            if (string.IsNullOrEmpty(search) == false) {

                list = list.Where(x => x.Brand.ToLower().StartsWith(search.ToLower())).ToList();
            }
            if (consumptionfrom != null) {

                list = list.Where(x => x.Consumption >= consumptionfrom).ToList();
            }
            if (consumptionto != null) {
                list = list.Where(x => x.Consumption <= consumptionto).ToList();
            }
            if (available != null) {
                list = list.Where(x => x.Available == true).ToList();

            }
            if (traveledkilometersfrom != null) {

                list = list.Where(x => x.TraveledKilometers >= traveledkilometersfrom).ToList();
            }
            if (traveledkilometersto != null) {

                list = list.Where(x => x.TraveledKilometers <= traveledkilometersto).ToList();
            }
            if (capacityfrom != null) {
                list = list.Where(x => x.Capacity >= capacityfrom).ToList();
            }
            if (capacityto != null) {

                list = list.Where(x => x.Capacity <= capacityto).ToList();
            }
            if (heightfrom != null) {
                list = list.Where(x => x.Height >= heightfrom).ToList();
            }
            if (heightto != null) {
                list = list.Where(x => x.Height <= heightto).ToList();
            }
            float MaxPotrosnja = list.Max(t => t.Consumption);
            ViewBag.potrosnja = MaxPotrosnja;
            int UkupnoPrjedjeno = list.Sum(t => t.TraveledKilometers);
            ViewBag.ukupnokm = UkupnoPrjedjeno;
            return View(list);
        }

        // GET: Trucks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truck truck = db.Trucks.Find(id);
            if (truck == null)
            {
                return HttpNotFound();
            }
            return View(truck);
        }

        // GET: Trucks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trucks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Brand,Consumption,Available,TraveledKilometers,Capacity,Height")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                db.Trucks.Add(truck);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(truck);
        }

        // GET: Trucks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truck truck = db.Trucks.Find(id);
            if (truck == null)
            {
                return HttpNotFound();
            }
            return View(truck);
        }

        // POST: Trucks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Brand,Consumption,Available,TraveledKilometers,Capacity,Height")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                db.Entry(truck).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(truck);
        }

        // GET: Trucks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truck truck = db.Trucks.Find(id);
            if (truck == null)
            {
                return HttpNotFound();
            }
            return View(truck);
        }

        // POST: Trucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Truck truck = db.Trucks.Find(id);
            db.Trucks.Remove(truck);
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
