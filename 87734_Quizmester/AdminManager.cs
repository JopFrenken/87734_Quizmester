using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _87734_Quizmester
{
    class AdminManager
    {
        // variables
        private string connectionString;

        // constructor
        public AdminManager(string c_connectionString)
        {
            connectionString = c_connectionString;
        }

        // methods

        // get all questions
        public List<Question> GetAllQuestions()
        {
            List<Question> questions = new List<Question>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM questions";

                using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection))
                {
                    using (MySqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Question entry = new Question
                            {
                                QuestionText = reader.GetString("question")
                            };

                            questions.Add(entry);
                        }
                    }
                }
            }
            // sort alphabetically
            questions = questions.OrderBy(u => u.QuestionText).ToList();

            return questions;
        }

        #region user functions
        // get all users
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM users";

                using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection))
                {
                    using (MySqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User entry = new User
                            {
                                Username = reader.GetString("username"),
                                Password = reader.GetString("password")
                            };

                            users.Add(entry);
                        }
                    }
                }
            }
            // sort alphabetically
            users = users.OrderBy(u => u.Username).ToList();

            return users;
        }
        // adds user 
        public bool AddUser(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Check if the username already exists in the database
                string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@username", username);
                    int existingUserCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existingUserCount > 0)
                    {
                        // User with the same username already exists
                        return false;
                    }
                }

                // Insert the new user into the database
                string insertQuery = "INSERT INTO users (username, password) VALUES (@username, @password)";
                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@password", password);
                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    // Check if the insertion was successful
                    return rowsAffected > 0;
                }
            }
        }

        // deletes user
        public bool DeleteUser(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Check if the username exists in the database
                string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@username", username);
                    int existingUserCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existingUserCount == 0)
                    {
                        // User with the specified username does not exist
                        return false;
                    }
                }

                // Delete the user from the database
                string deleteQuery = "DELETE FROM users WHERE username = @username";
                using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection))
                {
                    deleteCmd.Parameters.AddWithValue("@username", username);
                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    // Check if the deletion was successful
                    return rowsAffected > 0;
                }
            }
        }

        // Edit user's username and password
        public bool EditUser(string oldUsername, string newUsername, string newPassword)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Check if the old username exists in the database
                string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @oldUsername";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@oldUsername", oldUsername);
                    int existingUserCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existingUserCount == 0)
                    {
                        // User with the old username does not exist
                        return false;
                    }
                }

                // Update the user's username and password in the database
                string updateQuery = "UPDATE users SET username = @newUsername, password = @newPassword WHERE username = @oldUsername";
                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                {
                    updateCmd.Parameters.AddWithValue("@newUsername", newUsername);
                    updateCmd.Parameters.AddWithValue("@newPassword", newPassword);
                    updateCmd.Parameters.AddWithValue("@oldUsername", oldUsername);
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    // Check if the update was successful
                    return rowsAffected > 0;
                }
            }
        }

        public bool makeAdmin(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Check if user is already admin
                string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @username AND admin = 1";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@username", username);
                    int existingUserCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existingUserCount != 0)
                    {
                        // User is already admin
                        return false;
                    }
                }

                // Update the user's admin status
                string updateQuery = "UPDATE users SET admin = 1 WHERE username = @username";
                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                {
                    updateCmd.Parameters.AddWithValue("@username", username);
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    // Check if the update was successful
                    return rowsAffected > 0;
                }
            }
        }

        #endregion
    }
}
