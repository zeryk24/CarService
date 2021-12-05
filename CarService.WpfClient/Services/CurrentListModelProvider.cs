using CarService.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.WpfClient.Services
{
    internal class CurrentListModelProvider
    {
        private IListModel _currentListModel;
        public IListModel CurrentListModel
        {
            get
            {
                var x = _currentListModel;
                //_currentListModel = null;
                return x;
            }
            set => _currentListModel = value;
        }
    }
}

