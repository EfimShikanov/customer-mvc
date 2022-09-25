using CustomerDatalayer.Entities;
using CustomerDatalayer.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace CustomerDatalayer.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, IRepository<Customer>
    {
        public override string TableName => "Customer";

        public Customer Create(Customer customer)
        {
            using var connection = GetConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(
                "INSERT INTO [Customer] (FirstName, LastName, PhoneNumber, Email, TotalPurchasesAmount) " +
                "OUTPUT INSERTED.[CustomerId], INSERTED.[FirstName], INSERTED.[LastName], INSERTED.[PhoneNumber], INSERTED.[Email], INSERTED.[TotalPurchasesAmount] " +
                "VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @TotalPurchasesAmount)", connection);

            command.Parameters.AddRange(new[] {
                new SqlParameter("@FirstName", SqlDbType.NVarChar, 50) { Value = customer.FirstName is { Length: > 0 } ? customer.FirstName : String.Empty },
                new SqlParameter("@LastName", SqlDbType.NVarChar, 50) { Value = customer.LastName },
                new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 15) { Value = customer.PhoneNumber is { Length: > 0 } ? customer.PhoneNumber : DBNull.Value },
                new SqlParameter("@Email", SqlDbType.NVarChar, 50) { Value = customer.Email is { Length: > 0 } ? customer.Email : DBNull.Value },
                new SqlParameter("@TotalPurchasesAmount", SqlDbType.Money) { Value = customer.TotalPurchasesAmount ?? 0 },
            });

            var reader = command.ExecuteReader();
            reader.Read();

            return new Customer(reader);
        }

        public Customer Read(int customerId)
        {
            using var connection = GetConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM [Customer] WHERE CustomerId = @CustomerId", connection);

            command.Parameters.Add(
                new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = customerId
                });

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Customer(reader);
            }

            return null;
        }

        public int Update(Customer customer)
        {
            using var connection = GetConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(
                "UPDATE [Customer] " +
                "SET " +
                "FirstName = @FirstName, " +
                "LastName = @LastName, " +
                "PhoneNumber = @PhoneNumber, " +
                "Email = @Email, " +
                "TotalPurchasesAmount = @TotalPurchasesAmount " +
                "WHERE CustomerId = @CustomerId", connection);

            command.Parameters.AddRange(new[] {
                new SqlParameter("@FirstName", SqlDbType.NVarChar, 50) { Value = customer.FirstName is { Length: > 0 } ? customer.FirstName : String.Empty },
                new SqlParameter("@LastName", SqlDbType.NVarChar, 50) { Value = customer.LastName },
                new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 15) { Value = customer.PhoneNumber is { Length: > 0 } ? customer.PhoneNumber : DBNull.Value },
                new SqlParameter("@Email", SqlDbType.NVarChar, 50) { Value = customer.Email is { Length: > 0 } ? customer.Email : DBNull.Value },
                new SqlParameter("@TotalPurchasesAmount", SqlDbType.Money) { Value = customer.TotalPurchasesAmount ?? 0 },
                new SqlParameter("@CustomerId", SqlDbType.Int) { Value = customer.CustomerId }
            });

            return command.ExecuteNonQuery();
        }

        public int Delete(int customerId)
        {
            using var connection = GetConnection();
            connection.Open();
            
            SqlCommand command = new SqlCommand("DELETE FROM [Notes] WHERE CustomerId = @CustomerId", connection);
            command.Parameters.Add(
                new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = customerId
                });
            command.ExecuteNonQuery();
            
            command = new SqlCommand("DELETE FROM [Address] WHERE CustomerId = @CustomerId", connection);
            command.Parameters.Add(
                new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = customerId
                });
            command.ExecuteNonQuery();
            
            command = new SqlCommand("DELETE FROM [Customer] WHERE CustomerId = @CustomerId", connection);
            command.Parameters.Add(
                new SqlParameter("@CustomerId", SqlDbType.Int)
                {
                    Value = customerId
                });
            return command.ExecuteNonQuery();
            
        }
    }
}
