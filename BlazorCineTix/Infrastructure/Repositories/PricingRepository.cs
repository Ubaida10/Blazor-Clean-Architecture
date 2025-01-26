using Core.RepositoryInterfaces;

namespace Infrastructure.Repositories;

public class PricingRepository : IPricingRepository
{
    public decimal GetPrice(int movieId, DateTime showTime)
    {
        throw new NotImplementedException();
    }
}