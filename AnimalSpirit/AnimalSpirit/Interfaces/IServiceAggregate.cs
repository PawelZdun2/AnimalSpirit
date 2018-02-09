using GalaSoft.MvvmLight.Messaging;

namespace AnimalSpirit.Interfaces
{
    public interface IServiceAggregate
    {
        INavigationService NavigationService { get; }
        IMessenger MessengerService { get; }
    }
}
