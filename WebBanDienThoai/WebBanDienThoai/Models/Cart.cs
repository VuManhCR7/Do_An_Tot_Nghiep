namespace WebBanDienThoai.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    [Serializable]
    public partial class Cart
    {
        public int ID { get; set; }

        public int? ProductID { get; set; }

        public int? Quantity { get; set; }

        public DateTime? CreatedAt { get; set; }

        public virtual Product Product { get; set; }
    }
}
