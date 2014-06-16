using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrencyUtility
{
 public class SiteUser
    {

        public string IP { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string PostalCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

    }
}
