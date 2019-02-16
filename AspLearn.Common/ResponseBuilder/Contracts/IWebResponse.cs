using System.Net;

namespace AspLearn.Common.ResponseBuilder.Contracts {
    public interface IWebResponse {
        object Body { get; set; }

        string Message { get; set; }

        HttpStatusCode StatusCode { get; set; }
    }
}
