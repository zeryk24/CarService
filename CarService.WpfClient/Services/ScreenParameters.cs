using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CarService.WpfClient.Services {
class ScreenParameters
{
	public event EventHandler WindowSizeChangedEvent;

	private static readonly ScreenParameters StaticInstance = new ScreenParameters();
	public static ScreenParameters Instance => StaticInstance;

	public double WindowWidth { get; set; }
	public double WindowHeight { get; set; }

	public void WindowSizeChanged( Window window, SizeChangedEventArgs e )
	{
		if ( window == null )
		{
			return;
		}

		ScreenParameters.Instance.WindowWidth = window.Width;
		ScreenParameters.Instance.WindowHeight = window.Height;
		WindowSizeChangedEvent ? .Invoke( this, EventArgs.Empty );
	}

}
}
