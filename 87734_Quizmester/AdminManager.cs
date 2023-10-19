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

        // edit user's username and password
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

        // makes user admin
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

        #region question functions
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

        // adds question
        public bool AddQuestion(string question, string answer1, string answer2, string answer3, string answer4, string correctAnswer, string category)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Check if the question already exists in the database
                string checkQuery = "SELECT COUNT(*) FROM questions WHERE question = @question";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@question", question);
                    int existingQuestionCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existingQuestionCount > 0)
                    {
                        // Question with the same text already exists
                        return false;
                    }
                }

                // Insert the new question into the database
                string insertQuery = "INSERT INTO questions (question, answer_1, answer_2, answer_3, answer_4, correct_answer, category) VALUES (@question, @answer1, @answer2, @answer3, @answer4, @correctAnswer, @category)";
                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@question", question);
                    insertCmd.Parameters.AddWithValue("@answer1", answer1);
                    insertCmd.Parameters.AddWithValue("@answer2", answer2);
                    insertCmd.Parameters.AddWithValue("@answer3", answer3);
                    insertCmd.Parameters.AddWithValue("@answer4", answer4);
                    insertCmd.Parameters.AddWithValue("@correctAnswer", correctAnswer);
                    insertCmd.Parameters.AddWithValue("@category", category);

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    // Check if the insertion was successful
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeleteQuestion(string question)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Check if the question exists in the database
                string checkQuery = "SELECT COUNT(*) FROM questions WHERE question = @question";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@question", question);
                    int existingQuestionCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existingQuestionCount == 0)
                    {
                        // Question with the specified text does not exist
                        return false;
                    }
                }

                // Delete the question from the database
                string deleteQuery = "DELETE FROM questions WHERE question = @question";
                using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection))
                {
                    deleteCmd.Parameters.AddWithValue("@question", question);
                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    // Check if the deletion was successful
                    return rowsAffected > 0;
                }
            }
        }

        public bool EditQuestion(string oldQuestionText, string newQuestionText, string newAnswer1, string newAnswer2, string newAnswer3, string newAnswer4, string newCorrectAnswer, string newCategory)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Check if the old question exists in the database
                string checkQuery = "SELECT COUNT(*) FROM questions WHERE question = @oldQuestionText";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@oldQuestionText", oldQuestionText);
                    int existingQuestionCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existingQuestionCount == 0)
                    {
                        // Question with the old text does not exist
                        return false;
                    }
                }

                // Update the question in the database
                string updateQuery = "UPDATE questions SET question = @newQuestionText, answer_1 = @newAnswer1, answer_2 = @newAnswer2, answer_3 = @newAnswer3, answer_4 = @newAnswer4, correct_answer = @newCorrectAnswer, category = @newCategory WHERE question = @oldQuestionText";
                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, connection))
                {
                    updateCmd.Parameters.AddWithValue("@newQuestionText", newQuestionText);
                    updateCmd.Parameters.AddWithValue("@newAnswer1", newAnswer1);
                    updateCmd.Parameters.AddWithValue("@newAnswer2", newAnswer2);
                    updateCmd.Parameters.AddWithValue("@newAnswer3", newAnswer3);
                    updateCmd.Parameters.AddWithValue("@newAnswer4", newAnswer4);
                    updateCmd.Parameters.AddWithValue("@newCorrectAnswer", newCorrectAnswer);
                    updateCmd.Parameters.AddWithValue("@newCategory", newCategory);
                    updateCmd.Parameters.AddWithValue("@oldQuestionText", oldQuestionText);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    // Check if the update was successful
                    return rowsAffected > 0;
                }
            }
        }

        // In the AdminManager class
        public Question GetQuestionByQuestionText(string questionText)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM questions WHERE question = @questionText";

                using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, connection))
                {
                    selectCmd.Parameters.AddWithValue("@questionText", questionText);

                    using (MySqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Question question = new Question
                            {
                                QuestionText = reader.GetString("question"),
                                Answer1 = reader.GetString("answer_1"),
                                Answer2 = reader.GetString("answer_2"),
                                Answer3 = reader.GetString("answer_3"),
                                Answer4 = reader.GetString("answer_4"),
                                CorrectAnswer = reader.GetString("correct_answer"),
                                Category = reader.GetString("category")
                            };

                            return question;
                        }
                        else
                        {
                            // Question with the specified text does not exist
                            return null;
                        }
                    }
                }
            }
        }


        #endregion
    }
}
