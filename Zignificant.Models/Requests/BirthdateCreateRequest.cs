using System;
using System.Collections.Generic;
using System.Text;

namespace Zignificant.Models.Requests
{
    public class BirthdateCreateRequest
    {
        public string FullName { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? Dod { get; set; }
        public string Notoriety { get; set; }
    }
}
