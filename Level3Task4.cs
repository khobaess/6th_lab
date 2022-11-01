using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
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
        int z = 0;
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
                z++;
                Console.WriteLine("Enter the surname of sportsman number " + (j + 1) + ":");
                string surname = Console.ReadLine();
                Console.WriteLine("Enter the result of exams for spotsman - " + surname + ": ");
                double x;
                string line;
                line = Console.ReadLine();
                if (double.TryParse(line, out x) == false) { Console.WriteLine("Incorrect data!!!"); return 0; }
                double.TryParse(line, out x);
                student[j] = new Student(surname, x);
            }
            Gropus[i] = new Group(GroupName, p, student);
        }
        for (int i = 0; i < n; i++)
        {

           int  left = 0;
           int  right = Gropus[i].Students.Length - 1;

            while (left < right)
            {
                for (int p = left; p < right; p++)
                {
                    if (Gropus[i].Students[p].Marks < Gropus[i].Students[p + 1].Marks)
                    {
                        Student x;
                        x = Gropus[i].Students[p];
                        Gropus[i].Students[p] = Gropus[i].Students[p + 1];
                        Gropus[i].Students[p + 1] = x;
                    }
                }
                right--;

                for (int p = right; p > left; p--)
                {
                    if (Gropus[i].Students[p - 1].Marks < Gropus[i].Students[p].Marks)
                    {
                        Student x;
                        x = Gropus[i].Students[p];
                        Gropus[i].Students[p] = Gropus[i].Students[p-1];
                        Gropus[i].Students[p-1] = x;
                    }
                }
                left++;
            }

        }
        Student[] obsh = new Student[z];
        int l = 0;
        for (int i=0; i < n; i++)
        {
            for (int j=0; j < Gropus[i].KollvoStudents; j++)
            {
                obsh[l] = Gropus[i].Students[j];
                l++;
            }
        }

        int lef = 0;
        int righ = obsh.Length - 1;

        while (lef < righ)
        {
            for (int p = lef; p < righ; p++)
            {
                if (obsh[p].Marks < obsh[p + 1].Marks)
                {
                    Student x;
                    x = obsh[p];
                    obsh[p] = obsh[p + 1];
                    obsh[p + 1] = x;
                }
            }
            righ--;

            for (int p = righ; p > lef; p--)
            {
                if (obsh[p - 1].Marks < obsh[p].Marks)
                {
                    Student x;
                    x = obsh[p];
                    obsh[p] = obsh[p - 1];
                    obsh[p - 1] = x;
                }
            }
            lef++;
        }

        Console.WriteLine("The general summary list:");

        for (int i=0; i<z; i++)
        {
            Console.WriteLine(obsh[i].Surname + " - " + obsh[i].Marks);
        }

        Console.WriteLine();
        Console.WriteLine("The group list:");

        for (int j = 0; j < n; j++)
        {

            Console.WriteLine("The list of TOP of Group <" + Gropus[j].GroupName + ">: ");
            for (int i = 0; i < Gropus[j].KollvoStudents; i++)
            {
                Console.WriteLine(Gropus[j].Students[i].Surname + " - " + Gropus[j].Students[i].Marks);
            }
        }
        return 0;
    }
}
