using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRNAssigment.Models
{   //quantity,TotalPrice,dateIn: DataTime?,cateID
    public class Product
    {
        [Required]
        [Key]
        public int ProductID { get; set; }

        [MaxLength(50)]
        public String ProductName { get; set; }

        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public DateTime DateIn { get; set; }

        [ForeignKey("SuppID")]
        public int SupplierID { get; set; }

        public virtual Supplier SuppID { get; set; }

    }
}
