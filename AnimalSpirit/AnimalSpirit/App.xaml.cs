using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalSpirit.AppStart;
using AnimalSpirit.Ioc;
using AnimalSpirit.Models.Messages;
using AnimalSpirit.View;
using Autofac.Core;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace AnimalSpirit
{
    using GalaSoft.MvvmLight.Messaging;
    using Interfaces;

    public partial class App : Application
	{
		public App(IModule[] platformSpecificModules)
		{
			//InitializeComponent();

			var platformSpecificModuleList = platformSpecificModules.ToList();
			platformSpecificModuleList.Add(new FormsModule());
			I.Instance.SetPlatformSpecificModules(platformSpecificModuleList.ToArray());
		}

		protected override void OnStart ()
		{
		    try
		    {
		        if (MainPage != null)
		        {
		            return;
		        }
		        InitNavigationPage();
		    }
		    catch (Exception e)
		    {
		        //e.Log();
		        throw;
		    }
        }

		protected override void OnSleep ()
		{
		    var messenger = I.Instance.Resolve<IMessenger>();
		    messenger.Send(new ApplicationStateChangedMessage { Sleeped = true });
        }

		protected override void OnResume ()
		{
		    var messenger = I.Instance.Resolve<IMessenger>();
		    messenger.Send(new ApplicationStateChangedMessage { Sleeped = false });
        }

	    private void InitNavigationPage()
	    {
	        var mainPage = I.Instance.Resolve<SplashPage>();
	        var navSer = I.Instance.Resolve<INavigationService>();

	        var navPage = new NavigationPage(mainPage);
	        navSer.SetMainPage(navPage);

	        MainPage = navPage;
	    }
    }
}
