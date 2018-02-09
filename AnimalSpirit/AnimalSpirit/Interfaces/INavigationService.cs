using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnimalSpirit.Interfaces
{
    public interface INavigationService
    {
        Page CurrentPage { get; }

        void ClearBackStack();
        void ClearBackStackTo<TPage>(bool withCurrentPage = false) where TPage : Page;
        void GoBack(bool animated = true);
        void GoBack(int numberOfPages);
        void GoBackTo<TPage>() where TPage : Page;
        void NavigateTo<TPage>(bool clearBackStack = false) where TPage : Page;
        void NavigateTo(Type pageType, bool clearBackStack = false);

        /// <summary>
        /// Method used to push popup 
        /// </summary>
        /// <typeparam name="TPopup">type of the page</typeparam>
        /// <param name="page">acctual page</param>
        /// <param name="animation">set true if you want to have animation on opening the popup</param>
        /// <returns></returns>
        Task PushPopupPageAsync(Type popupPageType, bool animation, object parametr = null);
        Task PopAllPopupsPageAsync(bool animate);
        void SetMainPage(NavigationPage navPage);
    }
}
