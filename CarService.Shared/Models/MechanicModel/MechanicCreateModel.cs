using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Shared.Models.MechanicModel
{
    public class MechanicCreateModel
    {
        public string Name { get; set; }
        public string ResidencePlace { get; set; }
        public string PhoneNumber { get; set; }
        public bool CarPainter { get; set; }
        public bool CarPlumber { get; set; }
        public bool EngineSpecialist { get; set; }
    }
}
