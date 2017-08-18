using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Project.Models
{
    public class ApprovalStatusViewModel
    {
        public List<Volunteer> volunteer;
        public SelectList status;
        public string ApprovalStatus { get; set; }
    }
}