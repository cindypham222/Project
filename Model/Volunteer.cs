using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Volunteer

    {

        public int VolunteerID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string UserName { get; set; }

        public string Availability { get; set; }

        public string Address { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Education { get; set; }

        public string DriverLicense { get; set; }

        public string SocialSecurity { get; set; }

        public string ApprovalStatus { get; set; }

        public ICollection<EmergencyContact> EmergencyContacts { get; set; }
        public ICollection<License> Licenses { get; set; }

        public ICollection<Skill> Skills { get; set; }

        public ICollection<Interest> Interests { get; set; }

        public ICollection<Availability> Availabilties { get; set; }

    }

}