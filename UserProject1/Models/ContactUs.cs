using System;
using System.Collections.Generic;

namespace UserProject1.Models
{
    public partial class ContactUs
    {
        public int ContactUsId { get; set; }
        public string UserName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
}
