using CarService.WpfClient.Services;
using CarService.WpfClient.ViewModels.Base;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CarService.WpfClient.ViewModels {
public class MainWindowViewModel : ViewModelBase
{
	private ViewModelBase selectedViewModel;
	public ViewModelBase SelectedViewModel
	{
		get { return selectedViewModel; }
		set
		{
			selectedViewModel = value;
			OnPropertyChanged( nameof( SelectedViewModel ) );
		}
	}

	public MainWindowViewModel()
	{
		SelectedViewModel = Locator.Current.GetService<MainViewViewModel>();
	}

	public void Init()
	{
		var mainWindow = Application.Current.MainWindow;
		mainWindow.SizeChanged += MainWindow_SizeChanged;
	}

	private void MainWindow_SizeChanged( object sender, SizeChangedEventArgs e )
	{
		if ( sender is Window window )
			ScreenParameters.Instance.WindowSizeChanged( window, e );
	}
}
}
