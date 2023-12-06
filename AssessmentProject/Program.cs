using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentProject2
{
   
    class Program
    {
        static List<Teacher> teachers = new List<Teacher>();
        static string filePath = @"D:\mphasis\Assesmentprojects\Project2\AssessmentProject\ teachers.txt";

        static void AddTeacher()
        {
            Teacher teacher = new Teacher();

            Console.Write("Enter ID: ");
            teacher.ID = int.Parse(Console.ReadLine());

            Console.Write("Enter Name : ");
            teacher.Name = Console.ReadLine();

            Console.Write("Enter Class : ");
            teacher.Class = Console.ReadLine();

            Console.Write("Enter Section : ");
            teacher.Section = Console.ReadLine();

            teachers.Add(teacher);
            Console.WriteLine("Teacher added successfully.");
        }
        static void UpdateTeacher()
        {
            Console.Write("Enter Teacher ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Teacher teacherToUpdate = teachers.Find(t => t.ID == id);

            if (teacherToUpdate != null)
            {
                Console.Write("Enter updated Name: ");
                teacherToUpdate.Name = Console.ReadLine();

                Console.Write("Enter updated Class: ");
                teacherToUpdate.Class = Console.ReadLine();

                Console.Write("Enter updated Section: ");
                teacherToUpdate.Section = Console.ReadLine();

                Console.WriteLine("Teacher updated successfully.");
            }
            else
            {
                Console.WriteLine("Teacher is not found.");
            }
        }

        static void DisplayTeachers()
        {
            Console.WriteLine("Teacher Data as follows:");

            foreach (var teacher in teachers)
            {

                Console.WriteLine($"ID : {teacher.ID}");
                Console.WriteLine($"Name : {teacher.Name}" );
                Console.WriteLine($"Class : {teacher.Class} ");
                Console.WriteLine($"Section :{teacher.Section} ");
            }
        }

        static void LoadData()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    string[] values = line.Split(',');
                    Teacher teacher = new Teacher
                    {
                        ID = int.Parse(values[0]),
                        Name = values[1],
                        Class = values[2],
                        Section = values[3]
                    };

                    teachers.Add(teacher);
                }
            }
        }
        static void SaveData()
        {
            List<string> lines = new List<string>();

            foreach (var teacher in teachers)
            {
                lines.Add(teacher.ToString());
            }

            File.WriteAllLines(filePath, lines);
        }
        static void Main(string[] args)
        {
            string Choice;
            LoadData();

            do
            {
                Console.WriteLine("1. Add Teacher\n2. Update Teacher\n3. Display All Teachers\n 4. Exit");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddTeacher();
                        break;

                    case 2:
                        UpdateTeacher();
                        break;

                    case 3:
                        DisplayTeachers();
                        break;

                    case 4:
                        SaveData();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
                Console.WriteLine("Do you Continue  yes/no?");
                Choice = Console.ReadLine();
            }
            while (Choice == "yes");
            Console.ReadKey();
        }   
    } 
}
