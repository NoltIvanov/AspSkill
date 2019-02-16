using AspLearn.Common.ResponseBuilder.Contracts;
using System.Net;

namespace AspLearn.Common.ResponseBuilder {
    public class WebResponse : IWebResponse {
        public object Body { get; set; }

        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
