using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CalendarEvents.Factory;
using CalendarEvents.Models;
using System.Globalization;
using System.Net.Http;
using System.Net;

namespace CalendarEvents.Controllers
{
    public class CalendarController : ApiController
    {
        [System.Web.Http.HttpGet]
        public IEnumerable<Entry> Entries(string startTime=null, string endTime=null)
        {
            DateTime _startTime, _endTime;

            if(startTime==null|| endTime ==null )
            {
                return CalendarFactory.GetCalendar().Entries;
            }
            var utcDateStart = DateTime.UtcNow.ToString(startTime, CultureInfo.InvariantCulture);
            var utcDateEnd = DateTime.UtcNow.ToString(endTime, CultureInfo.InvariantCulture);

            if (!DateTime.TryParseExact(utcDateStart, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out _startTime) ||
                !DateTime.TryParseExact(utcDateEnd, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out _endTime))
            {
                return CalendarFactory.GetCalendar().Entries;

            }

            return CalendarFactory.GetCalendar().Entries.Where(e => (e.StartTime.Value.Date >= _startTime.Date && e.StartTime.Value.Date <= _endTime.Date));
        }


        public HttpResponseMessage Create([FromBody] Entry entryModel)
        {
            if(entryModel == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new Exception("Please enter valid fields"));
            }
            CalendarFactory.GetCalendar().Entries.Add(entryModel);
            return Request.CreateResponse(HttpStatusCode.Created, entryModel);
        }

        public HttpResponseMessage Update(int id, Entry entry)
        {
            //TODO
            return Request.CreateResponse(HttpStatusCode.OK, entry);
        }

        public HttpResponseMessage Delete(int id)
        {
            Entry entry=null ;
            try
            {
                CalendarFactory.GetCalendar().Entries.First(i=>i.ID==id);
            }
            catch(Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            CalendarFactory.GetCalendar().Entries.Remove(entry);
            return Request.CreateResponse(HttpStatusCode.Created, entry);
        }
    }
}
//{
//  "StartTime": "2016-10-25",
//  "EndTime":"2014-10-26",
//   "LocationUrl" : "www.china.com"
//}

//{
//  "StartTime": "2014-10-25",
//  "EndTime":"2014-10-26",
//   "LocationUrl" : "www.china.com"
//}