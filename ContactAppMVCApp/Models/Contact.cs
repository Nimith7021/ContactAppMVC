using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ContactAppMVCApp.Models
{
    public class Contact
    {
        public int ContactID { get; set; }

        [DisplayName("First Name")]
        public string FName { get; set; }

        [DisplayName("Last Name")]
        public string LName { get; set; }
        public bool IsActive { get; set; } = true;

        public List<ContactDetail> Details { get; set; } = new List<ContactDetail>();
    }
}