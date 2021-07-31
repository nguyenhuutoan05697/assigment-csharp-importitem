using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRNAssigment.Models
{
    public class Supplier
    {
        [Required]
        [Key]
        public int SupplierID { get; set; }

        [MaxLength(50)]
        public String SupplierName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
