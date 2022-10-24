using System;
namespace _6th_Lab


{
    struct Student
    {
        public List<double> grades = new List<double>();
        public double mean_grade = 0;
        public string surname;

        public Student(List<double> x, string surname = "unknown")
        {
            int length = x.Count;
            double sum = 0;

            foreach (double grade in x)
            {
                grades.Add(grade);
                sum += grade;
            }

            if (length > 0)
            {
                mean_grade = sum / length;
            }
            this.surname = surname;
        }
    }

    class Program
    {
        class CompareHashMapping : IComparer<double>
        {
            public int key = 1;

            public CompareHashMapping(int k)
            {
                key = k;
            }

            public int Compare(double a, double b)
            {
                if (a < b)
                {
                    return -key;
                }
                if (a > b)
                {
                    return key;
                }
                return 0;
            }
        }

        class StudentsComparer : IComparer<Student>
        {
            public int key = 1;

            public StudentsComparer(int k)
            {
                key = k;
            }

            public int Compare(Student stud1, Student stud2)
            {
                if (stud1.mean_grade < stud2.mean_grade)
                {
                    return -key;
                }
                if (stud1.mean_grade > stud2.mean_grade)
                {
                    return key;
                }
                return 0;
            }
        }

        static void Main(string[] args)
        {
            #region level 2
            Console.WriteLine("Level 2");

            #region task 1
            Console.WriteLine("task 1");
            {
                int grades_number = 4;
                List<Student> students = new List<Student>();

                Console.WriteLine("enter number of students");
                int n;
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                    {
                        Console.WriteLine("incorrect format, try again");
                        continue;
                    }
                    break;
                }


                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"enter {i + 1} student  {grades_number} grades");

                    string[] row = Console.ReadLine().Split(" ");

                    if (row.Count() != grades_number)
                    {
                        Console.WriteLine("incorrect format");
                        return;
                    }

                    Console.WriteLine("enter student's name");
                    string name = Console.ReadLine();

                    List<double> tmp = new List<double>();

                    foreach (string s in row)
                    {
                        double value;
                        if (!double.TryParse(s, out value))
                        {
                            tmp.Add(value);
                        }
                    }
                    Student student = new Student(tmp, name);

                    if (student.mean_grade >= 4)
                    {
                        students.Add(student);
                    }
                    
                }

                students.Sort(new StudentsComparer(-1));

                foreach (Student s in students)
                {
                    Console.WriteLine(students[0].surname);
                }

            }
            #endregion

            #endregion

        }
    }
}