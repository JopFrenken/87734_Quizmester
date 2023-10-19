using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _87734_Quizmester
{
    class Question
    {
        // The text of the question
        public string QuestionText { get; set; }

        // The first answer choice
        public string Answer1 { get; set; }

        // The second answer choice
        public string Answer2 { get; set; }

        // The third answer choice
        public string Answer3 { get; set; }

        // The fourth answer choice
        public string Answer4 { get; set; }

        // The correct answer to the question
        public string CorrectAnswer { get; set; }

        // The category of the question
        public string Category { get; set; }
    }
}
