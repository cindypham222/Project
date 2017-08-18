using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Project.Models;

namespace Project.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project.Models.Availability", b =>
                {
                    b.Property<int>("AvailabilityID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Friday");

                    b.Property<string>("Monday");

                    b.Property<string>("Saturday");

                    b.Property<string>("Sunday");

                    b.Property<string>("Thursday");

                    b.Property<string>("Tuesday");

                    b.Property<int?>("VolunteerID");

                    b.Property<string>("Wednesday");

                    b.HasKey("AvailabilityID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("Project.Models.Center", b =>
                {
                    b.Property<int>("CenterID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("ContactNumber");

                    b.Property<string>("Name");

                    b.HasKey("CenterID");

                    b.ToTable("Center");
                });

            modelBuilder.Entity("Project.Models.EmergencyContact", b =>
                {
                    b.Property<int>("EmergencyContactID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<int?>("VolunteerID");

                    b.HasKey("EmergencyContactID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("EmergencyContact");
                });

            modelBuilder.Entity("Project.Models.Interest", b =>
                {
                    b.Property<int>("InterestID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("VolunteerID");

                    b.HasKey("InterestID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("Project.Models.License", b =>
                {
                    b.Property<int>("LicenseID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExpirationDate");

                    b.Property<string>("Name");

                    b.Property<int?>("VolunteerID");

                    b.HasKey("LicenseID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("License");
                });

            modelBuilder.Entity("Project.Models.Opportunity", b =>
                {
                    b.Property<int>("OpportunityID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CenterID");

                    b.Property<int>("Date");

                    b.Property<string>("Name");

                    b.HasKey("OpportunityID");

                    b.HasIndex("CenterID");

                    b.ToTable("Opportunity");
                });

            modelBuilder.Entity("Project.Models.Skill", b =>
                {
                    b.Property<int>("SkillID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("VolunteerID");

                    b.HasKey("SkillID");

                    b.HasIndex("VolunteerID");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("Project.Models.Volunteer", b =>
                {
                    b.Property<int>("VolunteerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("ApprovalStatus");

                    b.Property<string>("Availability");

                    b.Property<string>("DriverLicense");

                    b.Property<string>("Education");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("PhoneNumber");

                    b.Property<string>("SocialSecurity");

                    b.Property<string>("UserName");

                    b.HasKey("VolunteerID");

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("Project.Models.Availability", b =>
                {
                    b.HasOne("Project.Models.Volunteer", "Volunteer")
                        .WithMany("Availabilties")
                        .HasForeignKey("VolunteerID");
                });

            modelBuilder.Entity("Project.Models.EmergencyContact", b =>
                {
                    b.HasOne("Project.Models.Volunteer", "Volunteer")
                        .WithMany("EmergencyContacts")
                        .HasForeignKey("VolunteerID");
                });

            modelBuilder.Entity("Project.Models.Interest", b =>
                {
                    b.HasOne("Project.Models.Volunteer", "Volunteer")
                        .WithMany("Interests")
                        .HasForeignKey("VolunteerID");
                });

            modelBuilder.Entity("Project.Models.License", b =>
                {
                    b.HasOne("Project.Models.Volunteer", "Volunteer")
                        .WithMany("Licenses")
                        .HasForeignKey("VolunteerID");
                });

            modelBuilder.Entity("Project.Models.Opportunity", b =>
                {
                    b.HasOne("Project.Models.Center", "Center")
                        .WithMany("Opportunities")
                        .HasForeignKey("CenterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Project.Models.Skill", b =>
                {
                    b.HasOne("Project.Models.Volunteer", "Volunteer")
                        .WithMany("Skills")
                        .HasForeignKey("VolunteerID");
                });
        }
    }
}
