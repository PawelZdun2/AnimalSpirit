using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSpirit.Interfaces;
using AnimalSpirit.Ioc;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace AnimalSpirit.Services
{

    public class NavigationService : INavigationService
    {
        protected NavigationPage _navigation;

        public void SetMainPage(NavigationPage navPage)
        {
            _navigation = navPage;
        }

        public Page CurrentPage => _navigation.CurrentPage;

        public virtual async void GoBack(bool animated = true)
        {
            try
            {
                if (CurrentPage.BindingContext is ViewModelBase currentModel)
                {
                    currentModel.Cleanup();
                }

                if (_navigation.Pages.Count() > 1)
                {
                    await _navigation.PopAsync(animated);
                }
                else
                {
                    NavigateTo<MainPage>();
                }
            }
            catch (Exception e)
            {
               // e.Log();
                throw;
            }
        }

        public void GoBack(int numberOfPages)
        {
            for (var i = 0; i < numberOfPages; i++)
            {
                GoBack(false);
            }
        }

        public async Task PushPopupPageAsync(Type popupPageType, bool animation, object parametr = null)
        {
            throw new NotImplementedException();
            //var page = (PopupPage)I.Instance.Resolve(popupPageType);

            //PopupPage page;
            //if (parametr != null)
            //{
            //    page = Activator.CreateInstance(popupPageType, parametr) as PopupPage;
            //}
            //else
            //{
            //    page = Activator.CreateInstance(popupPageType) as PopupPage;
            //}

            //try
            //{
            //    await PopupNavigation.PushAsync(page, animation);
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(e.Message);
            //}
        }

        public async Task PopAllPopupsPageAsync(bool animate)
        {
            throw new NotImplementedException();
            // await PopupNavigation.PopAllAsync(animate: true);
        }


        public void GoBackTo<TPage>() where TPage : Page
        {
            try
            {

                for (var i = _navigation.Navigation.NavigationStack.Count - 1; i >= 0; i--)
                {
                    var stackPage = _navigation.Navigation.NavigationStack[i];
                    if (stackPage is TPage)
                        return;

                    GoBack();
                }
            }
            catch (Exception e)
            {
                //e.Log();
                throw;
            }
        }

        public virtual void NavigateTo<TPage>(bool clearBackStack = false) where TPage : Page
        {
            NavigateTo(typeof(TPage), clearBackStack);
        }

        public virtual void ClearBackStack()
        {
            try
            {
                for (var i = _navigation.Navigation.NavigationStack.Count - 2; i >= 0; i--)
                {
                    var stackPage = _navigation.Navigation.NavigationStack[i];
                    _navigation.Navigation.RemovePage(stackPage);
                }
            }
            catch (Exception e)
            {
               // e.Log();
                throw;
            }
        }

        public void ClearBackStackTo<TPage>(bool withCurrentPage = false) where TPage : Page
        {
            try
            {
                var j = withCurrentPage ? 1 : 2;

                for (var i = _navigation.Navigation.NavigationStack.Count - j; i >= 0; i--)
                {
                    var stackPage = _navigation.Navigation.NavigationStack[i];
                    if (!(stackPage is TPage))
                    {
                        if (stackPage.BindingContext is ViewModelBase currentModel)
                        {
                            currentModel.Cleanup();
                        }

                        _navigation.Navigation.RemovePage(stackPage);
                    }
                }
            }
            catch (Exception e)
            {
               // e.Log();
                throw;
            }
        }

        public async virtual void NavigateTo(Type pageType, bool clearBackStack)
        {
            var page = (Page)I.Instance.Resolve(pageType);

            try
            {
                await _navigation.PushAsync(page);
                if (clearBackStack)
                {
                    ClearBackStack();
                }
            }
            catch (Exception e)
            {
                //e.Log();
                throw;
            }
        }
    }
}
