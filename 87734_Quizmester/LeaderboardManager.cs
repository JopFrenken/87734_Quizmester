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
        public List<LeaderboardEntry> GetAllLeaderboardEntries(bool hasCategories, bool isSpecial)
        {
            List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Get leaderboard entries based on hasCategories and isSpecial flags
                string leaderboardQuery = "SELECT * FROM leaderboard WHERE has_categories = @hasCategories AND is_special = @isSpecial";

                using (MySqlCommand command = new MySqlCommand(leaderboardQuery, connection))
                {
                    command.Parameters.AddWithValue("@hasCategories", hasCategories);
                    command.Parameters.AddWithValue("@isSpecial", isSpecial);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LeaderboardEntry entry = new LeaderboardEntry
                            {
                                // Assuming your database schema includes columns like "Username", "Score", etc.
                                Username = reader.GetString("Username"),
                                Score = reader.GetInt32("Score"),
                                // ... other properties
                            };
                            leaderboardEntries.Add(entry);
                        }
                    }
                }
            }

            return leaderboardEntries;
        }


        // Add a new leaderboard entry
        public bool AddLeaderboardEntry(string username, int score, bool has_categories, bool is_special)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Insert a new leaderboard entry
                string insertQuery = "INSERT INTO leaderboard (username, score, has_categories, is_special) VALUES (@username, @score, @has_categories, @is_special)";

                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                {

                    insertCmd.Parameters.AddWithValue("@username", username);
                    insertCmd.Parameters.AddWithValue("@score", score);
                    insertCmd.Parameters.AddWithValue("@has_categories", has_categories);
                    insertCmd.Parameters.AddWithValue("@is_special", is_special);

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    // Registration successful if rowsAffected > 0
                    return rowsAffected > 0;
                }
            }
        }
    }
}
