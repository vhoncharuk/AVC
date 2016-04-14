using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVC.DB.Domain.Entities
{
    public class Category
    {
        public int Nidcategory { get; set; }

        public string Cnamecategory { get; set; }

        public virtual ICollection<Products> Products { get; set; }

        public Category()
        {
            Products = new List<Products>();
        }
    }
}
