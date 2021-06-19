using System;
using System.Collections.Generic;

#nullable disable

namespace ValSquadTest.Models
{
    public partial class ParkingAccessCard
    {
        public ParkingAccessCard()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public int? Credit { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
