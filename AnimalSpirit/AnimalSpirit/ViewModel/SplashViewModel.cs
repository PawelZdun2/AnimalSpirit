using System.Threading.Tasks;
using AnimalSpirit.Interfaces;
using AnimalSpirit.ViewModel.Base;

namespace AnimalSpirit.ViewModel
{
    public class SplashViewModel : ViewModelBase
    {
        public SplashViewModel(IServiceAggregate serviceAggregate) : base(serviceAggregate)
        {

        }

        protected override async Task LoadData()
        {
            this.NavigationService.NavigateTo<MainPage>();
        }

    }
}
