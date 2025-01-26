using Core.Data;
using Core.Entities;

namespace Core.RepositoryInterfaces;

public interface IMovieRepository
{
    //Create
    void Add(NewMovie movie);

    //Read
    Movie GetById(int id);
    IEnumerable<Movie> GetAll();
    
    //Update
    void Update(NewMovie movie);
    
    //Delete
    void Delete(int id);
    
    List<Movie> GetMovieByName(string name);
}