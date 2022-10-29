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
        public double[] Marks;
        public double sredmark;
        public Student(string Surname, double[] Marks, int m)
        {
            this.Surname = Surname;
            this.Marks = Marks;
            double sum = 0;
            for (int i=0; i<m; i++)
            {
                sum = sum + Marks[i];
            }
            this.sredmark = sum / m;
        }
    }
    struct Group
    {
        public string GroupName;
        public int KollvoStudents;
        public double GroupSredmark;
        public Student[] Students;
        public Group(string GroupName, int KollvoStudents, Student[] students)
        {
            this.GroupName = GroupName;
            this.KollvoStudents = KollvoStudents;
            this.Students = students;
            double sum = 0;
            for (int i=0; i<KollvoStudents; i++)
            {
                sum = sum + students[i].sredmark;
            }
            this.GroupSredmark = sum / KollvoStudents;
        }
    }
    static int Main()
    {
        Console.WriteLine("Enter the number of Group: ");
        int n;
        int.TryParse(Console.ReadLine(), out n);
        Console.WriteLine("Enter the number of exams: ");
        int m;
        int.TryParse(Console.ReadLine(), out m);
        if (n <= 0 || m <= 0) { Console.WriteLine("Incorrect data!!!"); return 0; }
        Group[] Gropus = new Group[n];
        for (int i=0; i<n; i++) // ¬водит группу
        {
            Console.WriteLine("Enter the name of Group number " + (i + 1) + ":");
            string GroupName = Console.ReadLine();
            Console.WriteLine("Enter the number of students on group - " + GroupName +": ");
            int p;
            int.TryParse(Console.ReadLine(), out p);
            if (p <= 0) { Console.WriteLine("Incorrect data!!!"); return 0; }
            Student[] student = new Student[p];
            double[] sredmars = new double[p];
            for (int j=0; j<p; j++) //¬водит студента
            {
                double[] marks = new double[m];
                Console.WriteLine("Enter the surname of student number " + (j + 1) + ":");
                string surname = Console.ReadLine();
                string[] line;
                Console.WriteLine("Enter the results of exams for Student - " + surname + ": ");
                while (true)
                {
                    line = Console.ReadLine().Split(" ");
                    if (line.Length != m) { Console.WriteLine("Re-enter the row!"); continue; }
                    else break;
                }
                for (int l = 0; l < m; l++)
                {
                    double x;
                    if (double.TryParse(line[l], out x) == false) { Console.WriteLine("Incorrect data!!!"); return 0; }
                    double.TryParse(line[l], out x);
                    marks[l] = x;
                }
                student[j] = new Student(surname, marks, m);
            }
            Gropus[i] = new Group(GroupName, p, student);
        }
        List<double> A = new List<double>();
        List<int> B = new List<int>();
        for (int i = 0; i < n; i++)
        {
            A.Add(Gropus[i].GroupSredmark);
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (A[j] == A.Max()) { B.Add(j); A[j] = A.Min() - 1; }
            }
        }
        Console.WriteLine("The list of TOP: ");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(Gropus[B[i]].GroupName + " " + Gropus[B[i]].GroupSredmark);
        }
        return 0;
    }
}
