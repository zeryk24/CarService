using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Api.Services {
public class TokenCheckService
{

	public bool CheckToken( string password )
	{
		if ( password == "6" )
			return true;
		return false;
	}
}
}
