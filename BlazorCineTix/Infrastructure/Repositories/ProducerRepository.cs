using Core.Entities;
using Core.RepositoryInterfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories;

public class ProducerRepository : GenericRepository<Producer>, IProducerRepository
{ 
    public ProducerRepository() : base()
    {
    }
    
    public IEnumerable<Movie> GetAllMoviesByProducer(int id)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = @"
            SELECT m.* 
            FROM Movies m 
            JOIN MovieActors ma ON m.Id = ma.MovieId 
            WHERE ma.MovieId = @ProducerId";

            // Use Dapper to map the result directly into a list of Movie objects.
            return connection.Query<Movie>(query, new { ProducerId = id });
        }
    }

}