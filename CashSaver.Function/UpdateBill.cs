using AzureFunctions.Autofac;
using CashSaver.Domain;
using CashSaver.Domain.Services.Interfaces;
using CashSaver.Function.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CashSaver.Function
{
    [DependencyInjectionConfig(typeof(AutofacConfig))]
    public static class UpdateBill
    {
        [FunctionName("UpdateBill")]
        [OpenApiOperation(operationId: "UpdateBills", tags: new[] { "Despesa" }, Description = "Atualiza as despesas especificadas")]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<Bill>), Description = "Despesas atualizadas com sucesso")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Unauthorized, contentType: "application/json", bodyType: typeof(ErrorResponse), Description = "Erro de autenticação")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.InternalServerError, contentType: "application/json", bodyType: typeof(ErrorResponse), Description = "Erro interno no servidor")]
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
