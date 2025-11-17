using System.Collections.Generic;

namespace PremiumCalculator.Repositories
{
    public class InMemoryOccupationRepository : IOccupationRepository
    {
        private readonly Dictionary<string, string> _occupationRating = new()
        {
            { "Cleaner", "Light Manual" },
            { "Doctor", "Professional" },
            { "Author", "White Collar" },
            { "Farmer", "Heavy Manual" },
            { "Mechanic", "Heavy Manual" },
            { "Florist", "Light Manual" },
            { "Other", "Heavy Manual" }
        };

        private readonly Dictionary<string, decimal> _ratingFactors = new()
        {
            { "Professional", 1.50m },
            { "White Collar", 2.25m },
            { "Light Manual", 11.50m },
            { "Heavy Manual", 31.75m }
        };

        public IReadOnlyDictionary<string, string> GetOccupations() => _occupationRating;

        public decimal GetFactorForRating(string rating)
        {
            if (!_ratingFactors.ContainsKey(rating))
                throw new KeyNotFoundException("Rating not found.");

            return _ratingFactors[rating];
        }

        public string GetRatingForOccupation(string occupation)
        {
            if (!_occupationRating.ContainsKey(occupation))
                throw new KeyNotFoundException("Occupation not found.");

            return _occupationRating[occupation];
        }
    }
}
