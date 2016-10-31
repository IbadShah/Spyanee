using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class SaleInvoice
    {
        public int SaleInvoiceId { get; set; }
        public string SaleInvoiceCode { get; set; }
        public int CustomerId { get; set; }
        public int CatId { get; set; }
        public int SubCatId { get; set; }
        public int UnitId { get; set; }
        public int PackingId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitRate { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountRecieved { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

    }
}
