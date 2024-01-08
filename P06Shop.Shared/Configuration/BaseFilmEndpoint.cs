using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Configuration
{
    public class BaseFilmEndpoint
    {
        public string Base_url { get; set; }
        public string GetAllFilmsEndpoint { get; set; }
        public string SearchFilmsEndpoint { get; set; }

        
    }
}
