using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrganizationOfEnterprise.Enterprise;
using OrganizationOfEnterprise.Helpers;

namespace PrjModule7
{
    internal static class Program
    {
        private static async Task Main()
        {
            var t11 = new Subdivision {Name = "T11"};
            var t1 = new Subdivision {Name = "T1"};
            t1.AddSubordinateUnits(new List<Subdivision> {t11});

            var t2 = new Subdivision {Name = "T2"};
            var t3 = new Subdivision {Name = "T3"};

            var t4 = new Subdivision {Name = "T4"};

            var t0 = new Subdivision {Name = "T0"};

            t0.AddSubordinateUnits(new List<Subdivision> {t1, t2, t3});

            t0.PrintSubordinateUnits();
            t4.PrintSubordinateUnits();
            t0.PrintMainUnit();

            t0.ToRecruitEmployee(new Employee {Name = "Name1", Surname = "Surname1", LastName = "LastName1"},
                PositionSystem.Director);
            t0.ToRecruitEmployee(new Employee {Name = "Name2", Surname = "Surname2", LastName = "LastName2"},
                PositionSystem.AssistantManager);
            // Console.WriteLine(t0.ToCompare(t4));
            var first = t0.Employees.First();
            var last = t0.Employees.Last();

            Console.WriteLine(first.Name);
            await EnterpriseSerializer.SerializeAsync(first, "employee.json");
            var deserializedFirst = await EnterpriseSerializer.DeSerializeAsync<Employee>("employee.json");
            Console.WriteLine(deserializedFirst.Name);
            Console.WriteLine(first.ToCompare(last));

            var unitOne = new Subdivision {Name = "U1"};
            var employeeOne = new Employee {Name = "Name1", Surname = "Surname1", LastName = "LastName1"};
            var employeeTwo = new Employee {Name = "Name2", Surname = "Surname2", LastName = "LastName2"};
            unitOne.ToRecruitEmployee(employeeOne, PositionSystem.Director);
            unitOne.ToRecruitEmployee(employeeTwo, PositionSystem.AssistantManager);

            Console.WriteLine(employeeOne.ToCompare(employeeTwo));
        }
    }
}