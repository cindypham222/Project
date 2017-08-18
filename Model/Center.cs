using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Center

    {

        public int CenterID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int ContactNumber { get; set; }

        public ICollection<Opportunity> Opportunities { get; set; }

    }

}
