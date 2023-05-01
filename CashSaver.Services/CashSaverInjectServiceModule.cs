using Autofac;
using CashSaver.Domain;
using CashSaver.Domain.Services.Interfaces;

namespace CashSaver.Services
{
    public class CashSaverInjectServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BillService>().As<IService<Bill>>();
            base.Load(builder);
        }
    }
}
