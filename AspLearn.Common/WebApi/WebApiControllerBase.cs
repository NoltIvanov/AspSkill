using AspLearn.Common.ResponseBuilder.Contracts;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Linq;
using System.Net;

namespace AspLearn.Common.WebApi {
    public abstract class WebApiControllerBase : Controller {
        private readonly IResponseFactory _responseFactory;

        private Guid? _userNetId {
            get {
                if (User.Claims.FirstOrDefault(c => c.Type.Equals("NetId")) != null) {
                    return Guid.Parse(User.Claims.FirstOrDefault(c => c.Type.Equals("NetId")).Value);
                } else {
                    return null;
                }
            }
        }

        /// <summary>
        ///     Nlogger
        /// </summary>
        protected Logger Logger { get; }

        protected Guid? UserNetId => _userNetId;

        /// <summary>
        ///     ctor().
        /// </summary>
        protected WebApiControllerBase(IResponseFactory responseFactory) {
            Logger = NLog.LogManager.GetCurrentClassLogger();

            _responseFactory = responseFactory;
        }

        protected IWebResponse SuccessResponseBody(object body, string message = "") {
            IWebResponse response = _responseFactory.GetResponse();
            response.Body = body;
            response.StatusCode = HttpStatusCode.OK;
            response.Message = message;

            return response;
        }

        protected IWebResponse ErrorResponseBody(string message, HttpStatusCode statusCode) {
            IWebResponse response = _responseFactory.GetResponse();
            response.Message = message;
            response.StatusCode = statusCode;

            return response;
        }
    }
}
