using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSpirit.View.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnimalSpirit.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SplashPage : PageBase
	{
		public SplashPage ()
		{
			InitializeComponent ();
		}
	}
}