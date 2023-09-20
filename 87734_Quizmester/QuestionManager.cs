using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _87734_Quizmester
{
    class QuestionManager
    {
        // variables
        private string connectionString;

        // constructor
        public QuestionManager(string c_connectionString)
        {
            connectionString = c_connectionString;
        }

        // methods
        public List<Question> GetAllQuestions()
        {
            List<Question> questions = new List<Question>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Get all questions
                string questionQuery = "SELECT * FROM questions";
                MySqlCommand command = new MySqlCommand(questionQuery, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
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
