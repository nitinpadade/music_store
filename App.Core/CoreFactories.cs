using App.Core.Command;
using App.Core.Contracts;
using App.Core.Query;
using App.Data;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public static class CoreFactories
    {
        public static void Install(IWindsorContainer container)
        {
            DataFactories.Install(container);

            // Command            
            container.Register(Classes.FromThisAssembly().BasedOn(typeof(ICrudService<>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Component.For(typeof(IOrderService)).ImplementedBy(typeof(SubmitOrderCmd)).LifestyleTransient());

            // Query
            container.Register(Component.For(typeof(IUserValidate)).ImplementedBy(typeof(UserValidateQry)).LifestyleTransient());
            container.Register(Component.For(typeof(IAuthenticateService)).ImplementedBy(typeof(AuthenticateServiceQry)).LifestyleTransient());
            container.Register(Component.For(typeof(IStoreService)).ImplementedBy(typeof(StoreQry)).LifestyleTransient());
            container.Register(Component.For(typeof(ICartService)).ImplementedBy(typeof(CartQuery)).LifestyleTransient());
            container.Register(Component.For(typeof(IOrdersQuery)).ImplementedBy(typeof(OrdersQry)).LifestyleTransient());
            container.Register(Component.For(typeof(IDropListService)).ImplementedBy(typeof(DropListServiceQry)).LifestyleTransient());            

        }
    }
}
