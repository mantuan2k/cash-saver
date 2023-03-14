using Autofac;
using CashSaver.Domain;
using CashSaver.Repositories.Interfaces;

namespace CashSaver.Repositories
{
    public class CashSaverInjectRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CashSaverContext>().As<CashSaverContext>();
            builder.Register(c => new BillRepository(new CashSaverContext())).As<IService<Bill>>();
            base.Load(builder);
        }
    }
}
