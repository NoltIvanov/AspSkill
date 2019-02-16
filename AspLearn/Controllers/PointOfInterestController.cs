using AspLearn.Common.ResponseBuilder.Contracts;
using AspLearn.Common.ResponseBuilder.Messages;
using AspLearn.Common.WebApi;
using AspLearn.Data;
using AspLearn.Data.Models;
using AspLearn.Data.Models.RuleTypes;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspLearn.Controllers {
    [Route("api/cities")]
    public class PointOfInterestController : WebApiControllerBase {

        public PointOfInterestController(IResponseFactory responseFactory) : base(responseFactory) {

        }

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterestByCityId(int cityId) {
            try {
                //var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
                //if (city == null) {
                //    return BadRequest(ErrorResponseBody(WebResponseMessages.ERROR_NOT_FOUND, HttpStatusCode.BadRequest));
                //} else {
                //    return Ok(SuccessResponseBody(city.PointsOfInterest, "Awesome"));
                //}
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ErrorResponseBody(ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpGet("{cityId}/pointsofinterest/{id}", Name = "GetPointOfInterestById")]
        public IActionResult GetPointOfInterestById(int cityId, int id) {
            try {
                //var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
                //if (city == null) {
                //    return BadRequest(ErrorResponseBody(WebResponseMessages.ERROR_NOT_FOUND, HttpStatusCode.BadRequest));
                //} else {
                //    var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);
                //    if (pointOfInterest == null) {
                //        return NotFound();
                //    } else {
                //        return Ok(SuccessResponseBody(pointOfInterest, "Awesome"));
                //    }
                //}
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ErrorResponseBody(ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationEntity pointOfInterestForCreationEntity) {
            try {
                if (pointOfInterestForCreationEntity == null) {
                    return BadRequest(ErrorResponseBody("", HttpStatusCode.BadRequest));
                }
             
                if (!ModelState.IsValid) {
                    return BadRequest(ErrorResponseBody(ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage, HttpStatusCode.BadRequest));
                }

                //var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
                //if (city == null) {
                //    return NotFound();
                //}

                //var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

                //var pointOfInterest = new PointOfInterest {
                //    Id = ++maxPointOfInterestId,
                //    Name = new IsNullOrEmptyString(pointOfInterestForCreationEntity.Name).Value,
                //    Description = new IsNullOrEmptyString(pointOfInterestForCreationEntity.Description).Value
                //};

                //city.PointsOfInterest.Add(pointOfInterest);

                //return CreatedAtRoute("GetPointOfInterestById", new { cityId = cityId, id = pointOfInterest.Id }, pointOfInterest);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
