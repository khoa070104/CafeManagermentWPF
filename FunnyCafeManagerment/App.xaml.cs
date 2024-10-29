using FunnyCafeManagerment_DataAcess.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace FunnyCafeManagerment
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private static MainVM _mainViewModel;
		public static MainVM MainViewModel
		{
			get
			{
				if (_mainViewModel == null)
					_mainViewModel = new MainVM();
				return _mainViewModel;
			}
		}
	}

}
