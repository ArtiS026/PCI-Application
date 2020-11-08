using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static PizzaCabinInc.Model.ScheduleModel;

namespace PizzaCabinInc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiClient : ControllerBase
    {
        //get the data from the REST service PizzaCabinInc.
        [HttpGet]
        public async Task<ActionResult<string>> GetPizzacabinicIncResult()
        {
            try
            {
                var result = await BusinessLogic.ScheduleAsync.GetPizzacabinicIncJsonResult();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        // GET api/values/5
        //query SchedulesResponse data from database
        [HttpGet("{id}")]
        public ActionResult<List<ScheduleResponse>> GetSchedulesResponse(int id)
        {
            try
            {
                var result = DataAccess.Repository.GetSchedulesResponse();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        // POST api/
        //post SchedulesResponse Json data into database 
        [HttpPost]
        public async void PostPizzacabinicIncJsonDataInDB()
        {
            try
            {
                // pass deseralized object to insert method 

                var result = await BusinessLogic.ScheduleAsync.GetPizzacabinicIncJsonResult();
                var scheduleresponse = JsonConvert.DeserializeObject<ScheduleResponse>(result);
                DataAccess.Repository.InsertScheduleResponse(scheduleresponse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
