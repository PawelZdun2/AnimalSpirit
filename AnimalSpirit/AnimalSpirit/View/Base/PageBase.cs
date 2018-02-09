using System;
using System.Collections.Generic;
using System.Text;
using AnimalSpirit.Extensions;
using AnimalSpirit.ViewModel.Base;
using Xamarin.Forms;

namespace AnimalSpirit.View.Base
{
    public class PageBase : ContentPage
    {
        public ViewModelBase Model => (ViewModelBase)BindingContext;

        public PageBase()
        {
            this.SetViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            Model?.LoadDataCommand?.Execute(null);
        }

        protected override void OnDisappearing()
        {
            Model?.StopCommand?.Execute(null);
        }

        protected override bool OnBackButtonPressed()
        {
            bool executeBaseMethod = true;
            if (BindingContext is ViewModelBase model)
            {
                executeBaseMethod = model.OnBackButtonPressed();
            }
            if (executeBaseMethod)
            {
                Model.NavigationService.GoBack();
            }
            return true;
        }
    }
}
