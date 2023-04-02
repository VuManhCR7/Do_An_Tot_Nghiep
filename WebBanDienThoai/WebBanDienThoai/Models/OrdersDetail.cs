namespace WebBanDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdersDetail")]
    public partial class OrdersDetail
    {
        ShopMobileDbContext db = null;
        public OrdersDetail()
        {
            db = new ShopMobileDbContext();
        }

        public bool Insert(OrdersDetail detail)
        {
            try
            {
                db.OrdersDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int ID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int? Quantity { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
