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
        private static List<int> usedQuestionIds;

        public QuestionManager(string c_connectionString, string c_category)
        {
            connectionString = c_connectionString;
            category = c_category;
            usedQuestionIds = new List<int>();
        }

        public List<Question> GetRandomQuestions()
        {
            List<Question> questions = new List<Question>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Get random questions based on the specified category and limit to 5 questions
                string questionQuery = "SELECT * FROM questions WHERE category = @Category";

                // extra sql to make sure there are no repeated questions
                if (usedQuestionIds.Any())
                {
                    questionQuery += " AND id NOT IN (" + string.Join(",", usedQuestionIds) + ")";
                }

                questionQuery += " ORDER BY RAND() LIMIT 5";
                MySqlCommand command = new MySqlCommand(questionQuery, connection);
                command.Parameters.AddWithValue("@Category", category);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int questionId = reader.GetInt32("id");
                        usedQuestionIds.Add(questionId); // Add the used question ID to the list

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
    }
}
