using Core.Entities;

namespace Core.Interfaces;

public interface ICinemaRepository
{
    //Create
    void AddCinema(Cinema cinema);

    //Read
    Cinema GetCinemaById(int id);
    IEnumerable<Cinema> GetAllCinemas();
    IEnumerable<Movie>GetAllMoviesInACinema(int id);
    
    //Update
    void UpdateCinema(Cinema cinema);
    
    //Delete
    void DeleteCinema(Cinema cinema);
}