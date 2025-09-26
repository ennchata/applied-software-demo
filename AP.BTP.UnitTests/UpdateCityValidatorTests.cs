using FluentValidation.TestHelper;
using Moq;
using AP.BTP.Application.Interfaces;
using AP.BTP.Application.CQRS.Cities;

namespace AP.DemoProject.Application.UnitTests.CQRS.Cities
{
    [TestClass]
    public class UpdateCityValidatorTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly UpdateCityValidator _validator;

        public UpdateCityValidatorTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _validator = new UpdateCityValidator(_mockUow.Object);
        }

        [TestMethod]
        public async Task TestPopulationNegative()
        {
            // Arrange
            var command = new UpdateCityCommand
            {
                Population = -1,
                CountryId = 1
            };

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Population)
                .WithErrorMessage("inwoners aantal moet positief getal zijn");
        }

        [TestMethod]
        public async Task TestPopulationVeryNegative()
        {
            // Arrange
            var command = new UpdateCityCommand
            {
                Population = -100,
                CountryId = 1
            };

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Population)
                .WithErrorMessage("inwoners aantal moet positief getal zijn");
        }

        [TestMethod]
        public async Task TestPopulationExceedingTenMillion()
        {
            // Arrange
            var command = new UpdateCityCommand
            {
                Population = 10000001,
                CountryId = 1
            };

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Population)
                .WithErrorMessage("inwoners aantal mag niet meer dan 10mil zijn");
        }

        [TestMethod]
        public async Task TestPopulationExceedingTwentyMillion()
        {
            // Arrange
            var command = new UpdateCityCommand
            {
                Population = 20000000,
                CountryId = 1
            };

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Population)
                .WithErrorMessage("inwoners aantal mag niet meer dan 10mil zijn");
        }

        [TestMethod]
        public async Task TestPopulationZero()
        {
            // Arrange
            var command = new UpdateCityCommand
            {
                Population = 0,
                CountryId = 1
            };

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Population);
        }

        [TestMethod]
        public async Task TestPopulationWithinLimit()
        {
            // Arrange
            var command = new UpdateCityCommand
            {
                Population = 5000000,
                CountryId = 1
            };

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Population);
        }

        [TestMethod]
        public async Task TestPopulationAtLimit()
        {
            // Arrange
            var command = new UpdateCityCommand
            {
                Population = 10000000,
                CountryId = 1
            };

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Population);
        }

        [TestMethod]
        public async Task TestCountryIdLessThanMinimum()
        {
            // Arrange
            var command = new UpdateCityCommand
            {
                Population = 10000,
                CountryId = -5
            };

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CountryId)
                .WithErrorMessage("kies een land aub");
        }

        [TestMethod]
        public async Task TestCountryIdWithinLimits()
        {
            // Arrange
            var command = new UpdateCityCommand
            {
                Population = 10000,
                CountryId = -3
            };

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CountryId);
        }

        [TestMethod]
        public async Task TestCountryIdPositive()
        {
            // Arrange
            var command = new UpdateCityCommand
            {
                Population = 10000,
                CountryId = 1
            };

            // Act
            var result = await _validator.TestValidateAsync(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CountryId);
        }

    }
}
