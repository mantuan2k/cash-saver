using Autofac;
using AzureFunctions.Autofac.Configuration;
using CashSaver.Repositories;
using CashSaver.Services;

namespace CashSaver.Function
{
    public class AutofacConfig
    {
        public AutofacConfig(string functionName)
        {
            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterModule(new CashSaverInjectRepositoryModule() { unitOfWork = true }) ;
                builder.RegisterModule(new CashSaverInjectServiceModule());
            }, functionName);
        }
    }
}
    