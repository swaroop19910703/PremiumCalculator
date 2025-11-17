using PremiumCalculator.Repositories;
using System;

namespace PremiumCalculator.Strategy
{
    public interface IRatingStrategyFactory
    {
        IRatingStrategy Create(string rating);
    }

    public class RatingStrategyFactory : IRatingStrategyFactory
    {
        private readonly IOccupationRepository _repo;

        public RatingStrategyFactory(IOccupationRepository repo)
        {
            _repo = repo;
        }

        public IRatingStrategy Create(string rating)
        {
            var factor = _repo.GetFactorForRating(rating);
            return new SimpleRatingStrategy(factor);
        }
    }

    internal class SimpleRatingStrategy : IRatingStrategy
    {
        private readonly decimal _factor;
        public SimpleRatingStrategy(decimal factor) => _factor = factor;
        public decimal GetFactor() => _factor;
    }
}
