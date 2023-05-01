using Autofac;
using CashSaver.Domain;
using CashSaver.Repositories.Interfaces;

namespace CashSaver.Repositories
{
    public class CashSaverInjectRepositoryModule : Module
    {
        public bool unitOfWork { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            if (unitOfWork)
            {
                builder.Register(c => new UnitOfWork(new CashSaverContext())).As<IUnitOfWork>().InstancePerLifetimeScope();
            }
            builder.RegisterType<CashSaverContext>().As<CashSaverContext>();
            builder.RegisterType<BillRepository>().As<IRepository<Bill>>();
            base.Load(builder);
        }
    }
}
