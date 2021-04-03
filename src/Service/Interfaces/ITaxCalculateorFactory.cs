using HireMe.Domain.Enums;

namespace HireMe.Service.Interfaces
{
    public interface ITaxCalculateorFactory
    {
        ITaxCalculator Create(SubscriptionLevel subscriptionLevel);
    }
}
