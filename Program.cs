using System;

namespace Task
{
    
    class Program
    {
        struct Student 
        {
            public List<double> grades = new List<double>();
            public double midGrade = 0;
            public string name;
            public Student(double[] x,string name = "неизвестно")
            {
                int dl = x.Length;
                double sum = 0;
                for(int i = 0; i < dl; i++)
                {
                    grades.Add(x[i]);
                    sum += x[i];
                }
                if (dl != 0) 
                {
                    midGrade = sum / dl;
                }
                this.name = name;
            }
            public Student(List<double> x,string name = "неизвестно")
            {
                int dl = x.Count;
                double sum = 0;
                for (int i = 0; i < dl; i++)
                {
                    grades.Add(x[i]);
                    sum += x[i];
                }
                if (dl != 0)
                {
                    midGrade = sum / dl;
                }
                this.name = name;
            }

        }
        struct Group
        {
            public double midGrade = 0;
            public string name ="неизвестно";
            public List<Student> students = new List<Student>();
            public Group(List<Student> st , string name = "неизвестно")
            {
                this.students = st;
                this.name = name;
                double sum = 0;
                foreach(Student student in students)
                {
                    sum+=student.midGrade;
                }

                if (students.Count != 0)
                {
                    this.midGrade = sum / students.Count;
                }
            }
        }
        struct Skier
        {
            public string name;
            public double rez1, rez2, sum;
            public Skier(double rez1, double rez2, string name = "неизвестно")
            {
                this.name = name;
                this.rez1 = rez1;
                this.rez2 = rez2;
                sum = rez1 + rez2;
            }
        }
        struct Answer
        {
            public string?[] ans = new string?[3];
            private static Dictionary<string, int> map1 = new Dictionary<string, int>();
            private static Dictionary<string, int> map2 = new Dictionary<string, int>();
            private static Dictionary<string, int> map3 = new Dictionary<string, int>();
            private static int kol = 0;
            private static List<string> answer1 = new List<string>();
            private static List<string> answer2 = new List<string>();
            private static List<string> answer3 = new List<string>();
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
            public Answer(string? ot1, string? ot2, string? ot3)
            {

                kol++;
                ans[0]=ot1;
                if (ot1 != null && !map1.ContainsKey(ot1))
                {
                    answer1.Add(ot1);
                    map1[ot1] = 1;
                }
                else
                {
                    if (ot1 != null)
                    {
                        map1[ot1]++;
                    }
                }
                ans[1]=ot2;
                if (ot2 != null && !map2.ContainsKey(ot2))
                {
                    answer2.Add(ot2);
                    map2[ot2] = 1;
                }
                else
                {
                    if (ot2 != null)
                    {
                        map2[ot2]++;
                    }
                }
                ans[2]=ot3;
                if (ot3 != null && !map3.ContainsKey(ot3))
                {
                    answer3.Add(ot3);
                    map3[ot3] = 1;
                }
                else
                {
                    if (ot3 != null)
                    {
                        map3[ot3]++;
                    }
                }
            }
            public static string HowM1(string ot)
            {
                double pr = 0;
                if (map1.ContainsKey(ot))
                {
                    pr = (map1[ot] * 100) / kol;
                }
                return ot + $" ({pr}%)";
            }
            public static string HowM2(string ot)
            {
                double pr = 0;
                if (map2.ContainsKey(ot))
                {
                    pr = (map2[ot] * 100) / kol;
                }
                return ot + $" ({pr}%)";
            }
            public static string HowM3(string ot)
            {
                double pr = 0;
                if (map3.ContainsKey(ot))
                {
                    pr = (map3[ot] * 100) / kol;
                }
                return ot + $" ({pr}%)";
            }
            public static double How1(string ot)
            {

                double pr = 0;
                if (map1.ContainsKey(ot))
                {
                    pr = (map1[ot] * 100) / kol;
                }
                return pr;
            }
            public static double How2(string ot)
            {

                double pr = 0;
                if (map2.ContainsKey(ot))
                {
                    pr = (map2[ot] * 100) / kol;
                }
                return pr;
            }
            public static double How3(string ot)
            {

                double pr = 0;
                if (map3.ContainsKey(ot))
                {
                    pr = (map3[ot] * 100) / kol;
                }
                return pr;
            }

        }
        static void exercise_2_1()
        {
            string error = "ошибка 2_1";
            int countGrades = 4;
            List<Student> students = new List<Student>();
            var Q = new PriorityQueue<Student, double>(new Comparer(-1));
            while (true)
            {
                Console.WriteLine($"введите {countGrades} оценки");
                if (!InputOutput.CheckSplitRead(out List<double> l, out bool check,error, countGrades))
                {
                    if (check) break;
                    return;
                }
                Student student = new Student(l);
                students.Add(student);
                Q.Enqueue(student, student.midGrade);
            }
            List<string> S = new List<string>();
            S.Add("средния оценка >= 4");
            while(Q.TryDequeue(out Student student, out double q))
            {
                if (q < 4)
                {
                    break;
                }
                S.Add(q.ToString());
            }
            foreach(string s in S)
            {
                Console.WriteLine(s);
            } 
        }
        static void exercise_2_2()
        {
            string error = "ошибка 2_2";
            int countGrades = 3;
            List<Student> students = new List<Student>();
            var Q = new PriorityQueue<Student, double>(new Comparer(-1));
            while (true)
            {
                Console.WriteLine($"введите имя");
                string name;
                if(!InputOutput.Read(out name))
                {
                    break;
                }
                Console.WriteLine($"введите {countGrades} оценки");
                if (!InputOutput.CheckSplitRead(out List<double> l, out bool check, error, countGrades))
                {
                    if (check) break;
                    return;
                }
                bool fl = false;
                foreach(double to in l)
                {
                    if(to <= 2) 
                    {
                        fl = true;
                        break;
                    }
                }
                if (fl) continue;
                Student student = new Student(l,name);
                students.Add(student);
                Q.Enqueue(student, student.midGrade);
            }
            List<string> S = new List<string>();
            S.Add("имя /средний балл успешно сдавших ");
            while (Q.TryDequeue(out Student student, out double q))
            {
                S.Add(student.name +" "+ q.ToString());
            }
            foreach (string s in S)
            {
                Console.WriteLine(s);
            }
        }

        static Group readGroup(int countGrades, out bool Fl)
        {
            Fl = false;
            string erorr = "ошибка 3_1";
            Console.WriteLine($"введите название группы");
            string Name;
            if (!InputOutput.Read(out Name))
            {
                return new Group(new List<Student>());
            }
            List<Student> students = new List<Student>();
            while (true)
            {
                string name;
                Console.WriteLine($"введите имя");
                if (!InputOutput.Read(out name))
                {
                    break;
                }
                Console.WriteLine($"введите {countGrades} оценок");
                if (!InputOutput.CheckSplitRead(out List<double> l, out bool check, erorr, countGrades))
                {
                    if (check) break;
                    Fl = true;
                    return new Group(new List<Student>());
                }

                Student student = new Student(l, name);
                students.Add(student);
            }
            Group group = new Group(students,Name);
            return group;
        }
        static void exercise_3_1()
        {
            string error = "ошибка 3_1";
            int countGrades = 5;
            int countGroups = 3;
            Group[] groups = new Group[countGroups];
            var Q = new PriorityQueue<Group, double>(new Comparer(-1));
            for(int i = 0; i < countGroups; ++i)
            {
                groups[i] = readGroup(countGrades,out bool Fl);
                if (Fl)
                {
                    return;
                }
                Q.Enqueue(groups[i], groups[i].midGrade);
            }

            List<string> S = new List<string>();
            S.Add("название групы /средний бал груп");
            while (Q.TryDequeue(out Group group, out double q))
            {
                S.Add(group.name + " " + q.ToString());
            }
            foreach (string s in S)
            {
                Console.WriteLine(s);
            }
        }
        static void WriteTask_3_4(PriorityQueue<Skier, double> Q)
        {
            List<string> S = new List<string>();
            S.Add("имя / результат");
            while (Q.TryDequeue(out Skier skier, out double q))
            {
                S.Add(skier.name + " " + q.ToString());
            }
            foreach (string s in S)
            {
                Console.WriteLine(s);
            }
        }
        static void exercise_3_4()
        {
            string error = "ошибка 3_4";
            List<Skier> skiers = new List<Skier>();
            var Q = new PriorityQueue<Skier, double>(new Comparer(-1));
            var Q1 = new PriorityQueue<Skier, double>(new Comparer(-1));
            var Q2 = new PriorityQueue<Skier, double>(new Comparer(-1));
            for (int i = 0; i == i; ++i)
            {
                string s;
                List<double> l = new List<double>();
                Console.WriteLine("введите имя");
                if(!InputOutput.Read(out s))
                {
                    break;
                }
                Console.WriteLine("ведите первый и второй результат");
                if (!InputOutput.CheckSplitRead(out l, out bool Check, error, 2))
                {
                    if (Check) break;
                    return;
                }

                Skier skier = new Skier(l[0], l[1], s);
                Q.Enqueue(skier, skier.sum);
                Q1.Enqueue(skier, skier.rez1);
                Q2.Enqueue(skier, skier.rez2);
            }

            WriteTask_3_4(Q1);
            Console.WriteLine();
            WriteTask_3_4(Q2);
            Console.WriteLine();
            WriteTask_3_4(Q);
            

        }
        static void exercise_3_6()
        {
            string error = "ошибка 3_6";
            var Q1 = new PriorityQueue<string, double>(new Comparer(-1));
            var Q2 = new PriorityQueue<string, double>(new Comparer(-1));
            var Q3 = new PriorityQueue<string, double>(new Comparer(-1));
            for (int i = 0; i == i; ++i)
            {
                string? s1,s2,s3;
                Console.WriteLine("какое животное");
                if (!InputOutput.Read(out s1))
                {
                    s1 = null;
                }
                Console.WriteLine("какая черта");
                if (!InputOutput.Read(out s2))
                {
                    s2 = null;
                }
                Console.WriteLine("какой предмет");
                if (!InputOutput.Read(out s3))
                {
                    s3 = null;
                }
                if (s1 == null && s2 == null && s3 == null)
                {
                    break;
                }
                Answer answer = new Answer(s1, s2, s3);
            }
            string header = "";
            List<string> l1 = Answer.Answer1;
            List<string> l2 = Answer.Answer2;
            List<string> l3 = Answer.Answer3;
            int sh1 = 0, sh2 = 0, sh3 = 0;
            if (l1.Count != 0)
            {
                header += "животное ";
            }
            if (l2.Count != 0)
            {
                header += "черта ";
            }
            if (l3.Count != 0)
            {
                header += "предмет ";
            }

            foreach (string s in l1)
            {
                Q1.Enqueue(s,Answer.How1(s));
            }
            foreach (string s in l2)
            {
                Q2.Enqueue(s, Answer.How2(s));
            }
            foreach (string s in l3)
            {
                Q3.Enqueue(s, Answer.How3(s));
            }

            List<string> S = new List<string>();
            S.Add(header);
            while ((Q1.Count > 0 || Q2.Count > 0 || Q3.Count > 0) && sh1 + sh2 + sh3 < 15) 
            {
                string ST = "";
                string st;
                double q;
                if (Q1.TryDequeue(out st, out q) && sh1 < 5) 
                {
                    sh1++;
                    ST += Answer.HowM1(st) + "/";
                } 
                else
                {
                    if (l1.Count != 0)
                    {
                        ST += " /";
                    }
                }
                if (Q2.TryDequeue(out st, out q) && sh2 < 5) 
                {
                    sh2++;
                    ST += Answer.HowM2(st) + "/";
                }
                else
                {
                    if (l2.Count != 0)
                    {
                        ST += " /";
                    }
                }
                if (Q3.TryDequeue(out st, out q) && sh3 < 5) 
                {
                    sh3++;
                    ST += Answer.HowM3(st) + " ";
                }
                S.Add(ST);
            }
            foreach (string s in S)
            {
                Console.WriteLine(s);
            }
        }
        static void Main(string[] args)
        {
            #region exercise_2_1;
            exercise_2_1();
            #endregion

            #region exercise_2_2;
            exercise_2_2();
            #endregion

            #region exercise_3_1;
            exercise_3_1();
            #endregion

            #region exercise_3_4;
            exercise_3_4();
            #endregion

            #region exercise_3_6;
            exercise_3_6();
            #endregion

        }

        static string ListToString(List<double> L)
        {
            string s = "";
            foreach (double v in L)
            {
                s += v.ToString();
                s += " ";
            }
            return s;
        }
        static string ArrayToString(double[] L)
        {
            string s = "";
            foreach (double v in L)
            {
                s += v.ToString();
                s += " ";
            }
            return s;
        }
        static string[] ArrayToString(double[][] L, int n = 0)
        {
            string[] S = new string[n];
            int sh = 0;
            foreach (double[] v in L)
            {
                S[sh] = ArrayToString(v);
                sh++;
            }
            return S;
        }
        static string[] ArrayToString(double[,] L)
        {
            int n = L.GetLength(0), m = L.GetLength(1);
            string[] S = new string[n];
            for (int i = 0; i < n; i++)
            {
                string s = "";
                for (int j = 0; j < m; j++)
                {
                    s += L[i, j].ToString();
                    s += " ";
                }
                S[i] = s;
            }
            return S;
        }
        static int Compare((double, int) x, (double, int) y)
        {
            if (x.Item1 < y.Item1)
            {
                return 1;
            }

            if (x.Item1 > y.Item1)
            {
                return -1;
            }

            return 0;
        }
    }

    static class InputOutput
    {
        const string EndString = "";
        static public void Write(int ans)
        {
            Console.WriteLine("ans : " + ans.ToString());
        }
        static public void Write(double ans)
        {
            Console.WriteLine("ans : " + ans.ToString());
        }
        static public bool Read(out string s)
        {
            s = Console.ReadLine();
            if(s == EndString)
            {
                return false;
            }
            return true;
        }
        static public bool Read(out double x)
        {
            string s;
            s = Console.ReadLine();

            if (!double.TryParse(s, out x))
            {
                return false;
            }
            return true;
        }
        static public bool Read(out int x)
        {
            string s;
            s = Console.ReadLine();

            if (!int.TryParse(s, out x))
            {
                return false;
            }
            return true;
        }
        static public bool Read(out int x, out bool fl)
        {
            fl = false;
            string s;
            s = Console.ReadLine();
            if (s == EndString) fl = true;
            if (!int.TryParse(s, out x))
            {
                return fl;
            }
            return true;
        }
        static public bool Read(out double x, out bool fl)
        {
            fl = false;
            string s;
            s = Console.ReadLine();
            if (s == EndString) fl = true;
            if (!double.TryParse(s, out x))
            {
                return fl;
            }
            return true;
        }

        static public bool CheckRead(out double x, string Erorr = "ошибка", string? ans = null)
        {
            bool fl;
            if (!Read(out x, out fl))
            {
                Console.WriteLine(Erorr);
                return false;
            }

            if (fl)
            {
                if (ans != null)
                {
                    Console.WriteLine(ans);
                }
                return false;
            }
            return true;
        }
        static public bool CheckRead(out int x, string Erorr = "ошибка", string? ans = null)
        {
            bool fl;
            if (!Read(out x, out fl))
            {
                Console.WriteLine(Erorr);
                return false;
            }

            if (fl)
            {
                if (ans != null)
                {
                    Console.WriteLine(ans);
                }
                return false;
            }
            return true;
        }
        static public bool CheckSplitRead(out List<double> L, out bool Check ,string Erorr = "ошибка", int? kol = null, string? ans = null)
        { 
            Check = false;
            List<double> l = new List<double>();
            L = l;
            string? s = Console.ReadLine();
            if (s == EndString)
            {
                if (ans != null)
                {
                    Console.WriteLine(ans);
                }
                if (ans == null)
                {
                    Check = true;
                }
                return false;
            }
            if (s == null)
            {
                Console.WriteLine(Erorr);
                return false;
            }
            string[] S = s.Split(" ");
            foreach (string st in S)
            {
                double x;
                if (st == "") continue;
                if (!double.TryParse(st, out x))
                {
                    Console.WriteLine(Erorr);
                    return false;
                }
                L.Add(x);
            }
            if (kol != null && L.Count() != kol)
            {
                Console.WriteLine("не верное количество элементов в строке");
                return false;
            }
            return true;
        }
    }
    class Comparer : IComparer<double>
    {
        public int A = 1;
        public Comparer(int a)
        {
            A = a;
        }
        public int Compare(double p1, double p2)
        {
            if (p1 < p2)
            {
                return -1 * A;
            }
            if (p1 > p2)
            {
                return A;
            }

            return 0;
        }
    }
}