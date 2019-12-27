using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TwitterCampaignManager.Funcs
{
    public static class Dates
    {        
        [FunctionName("DatesCompare")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, ILogger log)
        {
            log.Log(LogLevel.Trace, "C# HTTP trigger function processed a request.");

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            return ParseDates(requestBody);

        }

        public static IActionResult ParseDates(string requestBody)
        {
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            DateTime date1 = (DateTime)data.date1;
            DateTime date2 = DateTime.FromOADate((double)data.date2);

            int returnFlagIndicator = 0;
            if (date1 > date2)
            {
                returnFlagIndicator = 1;
            }
            else if (date1 < date2)
            {
                returnFlagIndicator = -1;
            }

            return (ActionResult)new OkObjectResult(new
            {
                returnFlag = returnFlagIndicator
            });
        }
    }
}
