using Core.Entities;
using Core.RepositoryInterfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository() : base()
        {
        }

        public IEnumerable<Movie> GetMoviesByActor(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"SELECT m.* FROM Movies m 
                         JOIN MovieActors ma ON m.Id = ma.MovieId 
                         WHERE ma.ActorId = @ActorId";

                return connection.Query<Movie>(query, new { ActorId = id }).ToList();
            }
        }

    }
}