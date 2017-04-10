using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Question
    {
        public  int QuestionID { get; set; }
        public string QuestionType { get; set; }
        public string QuestionText {get; set; }
        public string Answer {get;set;}
        public string CorrectAnswer { get; set; }
        private bool isLoaded = false;
        private List<Question> AllQ = new List<Question>();


       public List<Question> LoadQuestions()
        {

            if (!isLoaded)
            {

                List<string[]> rows = new List<string[]>();

                using (StreamReader reader = File.OpenText("C:\\PythonPrograms\\lc101\\csharp-exercises\\Quiz\\Quiz\\Questions.csv"))
                {
                    while (reader.Peek() >= 0)
                    {
                        string line = reader.ReadLine();
                        string[] rowArrray = CSVRowToStringArray(line);
                        if (rowArrray.Length > 0)
                        {
                            rows.Add(rowArrray);
                        }
                    }
                }

                // Remove headers
                string[] headers = rows[0];
                rows.Remove(headers);

                
                // Parse each row array into a more friendly Dictionary
                foreach (string[] row in rows)
                {
                    Question q = new Question();
                        
                    for (int i = 0; i < headers.Length; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                q.QuestionID = Int16.Parse(row[i]);
                                break;
                            case 1:
                                q.QuestionText = row[i];
                                break;
                            case 2:
                                q.QuestionType = row[i];
                                break;
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                                q.Answer = q.Answer + "," +  row[i];
                                break;
                            case 7:
                                q.CorrectAnswer = row[i];
                                break;
                        }
                    }
                    AllQ.Add(q);
                }
            }
            return AllQ;
        }

        /*
         * Parse a single line of a CSV file into a string array
         */
        private static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
        {
            bool isBetweenQuotes = false;
            StringBuilder valueBuilder = new StringBuilder();
            List<string> rowValues = new List<string>();

            // Loop through the row string one char at a time
            foreach (char c in row.ToCharArray())
            {
                if ((c == fieldSeparator && !isBetweenQuotes))
                {
                    rowValues.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
                else
                {
                    if (c == stringSeparator)
                    {
                        isBetweenQuotes = !isBetweenQuotes;
                    }
                    else
                    {
                        valueBuilder.Append(c);
                    }
                }
            }

            // Add the final value
            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        }

    }
    //class Programs

    //{
    //    static void Main(string[])
    //    {
    //        Question myques = new Question();

    //        myques.Questiontext = "What is the color of the sky?";

    //        myques.Answer[0] = "Red";
    //        myques.Answer[1] = "yellow";
    //        myques.Answer[2] = "blue";
    //        myques.Answer[3] = "green";
    //        myques.CorrectAnswer = 2;

    //        Console.WriteLine("{0} {1} {2} {3}"),

    //        Console.ReadLine();
    //    }

    //}


}
