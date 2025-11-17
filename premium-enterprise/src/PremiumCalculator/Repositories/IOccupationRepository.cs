using System.Collections.Generic;

namespace PremiumCalculator.Repositories
{
    public interface IOccupationRepository
    {
        IReadOnlyDictionary<string, string> GetOccupations();
        decimal GetFactorForRating(string rating);
        string GetRatingForOccupation(string occupation);
    }
}
