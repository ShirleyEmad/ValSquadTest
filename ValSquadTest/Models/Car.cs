using System;
using System.Collections.Generic;

#nullable disable

namespace ValSquadTest.Models
{
    public partial class Car
    {
        public int PlateNumber { get; set; }
        public string Brand { get; set; }
        public int Model { get; set; }
        public int? EmployeeId { get; set; }
        public int? CardId { get; set; }

        public virtual ParkingAccessCard Card { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
