using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class SaleOrder
    {
        public int SaleOrderId { get; set; }
        public string SaleOrderCode { get; set; }
        public string CustomerName { get; set; }
        public string CatName { get; set; }
        public string SubCatName { get; set; }
        public string UnitName { get; set; }
        public string PackingName { get; set; }
        public string ClassName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitRate { get; set; }
        public decimal Discount { get; set; }
        public decimal SalePercentage { get; set; }
        public decimal SaleRate { get; set; }
        public decimal AmountRecieved { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

    }
}
