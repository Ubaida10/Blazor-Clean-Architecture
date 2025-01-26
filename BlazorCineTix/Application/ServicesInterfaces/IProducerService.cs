using Core.Entities;
//using Microsoft.AspNetCore.Http;

namespace Application.ServicesInterfaces;

public interface IProducerService
{
    void AddProducer(Producer producer);
    void UpdateProducer(Producer producer);
    Producer GetProducerById(int id);
    IEnumerable<Producer> GetAllProducers();
    void DeleteProducer(int id);
}