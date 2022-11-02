using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Mail;
using System.Runtime.ExceptionServices;
using System.Windows.Markup;

class HelloWorld
{
    static Sportsmens[] Sorti(Sportsmens[] A)
    {
        int left = 0;
        int right = A.Length - 1;

        while (left < right)
        {
            for (int i = left; i < right; i++)
            {
                if (A[i].obshrez < A[i + 1].obshrez)
                {
                    Sportsmens x = A[i];
                    A[i] = A[i + 1];
                    A[i + 1] = x;
                }

            }
            right--;

            for (int i = right; i > left; i--)
            {
                if (A[i - 1].obshrez < A[i].obshrez)
                {
                    Sportsmens x = A[i];
                    A[i] = A[i - 1];
                    A[i - 1] = x;
                }
            }
            left++;
        }
        return A;
    }
    struct Sportsmens
    {
        public string Surname;
        public double kollvowin;
        public double kollvodraw;
        public double kollvoloss;
        public double obshrez;
        public double schetobshrez(double kollvowin, double kollvodraw, double kollvoloss)
        {
            return obshrez = kollvowin * 1 + kollvoloss * 0 + kollvodraw * 0.5;
        }
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
        if (n <= 0) { Console.WriteLine("Incorrect data!!!"); return 0; }
        Sportsmens[] sportsmens = new Sportsmens[n];
        for (int i = 0; i < n; i++)
        {
            int kollvowin = 0;
            int kollvodraw = 0;
            int kollvoloss = 0;
            Console.WriteLine("Enter the surname of participant number " + (i + 1) + ":");
            string surname = Console.ReadLine();
            sportsmens[i] = new Sportsmens(surname, kollvowin, kollvodraw, kollvoloss);
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                Console.WriteLine("Enter the result of mathes <" + sportsmens[i].Surname + "> VS <" + sportsmens[j].Surname + ">:");
                Console.WriteLine("If the result of the match is a draw, then write a <Draw>, otherwise write a <Win> if the match ended in defeat for the first team, or a <Loss> if the match ended in defeat for the first team.");
                bool ae = false;
                string line;
                line = Console.ReadLine();
                if (line == "Win")
                {
                    ae = true;
                    sportsmens[i].kollvowin++;
                    sportsmens[j].kollvoloss++;
                }
                if (line == "Draw")
                {
                    ae = true;
                    sportsmens[i].kollvodraw++;
                    sportsmens[j].kollvodraw++;
                }
                if (line == "Loss")
                {
                    ae = true;
                    sportsmens[j].kollvowin++;
                    sportsmens[i].kollvoloss++;
                }
                if (ae == false) { Console.WriteLine("Incorrect data!!!"); return 0; }
            }
        }
        for (int i = 0; i < n; i++)
        {
            sportsmens[i].schetobshrez(sportsmens[i].kollvowin, sportsmens[i].kollvodraw, sportsmens[i].kollvoloss);
        }
        Sorti(sportsmens);
        Console.WriteLine("The list of TOP: ");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(sportsmens[i].Surname + " - " + sportsmens[i].kollvowin);

        }

        return 0;
    }
}
