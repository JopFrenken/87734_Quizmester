using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _87734_Quizmester
{
    class RegisterManager
    {
        // variables
        private string connectionString;

        // constructor
        public RegisterManager(string c_connectionString)
        {
            connectionString = c_connectionString;
        }

        // methods
        public bool RegisterUser(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // check if username exists already
                string checkUsernameQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                using (MySqlCommand checkUsernameCmd = new MySqlCommand(checkUsernameQuery, connection))
                {
                    checkUsernameCmd.Parameters.AddWithValue("@username", username);
                    int count = Convert.ToInt32(checkUsernameCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        // Username already exists, registration failed
                        return false;
                    }
                }

                // if username doesn't exist proceed
                string insertQuery = "INSERT INTO users (username, password) VALUES (@username, @password)";
                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@password", password);

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    // Registration successful if rowsAffected > 0
                    return rowsAffected > 0;
                }
            }
        }
    }
}
