using System;
using System.Collections.Generic;
using System.Text;

namespace Zignificant.Models.Requests
{
    public class HistoryCreateRequest
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
