using AzureFunctions.Autofac;
using CashSaver.Domain;
using CashSaver.Domain.Services.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CashSaver.Functions
{
    [DependencyInjectionConfig(typeof(AutofacConfig))]
    public static class UpdateBill
    {
        [FunctionName("UpdateBill")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "bills")] 
            HttpRequestMessage req,
            [Inject] IService<Bill> service,
            ILogger log)
        {
            var contentEntity = await req.Content.ReadAsAsync<Bill>();
            var entity = service.GetById(contentEntity.Id);

            if (entity == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            service.Update(contentEntity);
            service.Save();

            var json = JsonConvert.SerializeObject(contentEntity, Formatting.Indented);

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
        }
    }
}
