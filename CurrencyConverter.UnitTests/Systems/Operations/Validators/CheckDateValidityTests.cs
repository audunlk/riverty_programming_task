using CurrencyConverter.ConsoleApp.Operations.Validators;

namespace CurrencyConverter.UnitTests.Systems.Operations.Validators

{
    public class CheckDateValidityTests
    {
        [Fact]
        public void CheckDateValidity_Returns_True_If_Date_Is_Valid()
        {
            //Arrange
            var date = "2021-01-01";
            //Act
            var result = CheckDateValidity.CheckDate(date);
            //Assert
            Assert.True(result);
        }
        [Fact]
        public void CheckDateValidity_Returns_False_If_Date_Is_Invalid()
        {
            //Arrange
            var date = "This is not a date";
            //Act
            var result = CheckDateValidity.CheckDate(date);
            //Assert
            Assert.False(result);
        }
       
    }
}
