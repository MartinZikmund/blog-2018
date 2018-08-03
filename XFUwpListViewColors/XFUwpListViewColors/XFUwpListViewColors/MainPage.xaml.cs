using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFUwpListViewColors
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
	        this.BindingContext = this;
	    }


	    public ObservableCollection<string> Items { get; } =
	        new ObservableCollection<string>() { "Test 1", "Test 2", "Test 3" };
    }
}
