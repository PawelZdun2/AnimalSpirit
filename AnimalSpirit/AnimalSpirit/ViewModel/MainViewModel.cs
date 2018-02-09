
using AnimalSpirit.Interfaces;
using AnimalSpirit.ViewModel.Base;

namespace AnimalSpirit.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IServiceAggregate serviceAggregate) : base(serviceAggregate)
        {

        }
    }
}
