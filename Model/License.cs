using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class License

    {

        public int LicenseID { get; set; }

        public string Name { get; set; }

        public int ExpirationDate { get; set; }

        public Volunteer Volunteer { get; set; }

    }

}