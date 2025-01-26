using System.Collections;
using Core.Entities;


namespace Core.RepositoryInterfaces;

public interface IActorRepository
{
    //Create
    void Add(Actor actor);

    //Read
    Actor GetById(int id);
    IEnumerable<Actor> GetAll();
    IEnumerable<Movie>GetMoviesByActor(int id);
    
    //Update
    void Update(Actor actor);
    
    //Delete
    void Delete(int id);
}