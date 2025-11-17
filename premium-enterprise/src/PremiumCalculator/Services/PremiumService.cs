using System;
using PremiumCalculator.Models;
using PremiumCalculator.Repositories;
using PremiumCalculator.Strategy;

namespace PremiumCalculator.Services
{
    public class PremiumService : IPremiumService
    {
        private readonly IOccupationRepository _repo;
        private readonly IRatingStrategyFactory _factory;

        public PremiumService(IOccupationRepository repo, IRatingStrategyFactory factory)
        {
            _repo = repo;
            _factory = factory;
        }

        public PremiumResult CalculatePremium(MemberInput input)
        {
            if (input is null) throw new ArgumentNullException(nameof(input));
            if (string.IsNullOrWhiteSpace(input.Name)) throw new ArgumentException("Name is required");
            if (string.IsNullOrWhiteSpace(input.Occupation)) throw new ArgumentException("Occupation is required");
            if (input.Age <= 0) throw new ArgumentException("Age must be > 0");
            if (input.DeathSumInsured <= 0) throw new ArgumentException("Death Sum Insured must be > 0");

            var rating = _repo.GetRatingForOccupation(input.Occupation);
            var strategy = _factory.Create(rating);
            var factor = strategy.GetFactor();

            var premium = (input.DeathSumInsured * factor * input.Age) / 1000m * 12m;

            return new PremiumResult { MonthlyPremium = decimal.Round(premium, 2) };
        }
    }
}
