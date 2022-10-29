using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Mail;
using System.Runtime.ExceptionServices;
using System.Windows.Markup;

class HelloWorld
{
    struct Sportsmens
    {
        public string Surname;
        public double kollvowin;
        public double kollvodraw;
        public double kollvoloss;
        public double obshrez;
        public Sportsmens(string surname1, double kollvowin, double kollvodraw, double kollvoloss)
        {
            this.Surname = surname1;
            this.kollvowin = kollvowin;
            this.kollvodraw = kollvodraw;
            this.kollvoloss = kollvoloss;
            this.obshrez = kollvowin * 1 + kollvoloss * 0 + kollvodraw * 0.5;
        }
    }
    static int Main()
    {
        Console.WriteLine("Enter the number of participant: ");
        int n;
        int.TryParse(Console.ReadLine(), out n);
        Console.WriteLine("Enter the number of matches for one participant of the tournament: ");
        int m;
        int.TryParse(Console.ReadLine(), out m);
        if (n <= 0 || m<=0) {Console.WriteLine("Incorrect data!!!"); return 0; }
        Sportsmens[] sportsmens = new Sportsmens[n];
        for (int i=0; i<n; i++)
        {
            int kollvowin = 0;
            int kollvodraw = 0;
            int kollvoloss = 0;
            bool ae;
            Console.WriteLine("Enter the surname of participant number " + (i+1) + ":");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter the results of matches for participant number " + (i+1) + ":");
            string[] line;
            while(true)
            {
                line = Console.ReadLine().Split(" ");
                if (line.Length != m) { Console.WriteLine("Re-enter the row!"); continue; }
                else break;
            }
            for (int j=0; j < m; j++)
            {
                ae = false;
                if (line[j] == "Win") { kollvowin++; ae = true; }
                if (line[j] == "Draw") { kollvodraw++; ae = true; }
                if (line[j] == "Loss") { kollvoloss++; ae = true; }
                if (ae == false) { Console.WriteLine("Incorrect data!!!"); return 0; }

            }
            sportsmens[i] = new Sportsmens (surname, kollvowin, kollvodraw, kollvoloss);
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
