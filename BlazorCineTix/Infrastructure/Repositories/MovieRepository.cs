using Core.Data;
using Core.Entities;
using Core.RepositoryInterfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository():base()
    {
    }

    public void Add(NewMovie movie)
{
    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
        string query = @"
            INSERT INTO Movies 
            (Title, Synopsis, Duration, ReleaseDate, Price, ImageUrl, RottenTomatoScore, Genre, ProducerID, ActorID, PortraitUrl) 
            VALUES 
            (@Title, @Synopsis, @Duration, @ReleaseDate, @Price, @ImageUrl, @RottenTomatoScore, @Genre, @ProducerID, @ActorID, @PortraitUrl);
            SELECT SCOPE_IDENTITY()";

        connection.Execute(query, new
        {
            movie.Title,
            movie.Synopsis,
            movie.Duration,
            movie.ReleaseDate,
            movie.Price,
            movie.ImageUrl,
            movie.RottenTomatoScore,
            movie.Genre,
            movie.ProducerId,
            movie.ActorId,
            movie.PortraitUrl
        });
    }
}

public List<Movie> GetMovieByName(string name)
{
    if (string.IsNullOrEmpty(name))
    {
        throw new ArgumentException("Search name cannot be null or empty", nameof(name));
    }

    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
        string query = @"SELECT * FROM Movies WHERE Title LIKE @name";

        // Use the LIKE operator to search for titles containing the 'name' parameter
        return connection.Query<Movie>(query, new { name = "%" + name + "%" }).ToList();
    }
}

public void Update(NewMovie movie)
{
    using (SqlConnection connection = new SqlConnection(ConnectionString))
    {
        string query = @"
            UPDATE Movies 
            SET 
                Title = @Title, 
                Synopsis = @Synopsis, 
                Duration = @Duration, 
                ReleaseDate = @ReleaseDate, 
                Price = @Price, 
                ImageUrl = @ImageUrl, 
                RottenTomatoScore = @RottenTomatoScore, 
                Genre = @Genre, 
                ProducerID = @ProducerID, 
                ActorID = @ActorID, 
                PortraitUrl = @PortraitUrl 
            WHERE Id = @Id";

        connection.Execute(query, new
        {
            movie.Id,
            movie.Title,
            movie.Synopsis,
            movie.Duration,
            movie.ReleaseDate,
            movie.Price,
            movie.ImageUrl,
            movie.RottenTomatoScore,
            movie.Genre,
            movie.ProducerId,
            movie.ActorId,
            movie.PortraitUrl
        });
    }
}

}