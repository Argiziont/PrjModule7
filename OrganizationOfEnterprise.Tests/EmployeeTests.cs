using System;
using OrganizationOfEnterprise.Enterprise;
using Xunit;

namespace OrganizationOfEnterprise.Tests
{
    public class EmployeeTests
    {
        #region snippet_ToCompare_ReturnsInt_InputIsCorrect

        [Fact]
        public void ToCompare_ReturnsInt_InputIsCorrect()
        {
            // Arrange
            var unitOne = new Subdivision {Name = "U1"};

            var employeeOne = new Employee {Name = "Name1", Surname = "Surname1", LastName = "LastName1"};
            var employeeTwo = new Employee {Name = "Name2", Surname = "Surname2", LastName = "LastName2"};

            unitOne.ToRecruitEmployee(employeeOne, PositionSystem.Director);
            unitOne.ToRecruitEmployee(employeeTwo, PositionSystem.AssistantManager);

            // Act
            var result = employeeOne.ToCompare(employeeTwo);

            // Assert
            Assert.IsType<int>(result);
        }

        #endregion

        #region snippet_ToCompare_ThrowsNotSupportedException_InputEmployeesHaveDifferentSubdivisions

        [Fact]
        public void ToCompare_ThrowsNotSupportedException_InputEmployeesHaveDifferentSubdivisions()
        {
            // Arrange
            var unitOne = new Subdivision {Name = "U1"};
            var unitTwo = new Subdivision {Name = "U2"};

            var employeeOne = new Employee {Name = "Name1", Surname = "Surname1", LastName = "LastName1"};
            var employeeTwo = new Employee {Name = "Name2", Surname = "Surname2", LastName = "LastName2"};

            unitOne.ToRecruitEmployee(employeeOne, PositionSystem.Director);
            unitTwo.ToRecruitEmployee(employeeTwo, PositionSystem.AssistantManager);

            //Act
            void Result()
            {
                employeeOne.ToCompare(employeeTwo);
            }

            // Assert
            Assert.Throws<NotSupportedException>(Result);
        }

        #endregion

        #region snippet_ToCompare_ThrowsNotSupportedException_InputEmployeeIsNotCorrectType

        [Fact]
        public void ToCompare_ThrowsNotSupportedException_InputEmployeeIsNotCorrectType()
        {
            // Arrange
            var unitOne = new Subdivision {Name = "U1"};

            var employeeOne = new Employee {Name = "Name1", Surname = "Surname1", LastName = "LastName1"};
            var employeeTwo = new Subdivision {Name = "U2"};

            unitOne.ToRecruitEmployee(employeeOne, PositionSystem.Director);

            //Act
            void Result()
            {
                employeeOne.ToCompare(employeeTwo);
            }

            // Assert
            Assert.Throws<NotSupportedException>(Result);
        }

        #endregion

        #region snippet_ToCompare_ThrowsArgumentNullException_InputEmployeeIsNull

        [Fact]
        public void ToCompare_ThrowsArgumentNullException_InputEmployeeIsNull()
        {
            // Arrange
            var unitOne = new Subdivision {Name = "U1"};

            var employeeOne = new Employee {Name = "Name1", Surname = "Surname1", LastName = "LastName1"};

            unitOne.ToRecruitEmployee(employeeOne, PositionSystem.Director);

            //Act
            void Result()
            {
                employeeOne.ToCompare(null);
            }

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion

        #region snippet_ToRecruit_Passes_InputIsCorrect

        [Fact]
        public void ToRecruit_Passes_InputIsCorrect()
        {
            // Arrange
            var unitOne = new Subdivision {Name = "U1"};

            var employeeOne = new Employee {Name = "Name1", Surname = "Surname1", LastName = "LastName1"};

            // Act
            employeeOne.ToRecruit(unitOne);

            // Assert
            Assert.NotNull(employeeOne.Subdivision);
        }

        #endregion

        #region snippet_ToRecruit_ThrowsArgumentNullException_InputIsInCorrect

        [Fact]
        public void ToRecruit_ThrowsArgumentNullException_InputIsInCorrect()
        {
            // Arrange
            var employeeOne = new Employee {Name = "Name1", Surname = "Surname1", LastName = "LastName1"};

            // Act
            void Result()
            {
                employeeOne.ToRecruit(null);
            }

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion

        #region snippet_SetPositionInSubdivision_Passes_InputIsCorrect

        [Fact]
        public void SetPositionInSubdivision_Passes_InputIsCorrect()
        {
            // Arrange
            var unitOne = new Subdivision {Name = "U1"};

            var positionOne = new Position {Subdivision = unitOne, PositionInCompany = PositionSystem.Associate};

            var employeeOne = new Employee {Name = "Name1", Surname = "Surname1", LastName = "LastName1"};

            // Act
            employeeOne.SetPositionInSubdivision(positionOne);

            // Assert
            Assert.NotNull(employeeOne.Position);
        }

        #endregion

        #region snippet_SetPositionInSubdivision_ThrowsArgumentNullException_InputIsInCorrect

        [Fact]
        public void SetPositionInSubdivision_ThrowsArgumentNullException_InputIsInCorrect()
        {
            // Arrange
            var employeeOne = new Employee {Name = "Name1", Surname = "Surname1", LastName = "LastName1"};

            // Act
            void Result()
            {
                employeeOne.SetPositionInSubdivision(null);
            }

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion
    }
}