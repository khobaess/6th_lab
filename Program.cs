using System;
using System.Text.RegularExpressions;
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

    struct Group
    {
        public double mean_grade = 0;
        public string group_number;
        public List<Student> students = new List<Student>();

        public Group(List<Student> studs, string group_number = "unknown")
        {
            this.students = studs;
            this.group_number = group_number;
            double sum = 0;

            foreach (Student s in students)
            {
                sum += s.mean_grade;
            }

            if (students.Count != 0)
            {
                this.mean_grade = sum / students.Count;
            }
        }
    }

    struct SkiAthlete
    {
        public string name;
        public double res1, res2, sum;

        public SkiAthlete(double res1, double res2, string name = "unknown")
        {
            this.res1 = res1;
            this.res2 = res2;
            sum = res1 + res2;
            this.name = name;
        }
    }

    struct Survey
    {
        private static int counter = 0;
        public string?[] answers = new string?[3];
        private static List<string> answer1 = new List<string>();
        private static List<string> answer2 = new List<string>();
        private static List<string> answer3 = new List<string>();
        private static Dictionary<string, int> cache1 = new Dictionary<string, int>();
        private static Dictionary<string, int> cache2 = new Dictionary<string, int>();
        private static Dictionary<string, int> cache3 = new Dictionary<string, int>();


        public Survey(string? ans1, string? ans2, string? ans3)
        {
            counter++;
            answers[0] = ans1;

            if (ans1 != null && !cache1.ContainsKey(ans1))
            {
                answer1.Add(ans1);
                cache1[ans1] = 1;
            }
            else
            {
                if (ans1 != null)
                {
                    cache1[ans1]++;
                }
            }

            answers[1] = ans2;
            if (ans2 != null && !cache2.ContainsKey(ans2))
            {
                answer2.Add(ans2);
                cache2[ans2] = 1;
            }
            else
            {
                if (ans2 != null)
                {
                    cache2[ans2]++;
                }
            }

            answers[2] = ans3;
            if (ans3 != null && !cache3.ContainsKey(ans3))
            {
                answer3.Add(ans3);
                cache3[ans3] = 1;
            }
            else
            {
                if (ans3 != null)
                {
                    cache3[ans3]++;
                }
            }
        }

        public static List<string> Answer1
        {
            get { return answer1; }
        }

        public static List<string> Answer2
        {
            get { return answer2; }
        }

        public static List<string> Answer3
        {
            get { return answer3; }
        }

        public static double percentage1(string ans)
        {
            double percentage = 0;
            if (cache1.ContainsKey(ans))
            {
                percentage = cache1[ans] * 100 / counter;
            }
            return percentage;
        }

        public static double percentage2(string ans)
        {
            double percentage = 0;
            if (cache2.ContainsKey(ans))
            {
                percentage = cache2[ans] * 100 / counter;
            }
            return percentage;
        }

        public static double percentage3(string ans)
        {
            double percentage = 0;
            if (cache3.ContainsKey(ans))
            {
                percentage = cache3[ans] * 100 / counter;
            }
            return percentage;
        }
    }

    struct Answer
    {
        public string answer;
        public double percentage;

        public Answer(string answer, double percentage)
        {
            this.answer = answer;
            this.percentage = percentage;
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

        static void sort_overall(List<SkiAthlete> x)
        {
            IOrderedEnumerable<SkiAthlete> xx = x.OrderBy(g => g.sum);

            foreach (SkiAthlete s in xx)
            {
                Console.WriteLine($"{s.name}    -       {s.sum}");
            }
        }

        static void sort_1(List<SkiAthlete> x)
        {
            IOrderedEnumerable<SkiAthlete> xx = x.OrderBy(g => g.res1);

            foreach (SkiAthlete s in xx)
            {
                Console.WriteLine($"{s.name}    -       {s.res1}");
            }
        }

        static void sort_2(List<SkiAthlete> x)
        {
            IOrderedEnumerable<SkiAthlete> xx = x.OrderBy(g => g.res2);

            foreach (SkiAthlete s in xx)
            {
                Console.WriteLine($"{s.name}    -       {s.res2}");
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
                            Console.WriteLine("incorrect format");
                            return;
                        }
                        tmp.Add(value);
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
                    Console.WriteLine($"{s.surname}     -   {s.mean_grade}");
                }

            }
            #endregion

            #region task 2
            Console.WriteLine("task 2");
            {
                int grades_number = 3;
                List<Student> students = new List<Student>();

                Console.WriteLine("as a stop sign use -1 when");
                Console.WriteLine("programm ask enter the surname");

                while (true)
                {
                    Console.WriteLine("enter surname");
                    string surname = Console.ReadLine();

                    if (surname == "-1")
                    {
                        break;
                    }

                    Console.WriteLine($"enter {grades_number} grades");

                    string[] row = Console.ReadLine().Split(" ");

                    if (row.Count() != grades_number)
                    {
                        Console.WriteLine("incorrect format");
                        break;
                    }

                    bool flag = false;
                    List<double> tmp = new List<double>();

                    foreach (string s in row)
                    {
                        double value;
                        if (!double.TryParse(s, out value))
                        {
                            Console.WriteLine("incorrect format");
                            return;
                        }

                        if (value <= 2)
                        {
                            flag = true;
                            break;
                        }
                        tmp.Add(value);
                    }

                    if (flag)
                    {
                        continue;
                    }

                    Student student = new Student(tmp, surname);
                    students.Add(student);
                }

                students.Sort(new StudentsComparer(-1));

                foreach (Student s in students)
                {
                    Console.WriteLine($"{s.surname}     -   {s.mean_grade}");
                }

            }
            #endregion

            #endregion

            #region level 3
            Console.WriteLine("level 3");

            #region task 1
            Console.WriteLine("task 1");
            {
                int grades_number = 5, groups_number = 3;
                Group[] groups = new Group[groups_number];

                for (int i = 0; i < groups_number; i++)
                {
                    Console.WriteLine("enter number of group");
                    string group_number = Console.ReadLine();

                    List<Student> students = new List<Student>();

                    Console.WriteLine("enter -1 as a stop sign");

                    while (true)
                    {
                        Console.WriteLine("enter student's surname");
                        string surname = Console.ReadLine();

                        if (surname == "-1")
                        {
                            break;
                        }

                        Console.WriteLine($"enter {grades_number} grades in a row");

                        string[] row = Console.ReadLine().Split(" ");

                        if (row.Count() != grades_number)
                        {
                            Console.WriteLine("incorrect format");
                            return;
                        }

                        List<double> tmp = new List<double>();

                        foreach (string s in row)
                        {
                            double value;
                            if (!double.TryParse(s, out value))
                            {
                                Console.WriteLine("incorrect format");
                                return;
                            }

                            tmp.Add(value);
                        }

                        Student stud = new Student(tmp, surname);
                        students.Add(stud);
                    }

                    groups[i] = new Group(students, group_number);
                }

                IOrderedEnumerable<Group> groups1 = groups.OrderBy(g => -g.mean_grade);

                foreach (Group g in groups1)
                {
                    Console.WriteLine($"{g.group_number}    -   {g.mean_grade}");
                }
            }
            #endregion

            #region task 4
            Console.WriteLine("task 4");
            {
                List<SkiAthlete> skiers = new List<SkiAthlete>();

                Console.WriteLine("write -1 as a stop sign when asking for a name");

                while (true)
                {
                    Console.WriteLine("enter name");
                    string name = Console.ReadLine();

                    if (name == "-1")
                    {
                        break;
                    }

                    Console.WriteLine("please enter the first and the second result respectively in a row");

                    string[] row = Console.ReadLine().Split(" ");

                    if (row.Count() != 2)
                    {
                        Console.WriteLine("incorrect format");
                        return;
                    }

                    List<double> tmp = new List<double>();

                    foreach (string s in row)
                    {
                        double value;
                        if (!double.TryParse(s, out value))
                        {
                            Console.WriteLine("incorrect format");
                            return;
                        }
                        tmp.Add(value);
                    }

                    SkiAthlete skier = new SkiAthlete(tmp[0], tmp[1], name);
                    skiers.Add(skier);
                }

                Console.WriteLine("name    -       result");
                Console.WriteLine();
                Console.WriteLine("1.");
                sort_1(skiers);
                Console.WriteLine();
                Console.WriteLine("2.");
                sort_2(skiers);
                Console.WriteLine();
                Console.WriteLine("overall.");
                sort_overall(skiers);
            }
            #endregion

            #region task 6
            Console.WriteLine("task 6");
            {
                while (true)
                {
                    string? s1, s2, s3;

                    Console.WriteLine("what animal do you associate with japan and the japanese?");
                    s1 = Console.ReadLine();
                    if (s1 == "")
                    {
                        s1 = null;
                    }

                    Console.WriteLine("What character trait is most common in Japanese people?");
                    s2 = Console.ReadLine();
                    if (s2 == "")
                    {
                        s2 = null;
                    }

                    Console.WriteLine("what inanimate object or concept do you associate with Japan?");
                    s3 = Console.ReadLine();
                    if (s3 == "")
                    {
                        s3 = null;
                    }

                    if (s1 == s2 && s2 == s3 && s3 == null)
                    {
                        break;
                    }

                    Survey survey = new Survey(s1, s2, s3);
                }

                string title = "";
                List<string> arr1 = Survey.Answer1;
                List<string> arr2 = Survey.Answer2;
                List<string> arr3 = Survey.Answer3;

                List<Answer> l1 = new List<Answer>();
                List<Answer> l2 = new List<Answer>();
                List<Answer> l3 = new List<Answer>();

                int i1 = 0, i2 = 0, i3 = 0;

                if (arr1.Count > 0)
                {
                    title += "animal    ";
                }
                if (arr2.Count > 0)
                {
                    title += "trait     ";
                }
                if (arr3.Count > 0)
                {
                    title += "object/concept    ";
                }

                foreach (string ans in arr1)
                {
                    if (i1 == 5)
                    {
                        break;
                    }
                    Answer tmp = new Answer(ans, Survey.percentage1(ans));
                    l1.Add(tmp);
                    i1++;
                }

                foreach (string ans in arr2)
                {
                    if (i2 == 5)
                    {
                        break;
                    }
                    Answer tmp = new Answer(ans, Survey.percentage2(ans));
                    l2.Add(tmp);
                    i2++;
                }

                foreach (string ans in arr3)
                {
                    if (i3 == 5)
                    {
                        break;
                    }
                    Answer tmp = new Answer(ans, Survey.percentage3(ans));
                    l3.Add(tmp);
                    i3++;
                }

                IOrderedEnumerable<Answer> l11 = l1.OrderBy(g => -g.percentage);
                IOrderedEnumerable<Answer> l22 = l2.OrderBy(g => -g.percentage);
                IOrderedEnumerable<Answer> l33 = l3.OrderBy(g => -g.percentage);

                Console.WriteLine(title);

                foreach (var s in l11.Zip(l22.Zip(l33, (a, b) => $"{a.answer} {a.percentage}%   {b.answer} {b.percentage}%"), (m, n) => $"{m.answer} {m.percentage}     {n}"))
                {
                    Console.WriteLine(s);
                }
            }
            #endregion

            #endregion

        }
    }
}