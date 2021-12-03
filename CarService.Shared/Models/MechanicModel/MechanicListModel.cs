using CarService.Shared.Models.RepairModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.MechanicModel
{
    public class MechanicListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ResidencePlace { get; set; }
        public string PhoneNumber { get; set; }
        public bool CarPainter { get; set; }
        public bool CarPlumber { get; set; }
        public bool EngineSpecialist { get; set; }
        public ICollection<RepairListModel> Repairs { get; set; }
    }
}
