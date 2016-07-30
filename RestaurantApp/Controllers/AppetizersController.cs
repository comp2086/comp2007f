using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantApp.Models;

namespace RestaurantApp.Controllers
{
    public class AppetizersController : Controller
    {
        private RestaurantContext db = new RestaurantContext();

        // GET: Appetizers
        public async Task<ActionResult> Index()
        {
            // ViewBag.Appetizers = db.Appetizers.ToListAsync();

            //return View("~/Views/Appetizers/UserIndex.cshtml");
            return View("~/Views/Appetizers/UserIndex.cshtml", await db.Appetizers.ToListAsync());
            //return View(await db.Appetizers.ToListAsync());
        }

        // GET: Appetizers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appetizer appetizer = await db.Appetizers.FindAsync(id);
            if (appetizer == null)
            {
                return HttpNotFound();
            }
            return View(appetizer);
        }

        // GET: Appetizers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appetizers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AppetizerId,Name,ThumbNail,FullImage,ShortDesc,FullDesc,Price")] Appetizer appetizer)
        {
            if (ModelState.IsValid)
            {
                db.Appetizers.Add(appetizer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(appetizer);
        }

        // GET: Appetizers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appetizer appetizer = await db.Appetizers.FindAsync(id);
            if (appetizer == null)
            {
                return HttpNotFound();
            }
            return View(appetizer);
        }

        // POST: Appetizers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AppetizerId,Name,ThumbNail,FullImage,ShortDesc,FullDesc,Price")] Appetizer appetizer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appetizer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(appetizer);
        }

        // GET: Appetizers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appetizer appetizer = await db.Appetizers.FindAsync(id);
            if (appetizer == null)
            {
                return HttpNotFound();
            }
            return View(appetizer);
        }

        // POST: Appetizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Appetizer appetizer = await db.Appetizers.FindAsync(id);
            db.Appetizers.Remove(appetizer);
            await db.SaveChangesAsync();
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
