using AspLearn.Common.ResponseBuilder.Contracts;
using AspLearn.Common.ResponseBuilder.Messages;
using AspLearn.Common.WebApi;
using AspLearn.Data;
using AspLearn.Data.Models;
using AspLearn.Data.Models.RuleTypes;
using AspLearn.Services.Cities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspLearn.Controllers {
    [Route("api/cities")]
    public class CitiesController : WebApiControllerBase {

        private readonly ICityService _cityService;

        /// <summary>
        ///     ctor().
        /// </summary>
        /// <param name="responseFactory"></param>
        public CitiesController(IResponseFactory responseFactory, ICityService cityService) : base(responseFactory) {
            _cityService = cityService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCities() {
            try {
                var result = await _cityService.GetAllCitiesAsync();
                if (result == null) {
                    return BadRequest(ErrorResponseBody(WebResponseMessages.ERROR_NOT_FOUND, HttpStatusCode.NotFound));
                } else {
                    return Ok(SuccessResponseBody(result));
                }
            }
            catch (Exception ex) {
                return BadRequest(ErrorResponseBody(ex.Message, HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("{netId}")]
        public async Task<IActionResult> GetCity([FromRoute] string netId) {
            try {
                var result = await _cityService.GetCityByNetIdAsync(Guid.Parse(netId));
                if (result == null) {
                    return BadRequest(ErrorResponseBody(WebResponseMessages.ERROR_NOT_FOUND, HttpStatusCode.NotFound));
                } else {
                    return Ok(result);
                }
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }    
    }
}
