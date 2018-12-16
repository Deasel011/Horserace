using System.Net;

namespace HorseRace14.Shit
{
    public class ApiClientResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T Content { get; set; }
        public string Message { get; set; }
    }
}
