using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using SB_Onboarding_1.Models;

namespace SB_Onboarding_1.Services
{
    public class StoresDAO : IStoreDataService
    {
        private string connectionString;
        private SqlConnection? _connection;
        //connection string don't put in the code, put in appsettings.json

        // constructor
        public StoresDAO(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<StoreModel> GetAllStores()
        {
            List<StoreModel> foundStores = new List<StoreModel>();
            string sqlStatement = "SELECT * FROM dbo.MockStores";

            using (_connection = new SqlConnection { ConnectionString = connectionString })
            {
                SqlCommand command = new SqlCommand(sqlStatement, _connection);

                try
                {
                    _connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundStores.Add(
                            new StoreModel
                            {
                                Id = (int)reader[0],
                                Name = (string)reader[1],
                                Address = (string)reader[2],
                                Revenue = (decimal)reader[3],
                                Description = (string)reader[4]
                            }
                        );
                    }
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return foundStores;



        }

        public StoreModel GetStoreById(int id)
        {
            StoreModel foundStore = null;
            string sqlStatement = "SELECT * FROM dbo.MockStores WHERE Id = @Id";

            using (_connection = new SqlConnection { ConnectionString = connectionString })
            {
                SqlCommand command = new SqlCommand(sqlStatement, _connection);
                command.Parameters.AddWithValue("@Id", id); 

                try
                {
                    _connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundStore =
                            new StoreModel
                            {
                                Id = (int)reader[0],
                                Name = (string)reader[1],
                                Address = (string)reader[2],
                                Revenue = (decimal)reader[3],
                                Description = (string)reader[4]
                            };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return foundStore;
        }

        public List<StoreModel> SearchStores(string searchTerm)
        {
            List<StoreModel> foundStores = new List<StoreModel>();
            string sqlStatement = "SELECT * FROM dbo.MockStores WHERE Description LIKE @Name";

            using (_connection = new SqlConnection { ConnectionString = connectionString })
            {
                SqlCommand command = new SqlCommand(sqlStatement, _connection);
                command.Parameters.AddWithValue("@Name", '%'+searchTerm+'%'); //wildcard %symbols make it so you can search within substrings also

                try
                {
                    _connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundStores.Add(
                            new StoreModel
                            {
                                Id = (int)reader[0],
                                Name = (string)reader[1],
                                Address = (string)reader[2],
                                Revenue = (decimal)reader[3],
                                Description = (string)reader[4]
                            }
                        );
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return foundStores;
        }

        /* CREATE */
        public int Insert(StoreModel store)
        {
            int commandOutput = -1;
            //insert at the beginning by default
            string sqlStatement = "INSERT INTO dbo.MockStores VALUES (@Name, @Address, @Revenue, @Description)";
            using (_connection = new SqlConnection { ConnectionString = connectionString })
            {
                SqlCommand command = new SqlCommand(sqlStatement, _connection);
                command.Parameters.AddWithValue("@Name", store.Name);
                command.Parameters.AddWithValue("@Address", store.Address);
                command.Parameters.AddWithValue("@Revenue", store.Revenue);
                command.Parameters.AddWithValue("@Description", store.Description);


                try
                {
                    _connection.Open();

                    commandOutput = Convert.ToInt32(command.ExecuteNonQuery()); // returns the first column of the row (the Id)

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return commandOutput;
        }

        /* UPDATE */
        public int Update(StoreModel store)
        {
            int newIDNum = -1;
            string sqlStatement = "UPDATE dbo.MockStores SET Name = @Name, Address = @Address, Revenue = @Revenue, Description = @Description WHERE Id = @Id";
            // convert this into a stored procedure!
            // add validation also
            using (_connection = new SqlConnection { ConnectionString = connectionString })
            {
                SqlCommand command = new SqlCommand(sqlStatement, _connection);
                command.Parameters.AddWithValue("@Id", store.Id);
                command.Parameters.AddWithValue("@Name", store.Name);
                command.Parameters.AddWithValue("@Address", store.Address);
                command.Parameters.AddWithValue("@Revenue", store.Revenue);
                command.Parameters.AddWithValue("@Description", store.Description);

                try
                {
                    _connection.Open();

                    newIDNum = Convert.ToInt32(command.ExecuteScalar()); // returns the first column of the row (the Id)

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return newIDNum;
        }

        /* DELETE */
        public int Delete(StoreModel store)
        {
            int commandOutput = -1;
            string sqlStatement = "DELETE FROM dbo.MockStores WHERE Id = @Id";

            using (_connection = new SqlConnection { ConnectionString = connectionString })
            {
                SqlCommand command = new SqlCommand(sqlStatement, _connection);
                command.Parameters.AddWithValue("@Id", store.Id);


                try
                {
                    _connection.Open();

                    commandOutput = Convert.ToInt32(command.ExecuteNonQuery()); // returns the first column of the row (the Id)

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return commandOutput;

        }
    }
}
