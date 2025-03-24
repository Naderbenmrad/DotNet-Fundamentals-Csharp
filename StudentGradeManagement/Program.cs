using System;
using System.Collections.Generic;

namespace StudentGradeManagement
{
    public class Student
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Dictionary<string, double> Grades { get; set; }

        public Student(string name, int id)
        {
            Name = name;
            ID = id;
            Grades = new Dictionary<string, double>();
        }

        public double CalculateAverageGrade()
        {
            if (Grades.Count == 0)
            {
                return 0;
            }

            double sum = 0;
            foreach (double grade in Grades.Values)
            {
                sum += grade;
            }
            return sum / Grades.Count;
        }
    }

    public class StudentGradeManagementSystem
    {
        static Dictionary<int, Student> students = new Dictionary<int, Student>();

        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMenu();
                int choice = GetUserChoice();
                ProcessChoice(choice);
                if (choice == 4)
                {
                    break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nGrade Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Grades");
            Console.WriteLine("3. View Student Record");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
        }

        static int GetUserChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return 0;
            }
        }

        static void ProcessChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    AddGrades();
                    break;
                case 3:
                    ViewStudentRecord();
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
            if (!students.ContainsKey(id))
            {
                students[id] = new Student(name, id);
                Console.WriteLine("Student added successfully.");
            }
            else
            {
                Console.WriteLine("A student with this ID already exists.");
            }
            }
            else
            {
            Console.WriteLine("Invalid ID. Please enter a numeric value.");
            }
        }

        static void AddGrades()
        {
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
            if (students.ContainsKey(id))
            {
                Console.Write("Enter subject name: ");
                string subject = Console.ReadLine();
                Console.Write("Enter grade: ");
                if (double.TryParse(Console.ReadLine(), out double grade))
                {
                students[id].Grades[subject] = grade;
                Console.WriteLine("Grade added successfully.");
                }
                else
                {
                Console.WriteLine("Invalid grade. Please enter a numeric value.");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            }
            else
            {
            Console.WriteLine("Invalid ID. Please enter a numeric value.");
            }
        }

        static void ViewStudentRecord()
        {
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
            if (students.ContainsKey(id))
            {
                Student student = students[id];
                Console.WriteLine($"\nStudent Name: {student.Name}");
                Console.WriteLine($"Student ID: {student.ID}");
                Console.WriteLine("Grades:");
                foreach (var grade in student.Grades)
                {
                Console.WriteLine($"  {grade.Key}: {grade.Value}");
                }
                Console.WriteLine($"Average Grade: {student.CalculateAverageGrade():F2}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            }
            else
            {
            Console.WriteLine("Invalid ID. Please enter a numeric value.");
            }
        }
    }
}