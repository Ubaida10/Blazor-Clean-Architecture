using Application.ServicesInterfaces;
using Core.Entities;
using Core.Interfaces;
using Core.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

public class ProducerService : ServicesInterfaces.IProducerService
{
    private readonly IProducerRepository _producerRepository;

    public ProducerService(IProducerRepository producerRepository)
    {
        _producerRepository = producerRepository;
    }
    public void AddProducer(Producer producer)
    {
        _producerRepository.Add(producer);
    }

    public void UpdateProducer(Producer producer)
    {
        _producerRepository.Update(producer);
    }

    public Producer GetProducerById(int id)
    {
        return _producerRepository.GetById(id);
    }

    public IEnumerable<Producer> GetAllProducers()
    {
        return _producerRepository.GetAll();
    }

    public void DeleteProducer(int id)
    {
        _producerRepository.Delete(id);
    }
}