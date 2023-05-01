using AzureFunctions.Autofac;
using CashSaver.Domain;
using CashSaver.Domain.Services.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CashSaver.Functions
{
    [DependencyInjectionConfig(typeof(AutofacConfig))]
    public static class CreateBill
    {
        [FunctionName("CreateBill")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "bills")]
                HttpRequestMessage req,
                [Inject] IService<Bill> service,
                ILogger log)
        {
            try
            {
                var bills = await req.Content.ReadAsAsync<Bill>();
                                
                service.Add(bills);
                service.Save();

                var json = JsonConvert.SerializeObject(bills, Formatting.Indented);


                return new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(e.Message)
                };
            }
        }
    }
}
