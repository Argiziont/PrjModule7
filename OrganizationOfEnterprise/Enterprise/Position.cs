using System;
using OrganizationOfEnterprise.Interfaces;

namespace OrganizationOfEnterprise.Enterprise
{
    [Serializable]
    public class Position : IComparer
    {
        public PositionSystem PositionInCompany { get; init; }
        public Subdivision Subdivision { get; init; }

        /// <summary>
        ///     Compares 2 Position
        /// </summary>
        /// <param name="comparable">Position for compare</param>
        /// <returns>If they are equal returns '0' if this position have higher tier, returns '1' else '-1'</returns>
        public int ToCompare(object comparable)
        {
            switch (comparable)
            {
                case null:
                    throw new ArgumentNullException(nameof(comparable));
                case not Position:
                    throw new NotSupportedException(
                        $"Wrong type, object is not comparable to type {GetType().FullName}");
            }

            var comparablePosition = (Position) comparable;

            if ((int) PositionInCompany == (int) comparablePosition.PositionInCompany) return 0;
            if ((int) PositionInCompany < (int) comparablePosition.PositionInCompany) return 1;
            return -1;
        }
    }
}