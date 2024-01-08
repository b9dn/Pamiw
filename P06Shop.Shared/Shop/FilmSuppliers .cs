using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Shop
{
    public class FilmSuppliers
    {
      
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
