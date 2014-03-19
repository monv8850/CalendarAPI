using System;
using System.Collections.Generic;

namespace CalendarEvents.Models
{
    public class Calendar
    {
        public List<Entry> Entries { get; set; }
        public Calendar()
        {
            Entries=new List<Entry>();
            Entries.Add(new Entry
            {
                StartTime = DateTime.Parse("25/10/1990"),
                EndTime = DateTime.Parse("25/10/1991"),
                LocationUrl = "Nigeria"
            });

            Entries.Add(new Entry
            {
                StartTime = DateTime.Parse("1/1/2014"),
                EndTime = DateTime.Parse("1/10/2025"),
                LocationUrl = "Crimea"
            });

            Entries.Add(new Entry
            {
                StartTime = DateTime.Parse("1/1/2026").AddDays(18),
                EndTime =DateTime.Now.AddDays(106),
                LocationUrl = "Moscow"
            });
        }
    }
}