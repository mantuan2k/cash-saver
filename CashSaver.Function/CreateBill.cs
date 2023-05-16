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
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace CashSaver.Function
{
    [DependencyInjectionConfig(typeof(AutofacConfig))]
    public static class CreateBill
    {
        [FunctionName("CreateBill")]
        [OpenApiOperation(operationId: "CreateBill", tags: new[] { "Despesa" }, Description = "Cadastra uma despesa no sistema")]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiRequestBody("application/json", typeof(Bill))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Bill), Description = "Despesa criada com sucesso")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Unauthorized, contentType: "application/json", bodyType: typeof(ErrorResponse), Description = "Erro de autenticação")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.InternalServerError, contentType: "application/json", bodyType: typeof(ErrorResponse), Description = "Erro interno no servidor")]
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
                var json = JsonConvert.SerializeObject(new ErrorResponse { Message = e.Message }, Formatting.Indented);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
            }
        }
    }
}
