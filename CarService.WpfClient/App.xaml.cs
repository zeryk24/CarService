using CarService.WpfClient.Services;
using CarService.WpfClient.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CarService.WpfClient {
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	public App()
	{
		Bootstrapper.RegisterDependencies( Locator.CurrentMutable, Locator.Current );
	}

	private void OnStartup( object sender, StartupEventArgs e )
	{
		Locator.Current.GetService<MainWindow>().Show();
		Locator.Current.GetService<MainWindowViewModel>().Init();
	}
}
}
