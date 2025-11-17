using PremiumCalculator.Models;

namespace PremiumCalculator.Services
{
    public interface IPremiumService
    {
        PremiumResult CalculatePremium(MemberInput input);
    }
}
