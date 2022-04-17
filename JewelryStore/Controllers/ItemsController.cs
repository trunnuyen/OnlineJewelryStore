﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JewelryStore.Models;

namespace JewelryStore.Controllers
{
    public class ItemsController : Controller
    {
        private JewelryStoreEntities db = new JewelryStoreEntities();

        // GET: Items
        public ActionResult Index()
        {
			//var ac = (Admin)Session["Account"];
			//if (ac == null)
			//{
			//	return RedirectToAction("Login", "Admin");
			//}
			var items = db.Item.Include(i => i.Brand).Include(i => i.ItemType).Where(a=>a.Active==true);
            return View(items.ToList());
        }
		public ActionResult Itemunactive()
		{
			//var ac = (Admin)Session["Account"];
			//if (ac == null)
			//{
			//	return RedirectToAction("Login", "Admin");
			//}
			var items = db.Item.Include(i => i.Brand).Include(i => i.ItemType).Where(a => a.Active == false);
			return View(items.ToList());
		}
		// GET: Items/Details/5
		public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brand, "ID", "Name");
            ViewBag.TypeID = new SelectList(db.ItemType, "ID", "TypeName");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create([Bind(Include = "ID,Name,PurcharsePrice,SellPrice,Quantity,TypeID,BrandID,Picture,ShortTitle,Describe")] Item item)
        {
            if (ModelState.IsValid)
            {
				item.DateImport = DateTime.Now;
				item.Active = true;
                db.Item.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brand, "ID", "Name", item.BrandID);
            ViewBag.TypeID = new SelectList(db.ItemType, "ID", "TypeName", item.TypeID);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.Brand, "ID", "Name", item.BrandID);
            ViewBag.TypeID = new SelectList(db.ItemType, "ID", "TypeName", item.TypeID);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit([Bind(Include = "ID,Name,PurcharsePrice,SellPrice,DateImport,Quantity,TypeID,BrandID,Picture,ShortTitle,Describe")] Item item)
        {
            if (ModelState.IsValid)
            {
				
				ViewBag.BrandID = new SelectList(db.Brand, "ID", "Name", item.BrandID);
				db.Entry(item).State = EntityState.Modified;
				item.Active = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brand, "ID", "Name", item.BrandID);
            ViewBag.TypeID = new SelectList(db.ItemType, "ID", "TypeName", item.TypeID);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Item item = db.Item.Find(id);
            db.Item.Remove(item);
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
		//public ActionResult ActiveEmployee(long? id)
		//{
		//	if (id == null)
		//	{
		//		return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		//	}
		//	Item item = db.Items.Find(id);
		//	if (item==null)
		//	{
		//		return HttpNotFound();
		//	}
		//	else
		//	{
		//		return RedirectToAction("Login", "Admin");
		//	}


		//}
		//[HttpPost]
		//public ActionResult ActiveEmployee(Item item)
		//{
		//	var temp = db.Items.Find(item.ID);

		//	temp.Active = false;
		//	db.SaveChanges();

		//	return RedirectToAction("Index");


		//}
		public ActionResult UnactiveProduct(long? id)
		{
		
			var temp = db.Item.SingleOrDefault(p => p.ID == id);
			temp.Active = false;
			db.SaveChanges();

			return RedirectToAction("Index");
		}
		public ActionResult Active(long? id)
		{

			var temp = db.Item.SingleOrDefault(p => p.ID == id);
			temp.Active = true;
			db.SaveChanges();

			return RedirectToAction("Itemunactive");
		}
	}
}