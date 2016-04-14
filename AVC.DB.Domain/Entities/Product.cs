using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVC.DB.Domain.Entities
{
    public class Products
    {
        public int Nidproduct { get; set; }
        public string Cname { get; set; }
        public string Ncode { get; set; }
        public string Carticul { get; set; }
        public int Nexist { get; set; }
        public decimal Nprice_d { get; set; }
        public decimal Nprice_u { get; set; }
        public int Ngaranty { get; set; }
        public int Nid_category { get; set; }
        public string Vendor { get; set; }
        public string Model { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public DateTime Ddateupdate { get; set; }
        public virtual Category Category { get; set; }

    }
}
