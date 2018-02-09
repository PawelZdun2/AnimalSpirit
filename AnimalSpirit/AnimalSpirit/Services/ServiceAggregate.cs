using System;
using System.Collections.Generic;
using System.Text;
using AnimalSpirit.Interfaces;
using GalaSoft.MvvmLight.Messaging;

namespace AnimalSpirit.Services
{
    public class ServiceAggregate : IServiceAggregate
    {
        public INavigationService NavigationService { get; }
        public IMessenger MessengerService { get; }

        public ServiceAggregate(INavigationService navigationService, IMessenger messangerService)
        {
            NavigationService = navigationService;
            MessengerService = messangerService;
        }
    }
}
