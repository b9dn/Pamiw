using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Shop
{
    public class FilmDetails
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public string Manufactuer { get; set; }

        public DateTime ManufactureDate { get; set; }
    }
}
