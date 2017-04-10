using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> students = new Dictionary<int, string>();
            string newStudent;

            Console.WriteLine("Enter your students (or ENTER to finish):");
            do
            {
                Console.Write("name: ");
                newStudent = Console.ReadLine();
                if (newStudent != "")
                {
                    // Get the student's grade
                    Console.Write("ID: ");
                    int newID = int.Parse(Console.ReadLine());
                    if (students.ContainsKey(newID))
                    {
                        Console.WriteLine("This Id already exist");
                    }
                    else
                    {
                        students.Add(newID, newStudent);
                    }

                }
            }
            while (newStudent != "");

            // Print class roster
            Console.WriteLine("\nClass roster:");
            StringBuilder sb;
            sb = new StringBuilder();
            
            foreach (KeyValuePair<int, string> student in students)
            {
                //Console.WriteLine(student.Key + " (" + student.Value + ")");
                sb.AppendLine(student.Key + ":" + student.Value);
                //sb.Append(student.Key + ":" + student.Value);
            }
            Console.WriteLine(sb);

            Console.ReadLine();
        }
    }
}
