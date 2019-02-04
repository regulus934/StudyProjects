using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.InventoryDb;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class InstrumentsController : Controller
    {
        private InventoryContext db = new InventoryContext();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Report (DateTime Month)
        {      
         var reports = db.Database.SqlQuery<Report>("select Instruments.Name, SUM (Instruments.Kolvo) as 'Kolvo' from Instruments join Requests on Instruments.RequestId_id = Requests.id where MONTH(Requests.month) = @id group by Instruments.Name", new SqlParameter("@id", Month.Month)).ToList();
        
             ViewBag.Month = Month.ToString("MMMM");

            return View(reports);
        }

        public ActionResult Invent(int? id)
        {
            ViewBag.id = id;
            if (db.Request.Find(id) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }
            return View(db.Request.Find(id).Instruments.ToList());
        }
        public ActionResult Index()
        {
            return View(db.Instruments.ToList());
        }
        // GET: Instruments1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // GET: Instruments1/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ReportForm()
        {
            return View();
        }

        // POST: Instruments1/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstrumentID,Name,Kolvo,Comments")] Instrument instrument, int? id)
        {
            if (ModelState.IsValid)
            {
                if (db.Request.Find(id) == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                instrument.RequestId = db.Request.Find(id);
                db.Instruments.Add(instrument);
                db.SaveChanges();
                return Redirect("/Instruments/Invent/"+id);
            }

            return Redirect("/Instruments/Invent/" + id);
        }

        // GET: Instruments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // POST: Instruments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstrumentID,Name,Kolvo,Comments")] Instrument instrument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instrument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instrument);
        }

        // GET: Instruments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            return View(instrument);
        }

        // POST: Instruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instrument instrument = db.Instruments.Find(id);
            db.Instruments.Remove(instrument);
            db.SaveChanges();
            return Redirect("/Requests/Index");
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
