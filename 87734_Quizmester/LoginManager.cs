using System;
using MySql.Data.MySqlClient;

class LoginManager
{
    // variables
    private string connectionString;

    // constructor
    public LoginManager(string c_connectionString)
    {
        connectionString = c_connectionString;
    }

    // methods
    public bool Login(string username, string password)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string selectQuery = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";

            // Create a MySqlCommand object to execute the SQL query within the connection context.
            using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection))
            {
                selectCmd.Parameters.AddWithValue("@username", username); // Set the username parameter.
                selectCmd.Parameters.AddWithValue("@password", password); // Set the password parameter.

                // Execute the query
                int count = Convert.ToInt32(selectCmd.ExecuteScalar());
  
                // If count is 1, it means a matching user with the provided username and password exists in the database
                return count == 1;
            }

        }
    }

    // returns true if user is admin
    public bool CheckIfAdmin(string username)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string selectQuery = "SELECT COUNT(*) FROM users WHERE username = @username AND admin = 1";

            using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection))
            {
                selectCmd.Parameters.AddWithValue("@username", username); // Set the username parameter.

                // Execute the query
                int count = Convert.ToInt32(selectCmd.ExecuteScalar());

                // If count is 1, it means a matching user with the provided username and admin=1 exists in the database
                return count == 1;
            }
        }
    }
}
