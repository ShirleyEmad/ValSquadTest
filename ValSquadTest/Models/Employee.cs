using System;
using System.Collections.Generic;

#nullable disable

namespace ValSquadTest.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
