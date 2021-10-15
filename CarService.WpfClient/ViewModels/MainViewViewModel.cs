using CarService.WpfClient.Services;
using CarService.WpfClient.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.WpfClient.ViewModels {
public class OrdersModel
{
	public DateTime Date { get; set; }
	public string Name { get; set; }
	public string Number { get; set; }
	public string Car { get; set; }
}

public class MainViewViewModel : ViewModelBase
{
	private List<OrdersModel> _orders;
	public List<OrdersModel> Orders
	{
		get { return _orders; }
		set
		{
			_orders = value;
			OnPropertyChanged( nameof( Orders ) );
		}
	}

	private int _width;
	public int Width
	{
		get { return _width; }
		set
		{
			_width = value;
			OnPropertyChanged( nameof( Width ) );
		}
	}

	public MainViewViewModel()
	{
		var x = new OrdersModel
		{
			Date = new DateTime( 2010, 10, 10 ),
			Name = "Emil zelený",
			Number = "+420 731 255 878",
			Car = "Ford Focus (3BC5847)"
		};

		Orders = new List<OrdersModel>();
		Orders.Add( x );
		Orders.Add( x );
		Orders.Add( x );
		Orders.Add( x );
		Orders.Add( x );
		Orders.Add( x );
		Orders.Add( x );
		Orders.Add( x );
		Orders.Add( x );
		Orders.Add( x );
		Orders.Add( x );
		Orders.Add( x );
		Orders.Add( x );
		Orders.Add( x );

		ScreenParameters.Instance.WindowSizeChangedEvent += WindowSizeChangedEvent;

		Width = 200;
	}

	private void WindowSizeChangedEvent( object sender, EventArgs e )
	{
		Width = ( int )( ScreenParameters.Instance.WindowWidth / 6 );
	}
}
}
