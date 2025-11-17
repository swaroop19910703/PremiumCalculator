using Xunit;
using PremiumCalculator.Services;
using PremiumCalculator.Repositories;
using PremiumCalculator.Strategy;
using PremiumCalculator.Models;
using System;

namespace PremiumCalculator.Tests
{
    public class PremiumServiceTests
    {
        private IPremiumService CreateService()
        {
            var repo = new InMemoryOccupationRepository();
            var factory = new RatingStrategyFactory(repo);
            return new PremiumService(repo, factory);
        }

        [Fact]
        public void CalculatePremium_ValidInput_ReturnsExpected()
        {
            var service = CreateService();
            var input = new MemberInput { Name = "Test", Age = 30, DateOfBirth = "01/1990", Occupation = "Doctor", DeathSumInsured = 100000 };
            var result = service.CalculatePremium(input);
            Assert.Equal(54000m, result.MonthlyPremium);
        }

        [Fact]
        public void CalculatePremium_InvalidOccupation_Throws()
        {
            var service = CreateService();
            var input = new MemberInput { Name = "Test", Age = 30, DateOfBirth = "01/1990", Occupation = "Unknown", DeathSumInsured = 100000 };
            Assert.Throws<KeyNotFoundException>(() => service.CalculatePremium(input));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void CalculatePremium_InvalidAge_Throws(int age)
        {
            var service = CreateService();
            var input = new MemberInput { Name = "T", Age = age, DateOfBirth = "01/1990", Occupation = "Doctor", DeathSumInsured = 100000 };
            Assert.Throws<ArgumentException>(() => service.CalculatePremium(input));
        }
    }
}
