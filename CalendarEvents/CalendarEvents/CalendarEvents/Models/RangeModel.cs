using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalendarEvents.Models
{
    public class RangeModel
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        //public RangeModel(string startTime, string endTime)
        //{
        //    StartTime = DateTime.Parse(startTime);
        //}
    }
}