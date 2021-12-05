using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.ConsumesModel
{
    public class ConsumesListModel : IListModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int ActivityId { get; set; }
        public int MaterialId { get; set; }
    }
}
