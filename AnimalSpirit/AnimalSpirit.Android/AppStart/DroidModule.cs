using AnimalSpirit.Interfaces;
using AnimalSpirit.Services;
using Autofac;

namespace AnimalSpirit.Droid.AppStart
{
    public class DroidModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            //builder.RegisterType<TimerService>().As<ITimerService>();
            //builder.RegisterType<ScreenResolutionService>().As<IScreenResolutionService>();
            //builder.RegisterType<ToastService>().As<IToastService>().InstancePerLifetimeScope();
            //builder.RegisterType<CultureService>().As<ICultureService>().InstancePerLifetimeScope();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            //builder.RegisterType<AppLifecycle>().As<IAppLifecycle>().SingleInstance();
            //builder.RegisterType<NotificationService>().As<INotificationService>().SingleInstance();
        }
    }
}