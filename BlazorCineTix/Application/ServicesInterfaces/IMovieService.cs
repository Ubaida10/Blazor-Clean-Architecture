using Core.Data;
using Core.Entities;
//using Microsoft.AspNetCore.Http;

namespace Application.ServicesInterfaces;

public interface IMovieService
{
    void AddMovie(NewMovie movie);
    void UpdateMovie(NewMovie movie);
    List<Movie> GetMovieByName(string name);
    IEnumerable<Movie> GetAllMovies();
    Movie GetMovieById(int id);
    
    void DeleteMovie(int id);
}