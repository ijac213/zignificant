using System;
using System.Collections.Generic;
using System.Text;
using Zignificant.Models.Requests;

namespace Zignificant.Models.Responses
{
    public class BirthdateResponse : BirthdateUpdateRequest
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
