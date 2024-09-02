using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ContactAppMVCApp.Models
{
    public class ContactDetail
    {
        public int ContactDetailId { get; set; }

        [DisplayName("Type(Number/Email)")]
        public string Type { get; set; }

        public string Value { get; set; }
    }
}