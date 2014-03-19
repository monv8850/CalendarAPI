using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarEvents.Models
{
    public class Entry
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string LocationUrl { get; set; }

        public int ID { get; set; }
    }
}