using Core.RepositoryInterfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected readonly string ConnectionString;

        public GenericRepository()
        {
            ConnectionString = @"Server=(localdb)\MSSQLLocalDB";
        }

        public IEnumerable<T> GetAll()
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            string query = $"SELECT * FROM {typeof(T).Name}s";
            return connection.Query<T>(query).ToList();
        }

        public T GetById(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            string query = $"SELECT * FROM {typeof(T).Name}s WHERE Id = @Id";
            return connection.QuerySingleOrDefault<T>(query, new { Id = id });
        }

        public void Add(T entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            string query = GenerateInsertQuery(entity);
            connection.Execute(query, entity);
        }

        public void Update(T entity)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            string query = GenerateUpdateQuery(entity);
            connection.Execute(query, entity);
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            string query = $"DELETE FROM {typeof(T).Name}s WHERE Id = @Id";
            connection.Execute(query, new { Id = id });
        }

        private string GenerateInsertQuery(T entity)
        {
            var properties = typeof(T).GetProperties().Where(p => p.Name != "Id").ToArray();
            string columnNames = string.Join(", ", properties.Select(p => p.Name));
            string parameterNames = string.Join(", ", properties.Select(p => $"@{p.Name}"));
            return $"INSERT INTO {typeof(T).Name}s ({columnNames}) VALUES ({parameterNames})";
        }

        private string GenerateUpdateQuery(T entity)
        {
            var properties = typeof(T).GetProperties().Where(p => p.Name != "Id").ToArray();
            string setClause = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
            return $"UPDATE {typeof(T).Name}s SET {setClause} WHERE Id = @Id";
        }
    }
}
