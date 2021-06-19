using DataStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Repository
{
    public class ValSquadData
    {
        //Employees Storage
        public List<Employee> employees = new List<Employee>()
        {
            new Employee{ID=1,Name="Youness",Age=27,Position="Leader"},
            new Employee{ID=2,Name="Mostafa",Age=23,Position="Junior"},
            new Employee{ID=3,Name="Maria",Age=29,Position="Manager"},
            new Employee{ID=4,Name="Youssef",Age=25,Position="Senior"},
            new Employee{ID=5,Name="Shady",Age=28,Position="Principle"}
        };

        //Cars Storage
        public List<Car> cars = new List<Car>()
        {
            new Car{PlateNumber=1,Brand="BMW",Model=2010,EmployeeID=1,CardID=3},
            new Car{PlateNumber=2,Brand="Pora",Model=2004,EmployeeID=3,CardID=1},
            new Car{PlateNumber=3,Brand="Merceedes",Model=2015,EmployeeID=2,CardID=2},
            new Car{PlateNumber=4,Brand="Fiat",Model=2000,EmployeeID=5,CardID=4},
            new Car{PlateNumber=5,Brand="Lada",Model=1998,EmployeeID=4,CardID=5}
        };

        //Cards Storage
        public List<ParkingAccessCard> parkingAccessCards = new List<ParkingAccessCard>()
        {
            new ParkingAccessCard{ID=1,Credit=10},
            new ParkingAccessCard{ID=2,Credit=8},
            new ParkingAccessCard{ID=3,Credit=100},
            new ParkingAccessCard{ID=4,Credit=4},
            new ParkingAccessCard{ID=5,Credit=30}
        };
    }
}
