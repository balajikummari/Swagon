using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Swagon.DomainModel;
using Swagon.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Collections.Generic;
using System.Linq;

namespace Swagon.APIs.Controllers
{
    [Route("cities")]
    [ApiController]
    [Authorize]
    public class CitysController : ControllerBase
    {
        private readonly ICityService cityService;


        public CitysController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<City>> Citys()
        {
            try
            {
                var data = cityService.GetCitiesOfaCountry("IND");
                if(data is null || data.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch(Exception e )
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.ToString());
            }
        }

        [Route("{CountryCode}")]
        [HttpGet]
        public ActionResult<IEnumerable<City>> Citys(string CountryCode)
        {
            try
            {
                var data = cityService.GetCitiesOfaCountry(CountryCode);
                if (data is null || data.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e); // or log to file
                return BadRequest(e.ToString());
            }
        }

        [Route("{selectedCountryCode}/{originCityName}")]
        [HttpGet]
        public ActionResult<City> Citys(string selectedCountryCode, string originCityName)
        {
            try
            {
                return Ok(cityService.getCityByName(originCityName, selectedCountryCode));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.ToString());
            }
        }


        [Route("StopNamesToIds/{CountryCode}")]
        [HttpPost]
        public ActionResult<IEnumerable<string>> StopNamesToIds( [FromBody]List<string> stopNames, string CountryCode)
        {
            try
            {            
                return Ok(cityService.StopNamesToIds(stopNames, CountryCode));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.ToString());
            }
        }

        [Route("StopIdsToNames/{CountryCode}")]
        [HttpPost]
        public ActionResult<IEnumerable<string>> StopIdsToNames([FromBody]List<string> StopIds, string CountryCode)
        {
            try
            {
                return Ok(cityService.StopIdsToNames(StopIds, CountryCode));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.ToString());
            }
        }

        

        [Route("GetFare")]
        [HttpGet]
        public ActionResult<decimal> GetPerKmFare()
        {
            try
            {
                return Ok(cityService.GetPerKmFare());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.ToString());
            }
        }

        [Route("GetFare/{FromCityId}/{TocityId}")]
        [HttpPost]
        public ActionResult<double> GetFare( string FromCityId, string TocityId)
        {
            try
            {
                return Ok(cityService.GetFare(FromCityId,TocityId));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest(e.ToString());
            }
        }
    }
}