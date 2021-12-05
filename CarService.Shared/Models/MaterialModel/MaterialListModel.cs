using CarService.Shared.Models.ConsumesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.MaterialModel
{
    public class MaterialListModel : IListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float StockQuantity { get; set; }
        public ICollection<ConsumesListModel> Consumes { get; set; }
    }
}
