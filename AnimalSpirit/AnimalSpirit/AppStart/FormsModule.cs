using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AnimalSpirit.Interfaces;
using AnimalSpirit.Services;
using AnimalSpirit.ViewModel.Base;
using Autofac;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;

namespace AnimalSpirit.AppStart
{
    public class FormsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var assembly = typeof(App).GetTypeInfo().Assembly;

            builder.RegisterType<ServiceAggregate>().As<IServiceAggregate>().SingleInstance();
            builder.RegisterInstance(Messenger.Default).SingleInstance();


            //builder.RegisterType<SessionService>().As<ISessionService>().SingleInstance();
            //builder.RegisterType<CacheService>().As<ICacheService>().SingleInstance();
            //builder.RegisterType<CodesToMessageMapper>().As<ICodesToMessageMapper>().SingleInstance();

            //builder.RegisterType<DispatcherService>().As<IDispatcherService>().SingleInstance();
            //builder.RegisterType<TokenRepository>().As<ITokenRepository>().SingleInstance();
            //builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssignableTo<Page>())
                .Except<Page>();

            //builder.RegisterAssemblyTypes(assembly)
            //    .Where(t => t.IsAssignableTo<PopupPage>());

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.IsAssignableTo<ViewModelBase>())
                .Except<ViewModelBase>();

            //builder.RegisterType<NavMenuViewModel>().SingleInstance();

            //builder.RegisterAssemblyTypes(typeof(CreateUserCommand).GetTypeInfo().Assembly)
            //    .Where(t => t.Name.EndsWith("Command"));

            //builder.RegisterAssemblyTypes(assembly)
            //    .Where(t => t.IsAssignableTo<Models.MenuItem>())
            //    .Except<Models.MenuItem>();

            //builder.RegisterType<MenuActionFactory>().As<IMenuActionFactory>();
        }
    }
}
