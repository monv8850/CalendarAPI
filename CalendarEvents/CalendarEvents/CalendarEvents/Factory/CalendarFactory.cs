using CalendarEvents.Models;

namespace CalendarEvents.Factory
{

    public static class CalendarFactory
    {
        private  static Calendar calendar;
        public static Calendar GetCalendar()
        {
            if(calendar == null)
            {
                 calendar = new Calendar();
            }
            return calendar;
        }

    }
}