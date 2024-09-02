using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ContactAppMVCApp.Models
{
    public class User
    {
        public int UserId { get; set; }

        [DisplayName("First Name")]
        public string FName { get; set; }

        [DisplayName("Last Name")]
        public string LName { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; } = true;

        public List<Contact> contacts { get; set; } = new List<Contact>();
    }
}