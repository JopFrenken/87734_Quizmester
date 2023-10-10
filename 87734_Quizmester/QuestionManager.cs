using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace _87734_Quizmester
{
    class QuestionManager
    {
        private string connectionString;
        private string category;

        public QuestionManager(string c_connectionString, string c_category)
        {
            connectionString = c_connectionString;
            category = c_category;
        }

        public List<Question> GetRandomQuestions()
        {
            List<Question> questions = new List<Question>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Get random questions
                string questionQuery = "SELECT * FROM questions";


                MySqlCommand command = new MySqlCommand(questionQuery, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int questionId = reader.GetInt32("id");

                        // Create a Question object for each row in the database
                        Question question = new Question
                        {
                            QuestionText = reader.GetString("question"),
                            Answer1 = reader.GetString("answer_1"),
                            Answer2 = reader.GetString("answer_2"),
                            Answer3 = reader.GetString("answer_3"),
                            Answer4 = reader.GetString("answer_4"),
                            CorrectAnswer = reader.GetString("correct_answer")
                        };

                        questions.Add(question);
                    }
                }
            }

            return questions;
        }

        public List<Question> GetQuestionsByCategory()
        {
            List<Question> questions = new List<Question>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Get random questions based on the specified category and limit to 5 questions
                string questionQuery = "SELECT * FROM questions WHERE category = @Category AND used = 0 ORDER BY RAND() LIMIT 5";

                MySqlCommand command = new MySqlCommand(questionQuery, connection);
                command.Parameters.AddWithValue("@Category", category);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int questionId = reader.GetInt32("id");

                        // Create a Question object for each row in the database
                        Question question = new Question
                        {
                            QuestionText = reader.GetString("question"),
                            Answer1 = reader.GetString("answer_1"),
                            Answer2 = reader.GetString("answer_2"),
                            Answer3 = reader.GetString("answer_3"),
                            Answer4 = reader.GetString("answer_4"),
                            CorrectAnswer = reader.GetString("correct_answer")
                        };

                        // Mark the question as used in the database
                        MarkQuestionAsUsed(questionId);

                        questions.Add(question);
                    }
                }
            }

            return questions;
        }

        private void MarkQuestionAsUsed(int questionId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE questions SET used = 1 WHERE id = @QuestionId";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@QuestionId", questionId);

                updateCommand.ExecuteNonQuery();
            }
        }

        public void ResetQuiz()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Reset the "used" status of all questions in the database
                string resetQuery = "UPDATE questions SET used = 0";
                MySqlCommand resetCommand = new MySqlCommand(resetQuery, connection);

                resetCommand.ExecuteNonQuery();
            }
        }
    }
}
