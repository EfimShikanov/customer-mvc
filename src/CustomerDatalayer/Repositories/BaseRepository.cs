using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CustomerDatalayer.Repositories
{
    public abstract class BaseRepository<TEntity>
    {
        public abstract string TableName { get; }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Server=WIN-I3MNAN83JES\\SQLEXPRESS;Database=CustomerLib_Shikanov;Trusted_Connection=True;");
        }

        private TEntity GetTEntityInstance(SqlDataReader reader)
        {
            return (TEntity)Activator.CreateInstance(typeof(TEntity), reader);
        }

        public List<TEntity> GetAll()
        {
            using var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand(
                $"SELECT * " +
                $"FROM [{TableName}]", connection);
            
            SqlDataReader reader = command.ExecuteReader();

            List<TEntity> customers = new List<TEntity>();
            while (reader.Read())
                customers.Add(GetTEntityInstance(reader));

            return customers;
        }
    }
}
