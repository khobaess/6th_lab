namespace _6_Lab {
    struct Task_2_3 {

        public string Surname{ get; set; }
        public double BestResult { get; set; }

        public Task_2_3(string surname, double[] results) {
            this.Surname = surname;
            this.BestResult = results.Max();
        }
    }

    struct Task_2_5 {
        public string Surname { get; set; }
        public double Score { get; set; }

        public Task_2_5(string surname, double jumpDistance, int[] score) {
            this.Surname = surname;
            this.Score = score.Sum() + (int)(jumpDistance / 2);
        }
    }

    struct Task_3_1 {
        public string Name;
        public double AverageMark;

        public Task_3_1(string name, int[] marks) {
            this.Name = name;
            this.AverageMark = marks.Sum() / 5.0;
        }
    }

    struct Task_3_4 {
        public string Surname;
        public double Result;

        public Task_3_4(string surname, double result) {
            this.Surname = surname;
            this.Result = result;
        }
    }

    struct Task_3_6 {

        public Dictionary<string, int> first = new Dictionary<string, int>();
        public Dictionary<string, int> second = new Dictionary<string, int>();
        public Dictionary<string, int> third = new Dictionary<string, int>();

        public Task_3_6() {

        }

        public void addAnswer(string[] answer) {
            if (answer[0] == "-") {

            } else if (first.ContainsKey(answer[0])) {
                first[answer[0]]++;
            } else {
                first.Add(answer[0], 1);
            }

            if (answer[1] == "-") {

            } else if (second.ContainsKey(answer[1])) {
                second[answer[1]]++;
            } else {
                second.Add(answer[1], 1);
            }

            if (answer[2] == "-") {

            } else if (third.ContainsKey(answer[2])) {
                third[answer[2]]++;
            } else {
                third.Add(answer[2], 1);
            }
        }

        public void printPopularAnswers() {

            void printAnswer(Dictionary<string, int> dict, string name) {

                string[] keys = new string[dict.Count];
                int[] values = new int[dict.Count];

                int curInd = 0;
                foreach (var item in dict.Keys) {
                    keys[curInd] = item;
                    values[curInd] = dict[item];
                    curInd++;
                }

                for (int i = 0; i < keys.Length; i++) {
                    for (int j = i + 1; j < keys.Length; j++) {
                        if (values[i] < values[j]) {
                            int tempi = values[i];
                            values[i] = values[j];
                            values[j] = tempi;

                            string temps = keys[i];
                            keys[i] = keys[j];
                            keys[j] = temps;
                        }
                    }
                }

                int suma = values.Sum();
                Console.WriteLine($"The most popular answers to the {name} question:");
                for (int i = 0; i < (dict.Count < 5 ? dict.Count : 5); i++) {
                    Console.WriteLine($"{i + 1}. {keys[i]} - {Math.Round(values[i] / (suma * 1.0) * 100)}%");
                }
            }

            printAnswer(first, "first");
            printAnswer(second, "second");
            printAnswer(third, "third");
        }
    }

    class Program {
        static void Main(string[] args) {

            // Level 2 -----------------------
            static void task_2_3() {
                Console.Write("Number of sportsmen: ");
                if (!int.TryParse(Console.ReadLine().Trim(), out int n)) {
                    Console.WriteLine("Wrong input.");
                    return;
                }

                Task_2_3[] sportsmen = new Task_2_3[n];

                Console.WriteLine("Sportsmen names and results, example: Ivanov 2,33 2,41 2,37");
                for (int i = 0; i < n; i++) {
                    Console.Write($"{i + 1}. ");

                    string[] data = Console.ReadLine().Trim().Split();

                    if (data.Length != 4) {
                        Console.WriteLine("Wrong input.");
                        return;
                    }

                    double[] results = new double[3];
                    for (int j = 1; j < 4; j++) {
                        if (!double.TryParse(data[j], out results[j - 1])) {
                            Console.WriteLine("Wrong input.");
                            return;
                        }
                        if (results[j - 1] < 0) { 
                            Console.WriteLine("Impossible jump distance");
                            return;
                        }
                    }

                    sportsmen[i] = new Task_2_3(data[0], results);
                }

                Console.WriteLine("Final protocol:");
                for (int i = 0; i < sportsmen.Length; i++) {
                    Console.WriteLine($"{sportsmen[i].Surname} {sportsmen[i].BestResult}");
                }
            }

            static void task_2_5() {
                Console.Write("Number of sportsmen: ");
                if (!int.TryParse(Console.ReadLine().Trim(), out int n)) {
                    return;
                }

                Task_2_5[] sportsmen = new Task_2_5[n];

                Console.WriteLine("Sportsmen names and results (surname, jump distance, scores by referees)\nexample: Ivanov 130,7 17 19 19 18 16");
                for (int i = 0; i < n; i++) {
                    Console.Write($"{i + 1}. ");

                    string[] data = Console.ReadLine().Trim().Split();

                    if (data.Length != 7) {
                        Console.WriteLine("Wrong input.");
                        return;
                    }

                    if (!double.TryParse(data[1], out double jumpDistance)) {
                        Console.WriteLine("Wrong input.");
                        return;
                    }

                    if (jumpDistance < 0) {
                        Console.WriteLine("Impossible jump distance");
                        return;
                    }

                    int[] results = new int[5];
                    for (int j = 2; j < 7; j++) {
                        if (!int.TryParse(data[j], out results[j - 2])) {
                            Console.WriteLine("Wrong input.");
                            return;
                        }
                        if (results[j - 2] < 0 || results[j - 2] > 20) {
                            Console.WriteLine("Wrong referee score.");
                            return;
                        }
                    }

                    sportsmen[i] = new Task_2_5(data[0], jumpDistance, results);
                }

                for (int i = 0; i < n; i++) {
                    for (int j = i + 1; j < n; j++) {
                        if (sportsmen[i].Score < sportsmen[j].Score) {
                            Task_2_5 temp = sportsmen[i];
                            sportsmen[i] = sportsmen[j];
                            sportsmen[j] = temp;
                        }
                    }
                }

                Console.WriteLine("Final protocol:");
                for (int i = 0; i < sportsmen.Length; i++) {
                    Console.WriteLine($"{i + 1}. {sportsmen[i].Surname} ({sportsmen[i].Score})");
                }
            }

            // Level 3 -----------------------
            static void task_3_1() {
                Task_3_1[] groups = new Task_3_1[3];

                Console.WriteLine("Enter groups names and marks, example: BIVT-22-17 3 3 4 5 3");
                for (int i = 0; i < 3; i++) {
                    Console.Write($"{i + 1}. ");

                    string[] data = Console.ReadLine().Trim().Split();

                    if (data.Length != 6) {
                        Console.WriteLine("Wrong input.");
                        return;
                    }

                    int[] marks = new int[5];
                    for (int j = 1; j < 6; j++) {
                        if (!int.TryParse(data[j], out marks[j - 1])) {
                            Console.WriteLine("Wrong input.");
                            return;
                        }
                        if (marks[j - 1] < 0) {
                            Console.WriteLine("Impossible mark");
                            return;
                        }
                    }

                    groups[i] = new Task_3_1(data[0], marks);
                }

                for (int i = 0; i < 3; i++) {
                    for (int j = i + 1; j < 3; j++) {
                        if (groups[i].AverageMark < groups[j].AverageMark) {
                            Task_3_1 temp = groups[i];
                            groups[i] = groups[j];
                            groups[j] = temp;
                        }
                    }
                }

                Console.WriteLine("Final table:");
                Console.WriteLine("Place\tName\t\tAverage Mark");
                for (int i = 0; i < groups.Length; i++) {
                    Console.WriteLine($"{i + 1}\t{groups[i].Name}\t{groups[i].AverageMark}");
                }
            }

            static void task_3_4() {

                static Task_3_4[] getGroup(string groupName) {
                    Console.Write($"Number of sportsmen in {groupName} group: ");
                    if (!int.TryParse(Console.ReadLine().Trim(), out int n)) {
                        return null;
                    }

                    Task_3_4[] group = new Task_3_4[n];

                    Console.WriteLine("Enter sportsmen names and results, example: Ivanov 17,7");
                    for (int i = 0; i < n; i++) {
                        Console.Write($"{i + 1}. ");

                        string[] data = Console.ReadLine().Trim().Split();

                        if (data.Length != 2) {
                            return null;
                        }

                        if (!double.TryParse(data[1], out double result)) {
                            return null;
                        }
                        if (result < 0) {
                            Console.WriteLine("Impossible result");
                            return null;
                        }

                        group[i] = new Task_3_4(data[0], result);
                    }

                    return sortGroup(group);
                }

                static Task_3_4[] sortGroup(Task_3_4[] group) {
                    for (int i = 0; i < group.Length; i++) {
                        for (int j = i + 1; j < group.Length; j++) {
                            if (group[i].Result > group[j].Result) {
                                Task_3_4 temp = group[i];
                                group[i] = group[j];
                                group[j] = temp;
                            }
                        }
                    }

                    return group;
                }

                static void printGroup(Task_3_4[] group, string groupName) {
                    Console.WriteLine($"Group {groupName} results:");

                    for (int i = 0; i < group.Length; i++) {
                        Console.WriteLine($"{i + 1}. {group[i].Surname} - {group[i].Result}");
                    }
                }

                static Task_3_4[] mixGroups(Task_3_4[] groupA, Task_3_4[] groupB) {
                    Task_3_4[] groupC = new Task_3_4[groupA.Length + groupB.Length];

                    int indA = 0, indB = 0;
                    for (int i = 0; i < groupC.Length; i++) {
                        if (indA == groupA.Length) {
                            groupC[i] = groupB[indB];
                            indB++;
                            continue;
                        }
                        if (indB == groupB.Length) {
                            groupC[i] = groupA[indA];
                            indA++;
                            continue;
                        }
                        if (groupA[indA].Result < groupB[indB].Result) {
                            groupC[i] = groupA[indA];
                            indA++;
                        } else {
                            groupC[i] = groupB[indB];
                            indB++;
                        }
                    }

                    return groupC;
                }


                Task_3_4[] groupA = getGroup("A");

                if (groupA == null) {
                    Console.WriteLine("Wrong input.");
                    return;
                }

                Task_3_4[] groupB = getGroup("B");

                if (groupB == null) {
                    Console.WriteLine("Wrong input.");
                    return;
                }

                printGroup(groupA, "A");
                printGroup(groupB, "B");

                Task_3_4[] groupC = mixGroups(groupA, groupB);

                printGroup(groupC, "A+B");
            }

            static void task_3_6() {
                Task_3_6 data = new Task_3_6();

                Console.WriteLine("Enter answers with a space between, exapmle: fox practicality sakura");
                Console.WriteLine("If question don`t have answer replace it with '-', example: 'fox - sakura' or '- - sakura' or '- - -'");
                Console.WriteLine("To stop typing answers, enter a blank line");

                while (true) {
                    string answer = Console.ReadLine().Trim();

                    if (answer == "") {
                        break;
                    }

                    if (answer.Split().Length != 3) {
                        Console.WriteLine("Wrong input.");
                        return;
                    }

                    data.addAnswer(answer.Split());
                }

                data.printPopularAnswers();
            }

            // -------------------------------

            task_2_3();
        }
    }
}
