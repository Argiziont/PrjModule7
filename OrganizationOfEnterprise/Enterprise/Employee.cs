using System;
using OrganizationOfEnterprise.Interfaces;

namespace OrganizationOfEnterprise.Enterprise
{
    [Serializable]
    public class Employee : Human, IComparer
    {
        /// <summary>
        ///     Creates instance  of Employee
        /// </summary>
        public Employee()
        {
        }

        /// <summary>
        ///     Creates instance  of Employee
        /// </summary>
        public Employee(string name, string surname, string lastName, DateTime birthDate, HumanSex sex,
            Subdivision subdivision, Position position, decimal salary) : base(name, surname, lastName, birthDate, sex)
        {
            Subdivision = subdivision;
            Position = position;
            Salary = salary;
        }

        public Subdivision Subdivision { get; private set; }

        public Position Position { get; private set; }

        public decimal Salary { get; private set; }

        /// <summary>
        ///     Compares 2 Employees
        /// </summary>
        /// <param name="comparable">Employee for compare</param>
        /// <returns>If they are equal returns '0' if this employee have higher position, returns '1' else '-1'</returns>
        public int ToCompare(object comparable)
        {
            switch (comparable)
            {
                case null:
                    throw new ArgumentNullException(nameof(comparable));
                case not Employee:
                    throw new NotSupportedException(
                        $"Wrong type, object is not comparable to type {GetType().FullName}");
            }

            var comparableEmployee = (Employee) comparable;
            if (comparableEmployee.Subdivision.Name != this.Subdivision.Name)
                throw new NotSupportedException(
                    "This employees are in different Subdivisions");

            if ((int) Position.PositionInCompany == (int) comparableEmployee.Position.PositionInCompany) return 0;
            if ((int) Position.PositionInCompany < (int) comparableEmployee.Position.PositionInCompany) return 1;
            return -1;
        }

        /// <summary>
        ///     Recruits current employee to company
        /// </summary>
        /// <param name="subdivision">Subdivision where employee works</param>
        public void ToRecruit(Subdivision subdivision)
        {
            Subdivision = subdivision ?? throw new ArgumentNullException(nameof(subdivision));
        }

        /// <summary>
        ///     Fires current employee from company
        /// </summary>
        public void ToFire()
        {
            Subdivision = null;
        }

        /// <summary>
        ///     Sets position for current employee in company
        /// </summary>
        public void SetPositionInSubdivision(Position position)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
        }

        /// <summary>
        ///     Sets salary for current employee in company
        /// </summary>
        public void SetSalaryInSubdivision(decimal price)
        {
            Salary = price;
        }
    }
}