using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _87734_Quizmester
{
    class CategoryManager
    {
        // variables
        private string connectionString;

        // constructor
        public CategoryManager(string c_connectionString)
        {
            connectionString = c_connectionString;
        }

        // methods
        public List<Category> GetTwoCategories()
        {
            List<Category> categories = new List<Category>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // prevents repeat
                string categoryQuery = "SELECT DISTINCT category " +
                      "FROM questions " +
                      "ORDER BY RAND() " +
                      "LIMIT 2;";

                MySqlCommand command = new MySqlCommand(categoryQuery, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string categoryName = reader.GetString("category");
                        Category category = new Category
                        {
                            CategoryName = categoryName
                        };

                        categories.Add(category);
                    }
                }
            }

            return categories;
        }
    }
}
