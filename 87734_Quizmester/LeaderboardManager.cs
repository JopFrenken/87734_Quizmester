using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _87734_Quizmester
{
    class LeaderboardManager
    {
        // variables
        private string connectionString;

        // constructor
        public LeaderboardManager(string c_connectionString)
        {
            connectionString = c_connectionString;
        }

        // methods

        // Get all leaderboard entries
        public List<LeaderboardEntry> GetAllLeaderboardEntries(bool hasCategories)
        {
            List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Get all leaderboard entries
                string leaderboardQuery = "SELECT * FROM leaderboard WHERE has_categories = @hasCategories";
                MySqlCommand command = new MySqlCommand(leaderboardQuery, connection);
                command.Parameters.AddWithValue("@hasCategories", hasCategories);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Create a LeaderboardEntry object for each row in the database
                        LeaderboardEntry entry = new LeaderboardEntry
                        {
                            Username = reader.GetString("username"),
                            Score = reader.GetInt32("score")
                        };

                        leaderboardEntries.Add(entry);
                    }
                }
            }

            return leaderboardEntries;
        }

        // Add a new leaderboard entry
        public bool AddLeaderboardEntry(string username, int score, bool has_categories)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Insert a new leaderboard entry
                string insertQuery = "INSERT INTO leaderboard (username, score, has_categories) VALUES (@username, @score, @has_categories)";

                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                {

                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@score", score);
                    insertCmd.Parameters.AddWithValue("@has_categories", has_categories);

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    // Registration successful if rowsAffected > 0
                    return rowsAffected > 0;
                }
            }
        }
    }
}
