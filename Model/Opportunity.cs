using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Opportunity

    {

        public int OpportunityID { get; set; }

        public int CenterID { get; set; }

        public string Name { get; set; }

        public int Date { get; set; }

        public Center Center { get; set; }

    }

}