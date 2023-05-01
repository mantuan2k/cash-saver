using AzureFunctions.Autofac;
using CashSaver.Domain;
using CashSaver.Domain.Services.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CashSaver.Functions
{
    [DependencyInjectionConfig(typeof(AutofacConfig))]
    public static class DeleteBills
    {
        [FunctionName("DeleteBills")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "bills")]
            HttpRequestMessage req,
            [Inject] IService<Bill> service,
            ILogger log)
        {
            try
            {
                var contentObj = await req.Content.ReadAsAsync<List<Bill>>();

                service.DeleteMany(contentObj);
                service.Save();

                return new HttpResponseMessage(HttpStatusCode.NoContent);
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
