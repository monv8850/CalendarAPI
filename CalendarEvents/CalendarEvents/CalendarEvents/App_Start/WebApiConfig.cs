using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace CalendarEvents
{
    public class JsonContentNegotiator : IContentNegotiator
{
    private readonly JsonMediaTypeFormatter _jsonFormatter;

    public JsonContentNegotiator(JsonMediaTypeFormatter formatter) 
    {
        _jsonFormatter = formatter;    
    }

    public ContentNegotiationResult Negotiate(
            Type type, 
            HttpRequestMessage request, 
            IEnumerable<MediaTypeFormatter> formatters)
    {
        return new ContentNegotiationResult(
            _jsonFormatter, 
            new MediaTypeHeaderValue("application/json"));
    }
}
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var jsonFormatter = new JsonMediaTypeFormatter();
            //optional: set serializer settings here
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}"
            );

            config.Routes.MapHttpRoute(
             name: "CreateEntry",
             routeTemplate: "api/Calendar/Entry/Create",
             defaults: new { controller="Calendar", action="Create"}
            );
        }
    }
}
