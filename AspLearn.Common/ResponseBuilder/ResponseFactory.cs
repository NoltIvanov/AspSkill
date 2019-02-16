using AspLearn.Common.ResponseBuilder.Contracts;

namespace AspLearn.Common.ResponseBuilder {
    public class ResponseFactory : IResponseFactory {
        public IWebResponse GetResponse() => new WebResponse();
    }
}
