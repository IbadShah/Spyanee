using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab.Models
{
    public class Categories
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
