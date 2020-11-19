using System;
using OrganizationOfEnterprise.Enterprise;
using Xunit;

namespace OrganizationOfEnterprise.Tests
{
    public class PositionTests
    {
        #region snippet_ToCompare_ReturnsInt_InputIsCorrect

        [Fact]
        public void ToCompare_ReturnsInt_InputIsCorrect()
        {
            // Arrange
            var unitOne = new Subdivision {Name = "U1"};
            var positionOne = new Position {Subdivision = unitOne, PositionInCompany = PositionSystem.President};
            var positionTwo = new Position {Subdivision = unitOne, PositionInCompany = PositionSystem.GeneralManager};

            // Act
            var result = positionOne.ToCompare(positionTwo);

            // Assert
            Assert.IsType<int>(result);
        }

        #endregion

        #region snippet_ToCompare_ThrowsNotSupportedException_InputPositionIsNull

        [Fact]
        public void ToCompare_ThrowsNotSupportedException_InputPositionIsNull()
        {
            // Arrange
            var unitOne = new Subdivision {Name = "U1"};
            var positionOne = new Position {Subdivision = unitOne, PositionInCompany = PositionSystem.President};

            //Act
            void Result()
            {
                positionOne.ToCompare(null);
            }

            // Assert
            Assert.Throws<ArgumentNullException>(Result);
        }

        #endregion

        #region snippet_ToCompare_ThrowsNotSupportedException_InputPositionIsNotCorrectType

        [Fact]
        public void ToCompare_ThrowsNotSupportedException_InputPositionIsNotCorrectType()
        {
            // Arrange
            var unitOne = new Subdivision {Name = "U1"};
            var positionOne = new Position {Subdivision = unitOne, PositionInCompany = PositionSystem.President};

            //Act
            void Result()
            {
                positionOne.ToCompare(unitOne);
            }

            // Assert
            Assert.Throws<NotSupportedException>(Result);
        }

        #endregion
    }
}