namespace WebBanDienThoai.Models
{
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Product")]
    public partial class Product
    {
        private ShopMobileDbContext db = new ShopMobileDbContext();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Carts = new HashSet<Cart>();
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public IEnumerable<Product> ListProductPaging(int pageIndex, int pageSize)
        {
            return db.Products.OrderByDescending(x => x.CreatedAt).ToPagedList(pageIndex, pageSize);
        }
        public int ID { get; set; } 

        [StringLength(250)]
        public string Name { get; set; }

        public int CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public decimal? Price { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public int? Quantity { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
