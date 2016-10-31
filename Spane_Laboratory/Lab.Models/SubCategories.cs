using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class SubCategories
    {
        public int SubCatId { get; set; }
        public string Item { get; set; }
        public decimal Quantity { get; set; }
        public string Units { get; set; }
        public decimal UnitRate { get; set; }
        public decimal Amount { get; set; }
        public int CatId { get; set; }

    }
}
