using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PizzaCabinInc.BusinessLogic
{
    public class ScheduleAsync
    {
        //get schedule data from external Rest service PizzacabinicInc
        public async static Task<string> GetPizzacabinicIncJsonResult()
        {
            try
            {
                string url = "http://pizzacabininc.azurewebsites.net/PizzaCabinInc.svc/schedule/2015-12-14"; // Pizzacabininc service url
                using (HttpClient client = new HttpClient())
                {
                    var result = await client.GetStringAsync(url);
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }
    }
}
