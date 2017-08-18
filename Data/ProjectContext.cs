using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext (DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Project.Models.Availability> Availability { get; set; }

        public DbSet<Project.Models.Center> Center { get; set; }

        public DbSet<Project.Models.EmergencyContact> EmergencyContact { get; set; }

        public DbSet<Project.Models.Interest> Interest { get; set; }

        public DbSet<Project.Models.License> License { get; set; }

        public DbSet<Project.Models.Opportunity> Opportunity { get; set; }

        public DbSet<Project.Models.Skill> Skill { get; set; }

        public DbSet<Project.Models.Volunteer> Volunteer { get; set; }
    }
}
