namespace Core.RepositoryInterfaces;

public interface IPricingRepository
{
    decimal GetPrice(int movieId, DateTime showTime);
}