using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using AnimalSpirit.Ioc;
using Xamarin.Forms;

namespace AnimalSpirit.Extensions
{
    public static class PageExtension
    {
        private interface IViewModelNameFactory
        {
            string GetViewModelName(string viewName);
        }

        private class PageViewModelNameFactory : IViewModelNameFactory
        {
            public string GetViewModelName(string viewName)
            {
                return viewName.Replace("Page", "ViewModel");
            }
        }

        private class ViewViewModelNameFactory : IViewModelNameFactory
        {
            public string GetViewModelName(string viewName)
            {
                return viewName.Replace("View", "ViewModel");
            }
        }

        public static void SetViewModel(this Page page)
        {
            page.SetViewModel(new PageViewModelNameFactory());
        }

        public static void SetViewModel(this Xamarin.Forms.View view)
        {
            view.SetViewModel(new ViewViewModelNameFactory());
        }

        private static void SetViewModel(this VisualElement page, IViewModelNameFactory vmNameFactory)
        {
            try
            {
                var pageName = page.GetType().Name;
                var viewModelTypeName = vmNameFactory.GetViewModelName(pageName);
                var types = page.GetType().GetTypeInfo().Assembly.ExportedTypes;
                var viewModelType = types.FirstOrDefault(n => n.Name.Equals(viewModelTypeName));
                if (viewModelType != null)
                {
                    page.BindingContext = I.Instance.Resolve(viewModelType);
                }
                else
                {
                    Debug.WriteLine($"Failed to find ViewModel for {pageName}");
                }
            }
            catch (Exception e)
            {
                // e.Log();
                throw;
            }
        }
    }
}
