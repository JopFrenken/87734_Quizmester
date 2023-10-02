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

            using (MySqlConnection connection = new MySqlConnection(connectionString)
            {
                // verder hier
            }
        }
    }
}
