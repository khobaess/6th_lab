using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Windows.Markup;

class HelloWorld
{
    struct Sportsmens
    {
        public string Surname;
        public double[] rez1;
        public double[] rez2;
        public double obshrez;
        public Sportsmens(string surname1, double[] rez11, double[] rez22)
        {
            this.Surname = surname1;
            this.rez1 = rez11;
            this.rez2 = rez22;
            double obshrez1 = 0;
            for (int i = 0; i < 5; i++)
            {
                obshrez1 = obshrez1 + rez11[i];
                obshrez1 = obshrez1 + rez22[i];
            }
            this.obshrez = obshrez1;
        }
    }
    static int Main()
    {
        Console.WriteLine("Enter the number of sportsmens: ");
        int n;
        int.TryParse(Console.ReadLine(), out n);
        if (n <= 0) {Console.WriteLine("Incorrect data!!!"); return 0; }
        Sportsmens[] sportsmens = new Sportsmens[n];
        for (int i=0; i<n; i++)
        {
            Console.WriteLine("Enter the surname of sportmen number " + (i+1) + ":");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter the results of first jump of sportmen number " + (i+1) + ":");
            double[] rez11 = new double[5];
            string[] line;
            while(true)
            {
                line = Console.ReadLine().Split(" ");
                if (line.Length != 5) { Console.WriteLine("Re-enter the row!"); continue; }
                else break;
            }
            for (int j=0; j < 5; j++)
            {
                double x;
                if (double.TryParse(line[j], out x) == false) { Console.WriteLine("Incorrect data!!!"); return 0; }
                double.TryParse(line[j], out x);
                
                rez11[j] = x;
            }
            Console.WriteLine("Enter the results of second jump of sportmen number " + (i+1) + ":");
            double[] rez22 = new double[5];
            string[] line1;
            while (true)
            {
                line1 = Console.ReadLine().Split(" ");
                if (line1.Length != 5) { Console.WriteLine("Re-enter the row!"); continue; }
                else break;
            }
            for (int j = 0; j < 5; j++)
            {
                double x;
                if (double.TryParse(line1[j], out x) == false) { Console.WriteLine("Incorrect data!!!"); return 0; }
                double.TryParse(line1[j], out x);
                rez22[j] = x;
            }
            sportsmens[i] = new Sportsmens (surname, rez11, rez22);
        }
        List<double> A = new List<double> ();
        List<int> B = new List<int>();
        for (int i=0; i<n; i++)
        {
            A.Add(sportsmens[i].obshrez);
        }
        for (int i=0; i<n; i++)
        {
            for (int j=0; j<n; j++)
            {
                if (A[j] == A.Max()) { B.Add(j); A[j] = A.Min() - 1; }
            }
        }
        Console.WriteLine("The list of TOP: ");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(sportsmens[B[i]].Surname + " " + sportsmens[B[i]].obshrez);
            
        }

        return 0;
    }
}
