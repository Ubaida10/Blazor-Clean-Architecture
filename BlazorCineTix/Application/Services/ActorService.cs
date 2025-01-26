using Core.Entities;
using Core.Interfaces;
using Core.RepositoryInterfaces;

namespace Application.Services;

public class ActorService : ServicesInterfaces.IActorService
{
    private readonly IActorRepository _actorRepository;
    public ActorService(IActorRepository actorRepository)
    {
        _actorRepository = actorRepository;
    }
    public void AddActor(Actor actor)
    {
        _actorRepository.Add(actor);
    }

    public void UpdateActor(Actor actor)
    {
        _actorRepository.Update(actor);
    }

    public Actor GetActorById(int id)
    {
        return _actorRepository.GetById(id);
    }

    public IEnumerable<Actor> GetAllActors()
    {
        return _actorRepository.GetAll();
    }

    public void DeleteActor(int id)
    {
        _actorRepository.Delete(id);
    }
}