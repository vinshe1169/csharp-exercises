using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Question> AllQ;
            Question q = new Question();
            AllQ = q.LoadQuestions();
            int correctanswers = 0;

            foreach (Question qu in AllQ)
            {
                Console.WriteLine("Question " + qu.QuestionID);
                Console.WriteLine(qu.QuestionText);
                Console.WriteLine(qu.Answer);
                Console.ReadLine();
                
            }


        }
    }
}
