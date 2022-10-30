namespace Lab_6
{
    struct AveragePoint
    {
        public string famile;
        public double average;
        public double[] x;
        public int k;
        public AveragePoint(string famile1, double[] x1)
        {
            average = 0;
            k = 0;
            famile = famile1;
            x = x1;
            for (int i = 0; i < 3; i++)
            {
                if (x[i] == 2) k = 1;
                average += x[i];
            }

            average /= 3;
        }
    }
    struct AverageTime
    {
        public string famile;
        public double[,] x;
        public double result;
        public AverageTime(string famile1, double[,] x1)
        {
            result = 0;
            famile = famile1;
            x = x1;
            for (int i = 0; i < x.GetLength(0); i++)
            {
                result += x[i, 0];
                result += x[i, 1];
            }

            result /= 10;
        }
    }
    struct AverageScore
    {
        public string famile;
        public string[] x;
        public double result;
        public AverageScore(string famile1, string[] x1)
        {
            result = 0;
            famile = famile1;
            x = x1;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == "в") result += 1;
                else if (x[i] == "н") result += 0.5;
                else result += 0;
            }
        }
    }

    struct AveragePointStudent
    {
        public string name;
        public double[] x;
        public double average;
        public int k;
        public AveragePointStudent(string name, double[] x)
        {
            k = 0;
            average = 0;
            this.name = name;
            this.x = x;
            foreach (var i in x)
            {
                average += i;
                if (i == 2) k = 1;
            }

            average /= x.Length;
        }
    }
    
    struct AveragePointGroup
    {
        public string groupnum;
        public AveragePointStudent[] x;
        public double average;
        public int number;
        public AveragePointGroup(string groupnum1, AveragePointStudent[] x1, int n)
        {
            average = 0;
            groupnum = groupnum1;
            x = x1;
            number = n;
            for (int i = 0; i < number; i++)
            {
                average += x[i].average;
            }
            average /= n;
        }
    }
    struct Skiers
    {
        public string famile;
        public double res1;
        public double res2;
        public double sum;

        public Skiers(string famile1, double ress1, double ress2)
        {
            famile = famile1;
            res1 = ress1;
            res2 = ress2;
            sum = res1 + res2;
        }
    }
    struct Japan
    {
        public string q1, q2, q3;
        public SortedList<string, int> Q1 = new SortedList<string, int>();
        public SortedList<string, int> Q2 = new SortedList<string, int>();
        public SortedList<string, int> Q3 = new SortedList<string, int>();
        public Japan(string q11, string q22, string q33)
        {
            q1 = q11;
            q2 = q22;
            q3 = q33;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            static void Task2_2lvl()
            {
                AveragePoint[] C = new AveragePoint[4];
                C[0] = new AveragePoint("Иванов", new double[] { 3.0, 5.0, 2.0});
                C[1] = new AveragePoint("Петров", new double[] { 5.0, 4.0, 3.0 });
                C[2] = new AveragePoint("Сидоров", new double[] { 5.0, 4.0, 5.0});
                C[3] = new AveragePoint("Сергеев", new double[] { 5.0, 2.0, 5.0});
                Console.WriteLine("Все ученики:");
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine($"Фамилия: {C[i].famile}, средний балл: {Math.Round(C[i].average, 4)}");
                }

                for (int i = 0; i < 4 - 1; i++)
                {
                    double amax = C[i].average;
                    int imax = i;
                    for (int j = i + 1; j < 4; j++)
                    {
                        if (C[j].average > amax)
                        {
                            amax = C[j].average;
                            imax = j;
                        }
                    }

                    AveragePoint temp;
                    temp = C[imax];
                    C[imax] = C[i];
                    C[i] = temp;
                }

                Console.WriteLine("Успешно сдавшие ученики:");
                for (int i = 0; i < 4; i++)
                {
                    if (C[i].k == 1) continue;
                    Console.WriteLine($"Фамилия: {C[i].famile}, средний балл: {Math.Round(C[i].average, 4)}");
                }
            }
            static void Task6_2lvl()
            {
                AverageTime[] C = new AverageTime[3];
                C[0] = new AverageTime("Иванов", new double[5, 2] {{9.6, 9.0}, {8.7, 8.2}, {9.8, 9.5}, {10.0, 9.4}, {8.6, 8.0} });
                C[1] = new AverageTime("Петров", new double[5, 2] {{9.6, 9.8}, {8.8, 8.2}, {9.8, 9.3}, {10.0, 10.0}, {9.6, 9.0} });
                C[2] = new AverageTime("Сидоров", new double[5, 2] {{8.6, 8.0}, {8.7, 8.2}, {8.8, 8.5}, {8.0, 8.4}, {8.6, 8.0} });
                for (int i = 0; i < 3 - 1; i++)
                {
                    double amax = C[i].result;
                    int imax = i;
                    for (int j = i + 1; j < 3; j++)
                    {
                        if (C[j].result > amax)
                        {
                            amax = C[j].result;
                            imax = j;
                        }
                    }

                    AverageTime temp;
                    temp = C[imax];
                    C[imax] = C[i];
                    C[i] = temp;
                }

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"{i + 1} место: {C[i].famile}, результат: {Math.Round(C[i].result, 4)}");
                }
            }
            static void Task7_2lvl()
            {
                AverageScore[] C = new AverageScore[3];
                C[0] = new AverageScore("Иванов", new string[5] {"в", "н", "н", "в", "п"});
                C[1] = new AverageScore("Петров", new string[5] {"в", "в", "н", "н", "н"});
                C[2] = new AverageScore("Сидоров", new string[5] {"п", "п", "н", "в", "в"});
                for (int i = 0; i < C.Length - 1; i++)
                {
                    double amax = C[i].result;
                    int imax = i;
                    for (int j = i + 1; j < C.Length; j++)
                    {
                        if (C[j].result > amax)
                        {
                            amax = C[j].result;
                            imax = j;
                        }
                    }

                    AverageScore temp;
                    temp = C[imax];
                    C[imax] = C[i];
                    C[i] = temp;
                }

                for (int i = 0; i < C.Length; i++)
                {
                    Console.WriteLine($"{C[i].famile} - {Math.Round(C[i].result, 4)} очков");
                }
            }
            static void Task1_3lvl()
            {
                int n;
                string name;
                Console.WriteLine("Enter the number of students");
                if (int.TryParse(Console.ReadLine(), out n))
                {
                    AveragePointGroup[] C = new AveragePointGroup[3];
                    Dictionary<string, List<Tuple<string, double>>> Achiviers =
                        new Dictionary<string, List<Tuple<string, double>>>();
                    for (int z = 0; z < 3; z++)
                    {
                        List<Tuple<string, double>> achievers = new List<Tuple<string, double>>();
                        Console.WriteLine($"{z + 1} group:");
                        AveragePointStudent[] A = new AveragePointStudent[n];
                        for (int i = 0; i < n; i++)
                        {
                            double[] marks = new double[5];
                            Console.WriteLine($"Surname {i + 1} student:");
                            name = Console.ReadLine();
                            Console.WriteLine($"Marks {i + 1} student, separating with spaces:");
                            string[] array = Console.ReadLine().Split(" ");
                            for (int j = 0; j < array.Length; j++) if (double.TryParse(array[j], out marks[j]));
                            A[i] = new AveragePointStudent(name, marks);
                            if (A[i].k != 1) achievers.Add(Tuple.Create(A[i].name, A[i].average));
                            achievers.OrderBy(x => x.Item2);
                            Achiviers.Add($"{z + 1} group", achievers);
                        }
                        C[z] = new AveragePointGroup($"{z + 1} group", A, n);
                    }
                    for (int i = 0; i < C.Length - 1; i++)
                    {
                        double amax = C[i].average;
                        int imax = i;
                        for (int j = i + 1; j < C.Length; j++)
                        {
                            if (C[j].average > amax)
                            {
                                amax = C[j].average;
                                imax = j;
                            }
                        }
                    
                        AveragePointGroup temp;
                        temp = C[imax];
                        C[imax] = C[i];
                        C[i] = temp;
                    }
                    for (int i = 0; i < C.Length; i++)
                    {
                        Console.WriteLine($"{i + 1} group achiviers student:");
                        foreach (var x in Achiviers[$"{i + 1} group"])
                        {
                            Console.WriteLine($"{x.Item1} - {x.Item2} средний балл");
                        }
                    }
                    for (int i = 0; i < C.Length; i++)
                    {
                        Console.WriteLine($"{C[i].groupnum} - {Math.Round(C[i].average, 3)} средний балл");
                    }
                }
                
            }
            static void Task4_3lvl()
            {
                Skiers[] C = new Skiers[3];
                for (int i = 0; i < C.Length; i++)
                {
                    Console.WriteLine($"Enter the name of the {i + 1} skier and his results separating with spaces");
                    string[] data = Console.ReadLine().Split(" ");
                    double[] results = new double[2];
                    for (int j = 1; j < data.Length; j++) if (double.TryParse(data[j], out results[j - 1]));
                    C[i] = new Skiers(data[0], results[0], results[1]);
                }

                for (int i = 0; i < C.Length - 1; i++)
                {
                    double amin = C[i].res1;
                    int imax = i;
                    for (int j = i + 1; j < C.Length; j++)
                    {
                        if (C[j].res1 < amin)
                        {
                            amin = C[j].res1;
                            imax = j;
                        }
                    }

                    Skiers temp;
                    temp = C[imax];
                    C[imax] = C[i];
                    C[i] = temp;
                }

                Console.WriteLine("First race:");
                for (int i = 0; i < C.Length; i++)
                {
                    Console.WriteLine($"{C[i].famile} - {C[i].res1} time, {i + 1} place");
                }
                for (int i = 0; i < C.Length - 1; i++)
                {
                    double amin = C[i].res2;
                    int imax = i;
                    for (int j = i + 1; j < C.Length; j++)
                    {
                        if (C[j].res2 < amin)
                        {
                            amin = C[j].res2;
                            imax = j;
                        }
                    }

                    Skiers temp;
                    temp = C[imax];
                    C[imax] = C[i];
                    C[i] = temp;
                }
                Console.WriteLine("Second race:");
                for (int i = 0; i < C.Length; i++)
                {
                    Console.WriteLine($"{C[i].famile} - {C[i].res2} time, {i + 1} place");
                }
                for (int i = 0; i < C.Length - 1; i++)
                {
                    double amin = C[i].sum;
                    int imax = i;
                    for (int j = i + 1; j < C.Length; j++)
                    {
                        if (C[j].sum < amin)
                        {
                            amin = C[j].sum;
                            imax = j;
                        }
                    }

                    Skiers temp;
                    temp = C[imax];
                    C[imax] = C[i];
                    C[i] = temp;
                }
                Console.WriteLine("First + second race:");
                for (int i = 0; i < C.Length; i++)
                {
                    Console.WriteLine($"{C[i].famile} - {C[i].sum} time, {i + 1} place");
                }
            }
            static void Task6_3lvl()
            {
                Japan[] C = new Japan[5];
                for (int i = 0; i < C.Length; i++)
                {
                    string[] s = Console.ReadLine().Split(" ");
                    string q1 = s[0];
                    string q2 = s[1];
                    string q3 = s[2];
                    C[i] = new Japan(q1, q2, q3);
                }
                
                Dictionary<string, int> Q1 = new Dictionary<string, int>();
                Dictionary<string, int> Q2 = new Dictionary<string, int>();
                Dictionary<string, int> Q3 = new Dictionary<string, int>();
                int k;
                double qq1 = 0, qq2 = 0, qq3 = 0;
                for (int i = 0; i < C.Length; i++)
                {
                    if (!Q1.ContainsKey(C[i].q1))
                    {
                        Q1.Add(C[i].q1, 1);
                        qq1++;
                    }
                    else
                    {
                        k = Q1[C[i].q1];
                        k++;
                        qq1++;
                        Q1[C[i].q1] = k;
                    }
                    if (!Q2.ContainsKey(C[i].q2))
                    {
                        qq2++;
                        Q2.Add(C[i].q2, 1);
                    }
                    else
                    {
                        k = Q2[C[i].q2];
                        k++;
                        qq2++;
                        Q2[C[i].q2] = k;
                    }
                    if (!Q3.ContainsKey(C[i].q3))
                    {
                        Q3.Add(C[i].q3, 1);
                        qq3++;
                    }
                    else
                    {
                        k = Q3[C[i].q3];
                        k++;
                        qq3++;
                        Q3[C[i].q3] = k;
                    }
                }
                
                List<Tuple<string, int>> QQ1 = new List<Tuple<string, int>>();
                List<Tuple<string, int>> QQ2 = new List<Tuple<string, int>>();
                List<Tuple<string, int>> QQ3 = new List<Tuple<string, int>>();
                foreach (var x in Q1)
                {
                    QQ1.Add(Tuple.Create(x.Key, x.Value));
                }
                foreach (var x in Q2)
                {
                    QQ2.Add(Tuple.Create(x.Key, x.Value));
                }
                foreach (var x in Q3)
                {
                    QQ3.Add(Tuple.Create(x.Key, x.Value));
                }
                foreach (var x in Q1)
                {
                    Console.WriteLine($"{x.Key}, {x.Value}");
                }
                QQ1.OrderBy(x => x.Item2);
                foreach (var x in Q1)
                {
                    Console.WriteLine($"{x.Key}, {x.Value}");
                }
                QQ2.OrderBy(x => x.Item2);

                QQ3.OrderBy(x => x.Item2);

                Console.WriteLine("First question:");
                k = QQ1.Count;
                if (k > 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine($"{i + 1} place - {QQ1[i].Item1}, {QQ1[i].Item2 / qq1 * 100} %");
                    }
                }
                else
                {
                    for (int i = 0; i < Q1.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} place - {QQ1[i].Item1}, {QQ1[i].Item2 / qq1 * 100} %");
                    }
                }
                Console.WriteLine("Second question:");
                k = QQ2.Count;
                if (k > 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine($"{i + 1} place - {QQ2[i].Item1}, {QQ2[i].Item2 / qq2 * 100} %");
                    }
                }
                else
                {
                    for (int i = 0; i < Q2.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} place - {QQ2[i].Item1}, {QQ2[i].Item2 / qq2 * 100} %");
                    }
                }
                k = QQ3.Count;
                Console.WriteLine("Third question:");
                if (k > 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine($"{i + 1} place - {QQ3[i].Item1}, {QQ3[i].Item2 / qq3 * 100} %");
                    }
                }
                else
                {
                    for (int i = 0; i < Q3.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} place - {QQ3[i].Item1}, {QQ3[i].Item2 / qq3 * 100} %");
                    }
                }
            }
            Task2_2lvl();
            Task6_2lvl();
            Task7_2lvl();
            Task1_3lvl();
            Task4_3lvl();
            Task6_3lvl();
        }
    }
}

