using System;
using System.Linq;

namespace JewelryStore.Models
{
	public class CartEntity
	{
		JewelryStoreEntities data = new JewelryStoreEntities();
		public long IdItem { set; get; }
		public string Name { set; get; }
		public string Picture { set; get; }
		public Double Prices { set; get; }
		public int Quantity { set; get; }
		public Double TotalPrices
		{
			get { return Quantity * Prices; }
		}
		public CartEntity(long id)
		{
			IdItem = id;
			Item product = data.Item.Single(n => n.ID == IdItem);
			Name = product.Name;
			Picture = product.Picture;
			Prices = Double.Parse(product.SellPrice.ToString());
			Quantity = 1;
		}
	}
}