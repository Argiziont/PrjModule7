using System;
using System.Collections.Generic;
using OrganizationOfEnterprise.Enterprise;
using Xunit;

namespace OrganizationOfEnterprise.Tests
{
    public class SubdivisionTests
    {
        #region snippet_ToCompare_ReturnsInt_InputIsCorrect

        [Fact]
        public void ToCompare_ReturnsInt_InputIsCorrect()
        {
            // Arrange
            var unitOne = new Subdivision() { Name = "U1" };
            var unitTwo = new Subdivision() { Name = "U2" };
            var unitThree = new Subdivision() { Name = "U3" };

            unitThree.AddSubordinateUnits(new List<Subdivision> {unitOne, unitTwo});

            // Act
            var result = unitOne.ToCompare(unitTwo);

            // Assert
            Assert.IsType<int>(result);
        }

        #endregion

        #region snippet_ToCompare_ThrowsNotSupportedException_InputEmployeesHaveDifferentSubdivisions

        [Fact]
        public void ToCompare_ThrowsNotSupportedException_InputUnitsHaveDifferentSubdivisions()
        {
            // Arrange
            var unitOne = new Subdivision() { Name = "U1" };
            var unitTwo = new Subdivision() { Name = "U2" };

            //Act
            void Result() => unitOne.ToCompare(unitTwo);

            // Assert
            Assert.Throws<NotSupportedException>(Result);
        }

        #endregion

        #region snippet_ToCompare_ThrowsArgumentNullException_InputEmployeeIsNotCorrectType

        [Fact]
        public void ToCompare_ThrowsArgumentNullException_InputEmployeeIsNotCorrectType()
        {
            // Arrange
            var unitOne = new Subdivision() { Name = "U1" };

            //Act
            void Result() => unitOne.ToCompare(null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion

        #region snippet_ToRecruitEmployee_Passes_InputIsCorrect

        [Fact]
        public void ToRecruitEmployee_Passes_InputIsCorrect()
        {
            // Arrange
            var employeeOne = new Employee { Name = "Name1", Surname = "Surname1", LastName = "LastName1" };

            var unitOne = new Subdivision() { Name = "U1" };

            // Act
            unitOne.ToRecruitEmployee(employeeOne, PositionSystem.President);

            // Assert
            Assert.Single(unitOne.Employees);
        }

        #endregion

        #region snippet_ToRecruitEmployee_ThrowsArgumentNullException_InputEmployeeIsNull

        [Fact]
        public void ToRecruitEmployee_ThrowsArgumentNullException_InputEmployeeIsNull()
        {
            // Arrange
            var unitOne = new Subdivision() { Name = "U1" };

            // Act
            void Result()=>unitOne.ToRecruitEmployee(null, PositionSystem.President);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion

        #region snippet_ToFireEmployee_Passes_InputIsCorrect

        [Fact]
        public void ToFireEmployee_Passes_InputIsCorrect()
        {
            // Arrange
            var employeeOne = new Employee { Name = "Name1", Surname = "Surname1", LastName = "LastName1" };

            var unitOne = new Subdivision() { Name = "U1" };

            unitOne.ToRecruitEmployee(employeeOne, PositionSystem.President);
            // Act
            unitOne.ToFireEmployee(employeeOne.Name, employeeOne.Surname, employeeOne.LastName);

            // Assert
            Assert.Empty(unitOne.Employees);
        }

        #endregion

        #region snippet_ToFireEmployee_ThrowsArgumentNullException_InputEmployeeIsNull

        [Fact]
        public void ToFireEmployee_ThrowsArgumentNullException_InputEmployeeIsNull()
        {
            // Arrange
            var unitOne = new Subdivision() { Name = "U1" };

            // Act
            void Result() => unitOne.ToFireEmployee(null, null,null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion

        #region snippet_ToFireEmployee_ThrowsKeyNotFoundException_InputEmployeeIsNull

        [Fact]
        public void ToFireEmployee_ThrowsKeyNotFoundException_InputEmployeeIsIncorrect()
        {
            // Arrange
            var employeeOne = new Employee { Name = "Name1", Surname = "Surname1", LastName = "LastName1" };
            var employeeTwo = new Employee { Name = "Name2", Surname = "Surname2", LastName = "LastName2" };

            var unitOne = new Subdivision() { Name = "U1" };

            unitOne.ToRecruitEmployee(employeeOne, PositionSystem.President);

            // Act
            void Result() => unitOne.ToFireEmployee(employeeTwo.Name, employeeTwo.Surname, employeeTwo.LastName);

            // Assert
            Assert.Throws<KeyNotFoundException>(Result);
        }

        #endregion

        #region snippet_AddMainUnit_Passes_InputIsCorrect

        [Fact]
        public void AddMainUnit_Passes_InputIsCorrect()
        {
            // Arrange
            var unitOne = new Subdivision() { Name = "U1" };
            var unitTwo = new Subdivision() { Name = "U2" };

            // Act
            unitOne.AddMainUnit(unitTwo);

            // Assert
            Assert.NotNull(unitOne.MainUnit);
        }

        #endregion

        #region snippet_AddMainUnit_ThrowsArgumentNullException_InputIsNull

        [Fact]
        public void AddMainUnit_ThrowsArgumentNullException_InputIsNull()
        {
            // Arrange
            var unitOne = new Subdivision() { Name = "U1" };

            // Act
            void Result() => unitOne.AddMainUnit(null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion

        #region snippet_AddSubordinateUnits_Passes_InputIsCorrect

        [Fact]
        public void AddSubordinateUnits_Passes_InputIsCorrect()
        {
            // Arrange
            var unitOne = new Subdivision() { Name = "U1" };
            var unitTwo = new Subdivision() { Name = "U2" };

            // Act
            unitOne.AddSubordinateUnits(new List<Subdivision>{ unitTwo});

            // Assert
            Assert.Single(unitOne.SubordinateUnits);
        }

        #endregion

        #region snippet_AddSubordinateUnits_ThrowsArgumentNullException_InputIsNull

        [Fact]
        public void AddSubordinateUnits_ThrowsArgumentNullException_InputIsNull()
        {
            // Arrange
            var unitOne = new Subdivision() { Name = "U1" };

            // Act
            void Result() => unitOne.AddSubordinateUnits(null);

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion
    }
}
