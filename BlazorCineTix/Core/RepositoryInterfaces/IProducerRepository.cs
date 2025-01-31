using Core.Entities;

namespace Core.RepositoryInterfaces;

public interface IProducerRepository
{
    //Create
    void Add(Producer producer);

    //Read
    Producer GetById(int id);
    IEnumerable<Producer> GetAll();
    IEnumerable<Movie> GetAllMoviesByProducer(int id);
    
    //Update
    void Update(Producer producer);
    
    //Delete
    void Delete(int id);
}