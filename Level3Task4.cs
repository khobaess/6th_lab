using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Mail;
using System.Runtime.ExceptionServices;
using System.Windows.Markup;

class HelloWorld
{
    struct Student
    {
        public string Surname;
        public double Marks;
        public Student(string Surname, double Marks)
        {
            this.Surname = Surname;
            this.Marks = Marks;   
        }
    }
    struct Group
    {
        public string GroupName;
        public int KollvoStudents;
        public Student[] Students;
        public Group(string GroupName, int KollvoStudents, Student[] students)
        {
            this.GroupName = GroupName;
            this.KollvoStudents = KollvoStudents;
            this.Students = students;
        }
    }
    static int Main()
    {
        Console.WriteLine("Enter the number of Group: ");
        int n;
        int.TryParse(Console.ReadLine(), out n);
        if (n <= 0) { Console.WriteLine("Incorrect data!!!"); return 0; }
        Group[] Gropus = new Group[n];
        for (int i = 0; i < n; i++) // Вводит группу
        {
            Console.WriteLine("Enter the name of Group number " + (i + 1) + ":");
            string GroupName = Console.ReadLine();
            Console.WriteLine("Enter the number of sportsman on group - " + GroupName + ": ");
            int p;
            int.TryParse(Console.ReadLine(), out p);
            if (p <= 0) { Console.WriteLine("Incorrect data!!!"); return 0; }
            Student[] student = new Student[p];
            double[] sredmars = new double[p];
            for (int j = 0; j < p; j++) //Вводит студента
            {
                Console.WriteLine("Enter the surname of student number " + (j + 1) + ":");
                string surname = Console.ReadLine();
                Console.WriteLine("Enter the result of exams for spotrname - " + surname + ": ");
                double x;
                string line;
                line = Console.ReadLine();
                if (double.TryParse(line, out x) == false) { Console.WriteLine("Incorrect data!!!"); return 0; }
                double.TryParse(line, out x);
                student[j] = new Student(surname, x);
            }
            Gropus[i] = new Group(GroupName, p, student);
        }
        Console.WriteLine("The пeneral summary list:");
        for (int j = 0; j < n; j++)
        {

            List<double> A = new List<double>();
            List<int> B = new List<int>();
            for (int i = 0; i < Gropus[j].KollvoStudents; i++)
            {
                A.Add(Gropus[j].Students[i].Marks);
            }
            for (int i = 0; i < Gropus[j].KollvoStudents; i++)
            {
                for (int l = 0; l < Gropus[j].KollvoStudents; l++)
                {
                    if (A[l] == A.Max()) { B.Add(l); A[l] = A.Min() - 1; }
                }
            }
            Console.WriteLine("The list of TOP of Group <" + Gropus[j].GroupName + ">: ");
            for (int i = 0; i < Gropus[j].KollvoStudents; i++)
            {
                Console.WriteLine(Gropus[j].Students[B[i]].Surname + " " + Gropus[j].Students[B[i]].Marks);
            }
        }
        return 0;
    }
}
