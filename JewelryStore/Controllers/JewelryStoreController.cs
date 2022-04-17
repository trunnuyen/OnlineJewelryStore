using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JewelryStore.Models;

namespace JewelryStore.Controllers
{
    public class JewelryStoreController : Controller
    {
		JewelryStoreEntities data = new JewelryStoreEntities();
      
		public ActionResult Signout()
		{
			FormsAuthentication.SignOut();
			//Response.Cookies.Clear();
			Session.Clear();

			return RedirectToAction("Index", "JewelryStore");

		}
		public ActionResult Search()
		{

			//var model = data.Items.Where(nv => nv.Name.Contains(search) || search == null).ToList();
			//return View(model);
			return PartialView();

		}
		private List<Item> NewItem(int count)
		{
			return data.Item.Where(d => d.Active == true).OrderByDescending(a => a.DateImport).Take(count).ToList();
		}
		public ActionResult Index(/*FormCollection fc*/string search)
		{
			//var item = NewItem(8);
			//if (!String.IsNullOrEmpty(search)){
			//	item = item.Where(s => s.Name.Contains(search)).ToList();
			//}
			//return View(item);
			//-----------------------------------------------
			//string name = fc["txtname"];
			//if (!String.IsNullOrEmpty(name))
			//{
			//	var item = from t in data.Items select t;

			//	item = item.Where(s => s.Name.Contains(name));
			//	return View(item);
			//}
			//return View(NewItem(8));
			//var model = NewItem(8).Where(nv => nv.Name.Contains(search) || search == null).ToList();

			var model = data.Item.OrderByDescending(c => c.DateImport).Take(8).Where(nv => nv.Name.Contains(search) || search == null && nv.Active == true).ToList();

			return View(model);


		}
		public ActionResult Detail(int id)
		{
			var gear = from t in data.Item
					   where t.ID == id
					   select t;
			return View(gear.Single());
		}
		public ActionResult Menu()
		{
			var menu = from t in data.Menu select t;
			return PartialView(menu);
		}
		public ActionResult ItemMenuType(long id)
		{


			var b = (from t in data.ItemType where t.MenuID == id select t).ToList();

			return PartialView(b);
		}
		public ActionResult Brandtype(long id)
		{


			var c = (from d in data.Brand where d.MenuID == id select d).ToList();

			return PartialView(c);
		}
		public ActionResult ProductbyType(long id)
		{
			var pr = from d in data.Item where d.TypeID == id && d.Active == true select d;
			return View(pr);
		}
		public ActionResult BrandbyType(long id)
		{
			var pr = from d in data.Item where d.BrandID == id && d.Active == true select d;
			return View(pr);
		}
		public ActionResult Banner()
		{
			var bn = (from d in data.Banner select d).ToList();
			return PartialView(bn);
		}
		private List<Blogs> NewBlogs(int count)
		{
			return data.Blogs.OrderByDescending(a => a.DateImport).Take(count).ToList();
		}
		public ActionResult Blog()
		{

			return View(NewBlogs(5));
		}
		public ActionResult BlogDetail(long id)
		{

			var blog = from t in data.Blogs
					   where t.ID == id
					   select t;
			return View(blog.Single());
		}
		public ActionResult RecentBlog()
		{

			return PartialView(NewBlogs(4));
		}
		public ActionResult Relatedproducts(long id)
		{
			var i = (from t in data.Item where t.BrandID == id && t.Active == true select t).Take(5).ToList();

			return PartialView(i);
		}
		public ActionResult Newdproducts()
		{

			return PartialView(NewItem(5));
		}
		//public ActionResult Helmetss()
		//{

		//		long id = 1;


		//	var i = data.ItemTypes.Find(
		//	var listitem=data.ItemTypes.Where(a=>a.ID==id)
		//		var temp = db.Clients.Find(id);
		//		var listorder = db.Orders.Where(o => o.IDClient == id);
		//		var lissordetai = db.OrderDetails.Where(d => d.Order.IDClient == id);
		//		ViewBag.listorder = listorder;
		//		//ViewBag.lissordetai = lissordetai;
		//		return View(new ClientManagerEntity(temp));

		//}
		public ActionResult Rings()
		{
			long id = 2;
			var i = from t in data.Item
					join c in data.ItemType on t.TypeID equals c.ID
					//join d in data.Menus on c.MenuID equals d.ID
					where c.MenuID == id && t.Active == true
					select new { t, c };
			List<JewelryEntity> listhl = new List<JewelryEntity>();

			foreach (var info in i.ToList())
			{
                JewelryEntity hl = new JewelryEntity
                {
                    Name = info.t.Name,
                    Picture = info.t.Picture,
                    Quantity = info.t.Quantity,
                    Sellprice = info.t.SellPrice,
                    Status = info.t.ShortTitle,
                    Describe = info.t.Describe
                };
                listhl.Add(hl);
			}
			//long id = 2;
			//var temp = data.Menus.Find(id);
			//var a = data.ItemTypes.Where(b => b.MenuID == id);

			//var listorder = db.Orders.Where(o => o.IDClient == id);
			//var lissordetai = db.OrderDetails.Where(d => d.Order.IDClient == id);
			//ViewBag.listorder = listorder;
			////ViewBag.lissordetai = lissordetai;
			//return View(new ClientManagerEntity(temp));

			return View(listhl);
		}
		public ActionResult Bracelets()
		{
			long id = 3;
			var i = from t in data.Item
					join c in data.ItemType on t.TypeID equals c.ID

					where c.MenuID == id && t.Active == true
					select new { t, c };
			List<JewelryEntity> listhl = new List<JewelryEntity>();

			foreach (var info in i.ToList())
			{
				JewelryEntity hl = new JewelryEntity();
				hl.Name = info.t.Name;
				hl.Picture = info.t.Picture;
				hl.Quantity = info.t.Quantity;
				hl.Sellprice = info.t.SellPrice;
				hl.Status = info.t.ShortTitle;
				hl.Describe = info.t.Describe;
				listhl.Add(hl);
			}


			return View(listhl);
		}

		public ActionResult Necklaces()
		{
			long id = 4;
			var i = from t in data.Item
					join c in data.ItemType on t.TypeID equals c.ID

					where c.MenuID == id && t.Active == true
					select new { t, c };
			List<JewelryEntity> listhl = new List<JewelryEntity>();

			foreach (var info in i.ToList())
			{
				JewelryEntity hl = new JewelryEntity();
				hl.Name = info.t.Name;
				hl.Picture = info.t.Picture;
				hl.Quantity = info.t.Quantity;
				hl.Sellprice = info.t.SellPrice;
				hl.Status = info.t.ShortTitle;
				hl.Describe = info.t.Describe;
				listhl.Add(hl);
			}


			return View(listhl);
		}
		//public ActionResult DetailProduct(long? id)
		//{

		//	var temp = data.Items.Find(id);

		//	return View(new ItemEntity(temp));
		//}
		public ActionResult DetailProduct(long id)
		{


			var i = from t in data.Item
					join c in data.ItemType on t.TypeID equals c.ID

					where t.ID.Equals(id)
					select t;
			List<JewelryEntity> listhl = new List<JewelryEntity>();

			foreach (var info in i)
			{
				JewelryEntity hl = new JewelryEntity();
				//var a = from t in data.Items where t.ID == hl.ID;
				hl.Name = info.Name;
				hl.Picture = info.Picture;
				hl.Quantity = info.Quantity;
				hl.Sellprice = info.SellPrice;
				hl.Status = info.ShortTitle;
				hl.Describe = info.Describe;
				listhl.Add(hl);
			}


			return View(listhl);

		}
		public ActionResult Brand()
		{

			var i = from t in data.Brand select t;


			return View(i.ToList());
		}
		public ActionResult Contact()
		{
			return View();
		}
		public ActionResult Sessionlogin()
		{
			return PartialView();
		}
		public ActionResult ListOrderClient()
		{
			var ac = (Customer)Session["usr"];
			if (ac == null)
			{
				return RedirectToAction("Login", "Acction");
			}

			var temp = data.Order.Where(p => p.Customer.Username == ac.Username);
			List<OrderEntity> listProdcut = new List<OrderEntity>();
			foreach (var item in temp)
			{
				OrderEntity pr = new OrderEntity();
				pr.TypeOf_OrderEntity(item);
				listProdcut.Add(pr);
			}


			return View(listProdcut);


		}
		public ActionResult ListOrderDetailClient(long? id)
		{
			var temp = data.OrderDetail.Where(d => d.OrderID == id);
			List<OrderDetailEntity> listdetail = new List<OrderDetailEntity>();
			foreach (var item in temp)
			{
				OrderDetailEntity or = new OrderDetailEntity();
				or.TypeOf_OrderEntity(item);
				listdetail.Add(or);
			}


			return PartialView(listdetail);

		}
		public ActionResult CancelOrder(long? id)
		{
			var temp = data.OrderDetail.Where(d => d.OrderID == id);
			List<OrderDetailEntity> listdetail = new List<OrderDetailEntity>();
			foreach (var item in temp)
			{
				OrderDetailEntity or = new OrderDetailEntity();
				or.TypeOf_OrderEntity(item);
				listdetail.Add(or);
			}
			ViewBag.Date = data.Order.SingleOrDefault(a => a.ID == id).Deliverydate;
			ViewBag.id = id;
			return View(listdetail);

		}
		[HttpPost]

		public ActionResult CancelOrder(FormCollection fc)
		{

			long id = Convert.ToInt64(fc["id"]);
			var tem = data.Order.SingleOrDefault(d => d.ID == id);

			tem.Deliverystatus = false;

			data.SaveChanges();


			return RedirectToAction("ListOrderClient");

		}
		public new ActionResult Profile()
		{
			var ac = (Customer)Session["usr"];


			var t = from a in data.Customer where a.Username == ac.Username select a;


			return View(t.ToList());


		}
    }
}