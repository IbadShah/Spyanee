using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public long Password { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    

    }
}
