using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using OrganizationOfEnterprise.Interfaces;

namespace OrganizationOfEnterprise.Enterprise
{
    [Serializable]
    public class Subdivision : IComparer
    {
        public string Name { get; init; }
        public Subdivision MainUnit { get; private set; }

        [JsonIgnore] public List<Subdivision> SubordinateUnits { get; } = new();

        [JsonIgnore] public List<Employee> Employees { get; } = new();

        /// <summary>
        ///     Compares 2 Subdivisions
        /// </summary>
        /// <param name="comparable">Subdivision for compare</param>
        /// <returns>If they are equal returns '0' if this unit have higher position, returns '1' else '-1'</returns>
        public int ToCompare(object comparable)
        {
            switch (comparable)
            {
                case null:
                    throw new ArgumentNullException(nameof(comparable));
                case not Subdivision:
                    throw new NotSupportedException(
                        $"Wrong type, object is not comparable to type {GetType().FullName}");
            }

            var comparableSubdivision = (Subdivision) comparable;

            var thisTopLevelUnit = this;
            var comparableTopLevelUnit = comparableSubdivision;
            int thisDistanceToTopLevel = 0, comparableDistanceToTopLevel = 0;

            while (thisTopLevelUnit.MainUnit != null)
            {
                thisTopLevelUnit = thisTopLevelUnit.MainUnit;
                thisDistanceToTopLevel++;
            }

            while (comparableTopLevelUnit.MainUnit != null)
            {
                comparableTopLevelUnit = comparableTopLevelUnit.MainUnit;
                comparableDistanceToTopLevel++;
            }

            if (thisTopLevelUnit.Name != comparableTopLevelUnit.Name)
                throw new NotSupportedException(
                    "This object and comparable are in different hierarchies");
            if (thisDistanceToTopLevel == comparableDistanceToTopLevel) return 0;

            if (thisDistanceToTopLevel > comparableDistanceToTopLevel) return -1;

            return 1;
        }

        /// <summary>
        ///     Adds employee to this company
        /// </summary>
        /// <param name="employee">Employee</param>
        /// <param name="positionInUnit">Position that employee will take</param>
        public void ToRecruitEmployee(Employee employee, PositionSystem positionInUnit)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));
            if (!Enum.IsDefined(typeof(PositionSystem), positionInUnit))
                throw new InvalidEnumArgumentException(nameof(positionInUnit), (int) positionInUnit,
                    typeof(PositionSystem));

            employee.SetPositionInSubdivision(new Position {Subdivision = this, PositionInCompany = positionInUnit});
            employee.ToRecruit(this);
            employee.SetSalaryInSubdivision(10000 / (int) positionInUnit + 1 / (int) positionInUnit * 500);

            Employees.Add(employee);
        }

        /// <summary>
        ///     Fires employee from this company
        /// </summary>
        public void ToFireEmployee(string employeeName, string employeeSurname, string employeeLastName)
        {
            if (employeeName == null) throw new ArgumentNullException(nameof(employeeName));
            if (employeeSurname == null) throw new ArgumentNullException(nameof(employeeSurname));
            if (employeeLastName == null) throw new ArgumentNullException(nameof(employeeLastName));

            _ = Employees.FirstOrDefault(x =>
            {
                if (x.Name != employeeName || x.Surname != employeeSurname || x.LastName != employeeLastName)
                    throw new KeyNotFoundException("There no such employee");

                x.ToFire();
                Employees.Remove(x);
                return true;
            });
        }

        /// <summary>
        ///     Prints all subordinate units of this subdivision
        /// </summary>
        public void PrintSubordinateUnits()
        {
            if (SubordinateUnits.Count == 0)
            {
                Console.WriteLine($"{Name} has no Subordinate units");
                return;
            }

            SubordinateUnits.ForEach(s => Console.WriteLine(s.Name));
        }

        /// <summary>
        ///     Prints higher level unit for this subdivision
        /// </summary>
        public void PrintMainUnit()
        {
            Console.WriteLine(MainUnit == null
                ? $"{Name} is top level main Subdivision"
                : $"{MainUnit} is higher level Subdivision");
        }

        /// <summary>
        ///     Gets number of employee in this subdivision
        /// </summary>
        public int GetCountOfEmployees()
        {
            return Employees.Count;
        }

        /// <summary>
        ///     Gets average salary for employees in this subdivision
        /// </summary>
        public decimal GetAverageSalary()
        {
            return GetTotalSalary() / Employees.Count;
        }

        /// <summary>
        ///     Gets total salary for employees in this subdivision
        /// </summary>
        public decimal GetTotalSalary()
        {
            return Employees.Sum(emp => emp.Salary);
        }

        /// <summary>
        ///     Adds higher level unit for this subdivision
        /// </summary>
        /// <param name="unit">Higher level Subdivision</param>
        public Subdivision AddMainUnit(Subdivision unit)
        {
            MainUnit = unit ?? throw new ArgumentNullException(nameof(unit));

            return this;
        }

        /// <summary>
        ///     Adds higher lower level units for this subdivision
        /// </summary>
        /// <param name="units">List of lover levels Subdivisions</param>
        public Subdivision AddSubordinateUnits(IEnumerable<Subdivision> units)
        {
            if (units == null) throw new ArgumentNullException(nameof(units));

            foreach (var unit in units)
            {
                unit.AddMainUnit(this);
                SubordinateUnits.Add(unit);
            }

            return this;
        }
    }
}