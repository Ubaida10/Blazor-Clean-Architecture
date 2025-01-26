using Core.Entities;

namespace Application.ServicesInterfaces;

public interface IActorService
{
    void AddActor(Actor actor);
    void UpdateActor(Actor actor);
    Actor GetActorById(int id);
    IEnumerable<Actor> GetAllActors();
    void DeleteActor(int id);
}