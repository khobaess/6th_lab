using System;
using System.Collections.Generic;

namespace lab6
{
    class Program
    {
        struct st1
        {
            public string surname;
            public double[] grades;
            public double average;

            public st1(string surnamee, double[] gradess)
            {
                surname = surnamee;
                grades = gradess;

                double s = 0;
                for (int i = 0; i < grades.Length; i++)
                {
                    s += grades[i];
                }

                average = s / grades.Length;
            }
        }
        struct st2
        {
            public string surname;
            public double time;
        }
        struct st3
        {
            public string animal;
            public string character;
            public string item;
        }

        static st1[] group_stats(int exam_count)
        {
            Console.WriteLine($"Enter the number of students in the group.");

            int n;
            bool try_x;

            try_x = int.TryParse(Console.ReadLine(), out n);
            if (!try_x)
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return new st1[0];
            }

            Console.WriteLine();
            Console.WriteLine("Enter the information about students.");
            Console.WriteLine("(Format: Ivanov 5 4 2...)");

            st1[] st_info = new st1[n];
            string input;
            string[] elems;
            string surname;
            double[] grades;


            for (int ind = 0; ind < n; ind++)
            {
                input = Console.ReadLine();
                elems = input.Split();

                if (elems.Length != exam_count + 1)
                {
                    Console.WriteLine("Invalid input.");
                    Console.ReadLine();
                    return new st1[0];
                }

                surname = elems[0];
                grades = new double[exam_count];

                for (int i = 1; i < elems.Length; i++)
                {
                    try_x = double.TryParse(elems[i], out grades[i - 1]);
                    if ((!try_x) || (grades[i - 1] < 0))
                    {
                        Console.WriteLine("Invalid input.");
                        Console.ReadLine();
                        return new st1[0];
                    }
                }

                st_info[ind] = new st1(surname, grades);
            }

            st1 temp;
            double max_average = st_info[0].average;
            int max_i = 0;

            for (int i = 0; i < n; i++)
            {
                max_average = st_info[i].average;
                max_i = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (st_info[j].average > max_average)
                    {
                        max_i = j;
                        max_average = st_info[j].average;
                    }

                }

                temp = st_info[i];
                st_info[i] = st_info[max_i];
                st_info[max_i] = temp;
            }

            return st_info;
        }
        static st2[] group_stats_2()
        {
            Console.WriteLine($"Enter the number of participants in the group.");

            int n;
            bool try_x;

            try_x = int.TryParse(Console.ReadLine(), out n);
            if (!try_x)
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return new st2[0];
            }

            Console.WriteLine();
            Console.WriteLine("Enter the information about participants.");
            Console.WriteLine("(Format: Ivanov 420.69)");

            st2[] st_info = new st2[n];
            string input;
            string[] elems;
            string surname;
            double time;


            for (int ind = 0; ind < n; ind++)
            {
                input = Console.ReadLine();
                elems = input.Split();

                if (elems.Length != 2)
                {
                    Console.WriteLine("Invalid input.");
                    Console.ReadLine();
                    return new st2[0];
                }

                surname = elems[0];

                try_x = double.TryParse(elems[1], out time);
                if ((!try_x) || (time <= 0))
                {
                    Console.WriteLine("Invalid input.");
                    Console.ReadLine();
                    return new st2[0];
                }

                st_info[ind].surname = surname;
                st_info[ind].time = time;
            }

            st2 temp;
            double min_time = st_info[0].time;
            int min_i = 0;

            return sort_st2(st_info);
        }
        static st2[] sort_st2(st2[] a)
        {
            st2 temp;
            double min_time = a[0].time;
            int min_i = 0;
            int n = a.Length;

            for (int i = 0; i < n; i++)
            {
                min_time = a[i].time;
                min_i = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (a[j].time < min_time)
                    {
                        min_i = j;
                        min_time = a[j].time;
                    }

                }

                temp = a[i];
                a[i] = a[min_i];
                a[min_i] = temp;
            }

            return a;
        }

        static void task_1_2()
        {
            Console.WriteLine("Task 1 level 2");

            st1[] st_info = group_stats(4);
            Array.Sort(st_info);
            
            foreach (st1 val in st_info)
            {
                if (val.average >= 4.0)
                {
                    Console.WriteLine();
                    Console.Write("Surname: ");
                    Console.Write($"{val.surname,-10}");
                    Console.Write("Average Grade: ");
                    Console.Write($"{val.average,-4:f2}");
                } 
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        static void task_2_2()
        {
            Console.WriteLine("Task 2 level 2");

            Console.WriteLine("Enter the number of students.");

            int n;
            bool try_x;

            try_x = int.TryParse(Console.ReadLine(), out n);
            if (!try_x)
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Enter the information about students.");
            Console.WriteLine("(Format: Ivanov 5 4 2)");

            st1[] st_info = new st1[n];
            string input;
            string[] elems;
            string surname;
            double[] grades;


            for (int ind = 0; ind < n; ind++)
            {
                input = Console.ReadLine();
                elems = input.Split();

                if (elems.Length != 4)
                {
                    Console.WriteLine("Invalid input.");
                    Console.ReadLine();
                    return;
                }

                surname = elems[0];
                grades = new double[3];

                for (int i = 1; i < elems.Length; i++)
                {
                    try_x = double.TryParse(elems[i], out grades[i - 1]);
                    if ((!try_x) || (grades[i - 1] < 2) || (grades[i - 1] > 5))
                    {
                        Console.WriteLine("Invalid input.");
                        Console.ReadLine();
                        return;
                    }

                    if (grades[i - 1] == 2)
                    {
                        grades = new double[3] { 0, 0, 0};
                        break;
                    }
                }

                st_info[ind] = new st1(surname, grades);
            }

            st1 temp;
            double max_average = st_info[0].average;
            int max_i = 0;

            for (int i = 0; i < n; i++)
            {
                max_average = st_info[i].average;
                max_i = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (st_info[j].average > max_average)
                    {
                        max_i = j;
                        max_average = st_info[j].average;
                    }

                }

                temp = st_info[i];
                st_info[i] = st_info[max_i];
                st_info[max_i] = temp;
            }

            foreach (st1 val in st_info)
            {
                if (val.average != 0)
                {
                    Console.WriteLine();
                    Console.Write("Surname: ");
                    Console.Write($"{val.surname,-10}");
                    Console.Write("Average Grade: ");
                    Console.Write($"{val.average,-4:f2}");
                }
            }

            Console.WriteLine();
            Console.ReadLine();
        }


        static void task_1_3()
        {
            Console.WriteLine("Task 1 level 3");

            st1[] st_info;

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Group {i}:");
                st_info = group_stats(5);

                foreach (st1 val in st_info)
                {
                    {
                        Console.WriteLine();
                        Console.Write("Surname: ");
                        Console.Write($"{val.surname,-10}");
                        Console.Write("Average Grade: ");
                        Console.Write($"{val.average,-4:f2}");
                    }
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }
        static void task_4_3()
        {
            Console.WriteLine("Task 4 level 3");

            Console.WriteLine("Group 1:");

            st2[] st_info = group_stats_2();
            for (int i = 0; i < st_info.Length; i++)
            {
                st2 val = st_info[i];

                Console.WriteLine();
                Console.Write("Surname: ");
                Console.Write($"{val.surname,-10}");
                Console.Write("Time: ");
                Console.Write($"{val.time,-10:f2}");
                Console.Write("Group Placement: ");
                Console.Write($"{i + 1}");
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Group 2:");

            st2[] st_info_2 = group_stats_2();
            for (int i = 0; i < st_info_2.Length; i++)
            {
                st2 val = st_info_2[i];

                Console.WriteLine();
                Console.Write("Surname: ");
                Console.Write($"{val.surname,-10}");
                Console.Write("Time: ");
                Console.Write($"{val.time,-10:f2}");
                Console.Write("Group Placement: ");
                Console.Write($"{i + 1}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Total:");

            int len1 = st_info.Length;
            int len2 = st_info_2.Length;

            st2[] st_info_3 = new st2[len1 + len2];
            for (int i = 0; i < st_info_3.Length; i++)
            {
                if (i < len1 )
                {
                    st_info_3[i].surname = st_info[i].surname;
                    st_info_3[i].time = st_info[i].time;
                }
                else
                {
                    st_info_3[i].surname = st_info_2[i - len1].surname;
                    st_info_3[i].time = st_info_2[i - len1].time;
                }
                
            }

            st_info_3 = sort_st2(st_info_3);

            for (int i = 0; i < st_info_3.Length; i++)
            {
                st2 val = st_info_3[i];
                Console.Write("Surname: ");
                Console.Write($"{val.surname,-10}");
                Console.Write("Time: ");
                Console.Write($"{val.time,-10:f2}");
                Console.Write("Total Placement: ");
                Console.Write($"{i + 1}");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
        static void task_6_3()
        {
            Console.WriteLine("Task 6 level 3");

            Console.WriteLine("Enter the number of answers.");

            int n;
            bool try_x;

            try_x = int.TryParse(Console.ReadLine(), out n);
            if (!try_x)
            {
                Console.WriteLine("Invalid input.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Enter the answers.");
            Console.WriteLine("(Format: Panda Talkative Sushi)");
            Console.WriteLine("(For a skipped question replace the answer with \"-\")");

            st3[] st_info = new st3[n];
            string input;
            string[] elems;
            string animal;
            string character;
            string item;


            for (int ind = 0; ind < n; ind++)
            {
                input = Console.ReadLine();
                elems = input.Split();

                if (elems.Length != 3)
                {
                    Console.WriteLine("Invalid input.");
                    Console.ReadLine();
                    return;
                }

                animal = elems[0];
                character = elems[1];
                item = elems[2];

                st_info[ind].animal = animal;
                st_info[ind].character = character;
                st_info[ind].item = item;
            }

            Dictionary<string, int> stats_animals = new Dictionary<string, int>();
            Dictionary<string, int> stats_characters = new Dictionary<string, int>();
            Dictionary<string, int> stats_items = new Dictionary<string, int>();

            for (int i = 0; i < st_info.Length; i++)
            {
                animal = st_info[i].animal;
                character = st_info[i].character;
                item = st_info[i].item;

                if (stats_animals.ContainsKey(animal))
                {
                    stats_animals[animal] += 1;
                }
                else if(animal != "-")
                {
                    stats_animals[animal] = 1;
                }


                if (stats_characters.ContainsKey(character))
                {
                    stats_characters[character] += 1;
                }
                else if(character != "-")
                {
                    stats_characters[character] = 1;
                }


                if (stats_items.ContainsKey(item))
                {
                    stats_items[item] += 1;
                }
                else if (item != "-")
                {
                    stats_items[item] = 1;
                }
            }

            /*Console.WriteLine();
            foreach (var val in stats_animals)
            {
                Console.WriteLine($"{val.Key}  {val.Value}");
            }

            Console.WriteLine();
            foreach (var val in stats_characters)
            {
                Console.WriteLine($"{val.Key}  {val.Value}");
            }

            Console.WriteLine();
            foreach (var val in stats_items)
            {
                Console.WriteLine($"{val.Key}  {val.Value}");
            }*/

            int number;
            int max_count;
            string max_answer;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Statistics:");
            Console.WriteLine();

            Console.WriteLine("Animals:");

            number = 5;
            if (stats_animals.Count < 5)
            {
                number = stats_animals.Values.Count;
            }

            for (int i = 1; i <= number; i++)
            {
                max_answer = "";
                max_count = 0;

                foreach (var val2 in stats_animals)
                {
                    if (val2.Value > max_count)
                    {
                        max_answer = val2.Key;
                        max_count = val2.Value;
                    }
                }

                Console.WriteLine($"{max_answer,-8} -    {max_count} times ({((max_count * 1.0) / n) * 100.0:f2} %)");

                stats_animals[max_answer] = 0;
            }

            Console.WriteLine();
            Console.WriteLine("Characteristics:");

            number = 5;
            if (stats_characters.Count < 5)
            {
                number = stats_characters.Values.Count;
            }

            for (int i = 1; i <= number; i++)
            {
                max_answer = "";
                max_count = 0;

                foreach (var val2 in stats_characters)
                {
                    if (val2.Value > max_count)
                    {
                        max_answer = val2.Key;
                        max_count = val2.Value;
                    }
                }

                Console.WriteLine($"{max_answer,-8} -    {max_count} times ({((max_count * 1.0) / n) * 100.0:f2} %)");

                stats_characters[max_answer] = 0;
            }

            Console.WriteLine();
            Console.WriteLine("Items/Ideas:");

            number = 5;
            if (stats_items.Count < 5)
            {
                number = stats_items.Values.Count;
            }

            for (int i = 1; i <= number; i++)
            {
                max_answer = "";
                max_count = 0;

                foreach (var val2 in stats_items)
                {
                    if (val2.Value > max_count)
                    {
                        max_answer = val2.Key;
                        max_count = val2.Value;
                    }
                }

                Console.WriteLine($"{max_answer,-8} -    {max_count} times ({((max_count * 1.0) / n) * 100.0:f2} %)");

                stats_items[max_answer] = 0;
            }

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            task_1_2();
            task_2_2();

            task_1_3();
            task_4_3();
            task_6_3();
        }
    }
}