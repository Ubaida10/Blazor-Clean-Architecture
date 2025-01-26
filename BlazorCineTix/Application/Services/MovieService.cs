using Application.ServicesInterfaces;
using Core.Data;
using Core.Entities;
using Core.RepositoryInterfaces;

namespace Application.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public void AddMovie(NewMovie movie)
    {
        _movieRepository.Add(movie);
    }

    public void UpdateMovie(NewMovie movie)
    {
        _movieRepository.Update(movie);
    }

    public List<Movie> GetMovieByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Search name cannot be null or empty", nameof(name));
        }

        try
        {
            return _movieRepository.GetMovieByName(name);
        }
        catch (Exception ex)
        {
            // Log the error here
            throw new ApplicationException("An error occurred while fetching the movies.", ex);
        }
    }

    
    public Movie GetMovieById(int id)
    {
        return _movieRepository.GetById(id);
    }

    public IEnumerable<Movie> GetAllMovies()
    {
        return _movieRepository.GetAll();
    }

    public void DeleteMovie(int id)
    {
        _movieRepository.Delete(id);
    }
}