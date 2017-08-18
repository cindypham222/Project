using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Skill

    {

        public int SkillID { get; set; }

        public string Name { get; set; }

        public Volunteer Volunteer { get; set; }

    }

}