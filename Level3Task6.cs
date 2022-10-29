using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO.Pipes;
using System.Net.Mail;
using System.Runtime.ExceptionServices;
using System.Windows.Markup;

class HelloWorld
{
    struct ans1
    {
        public string Answere;
        public ans1(string Answere)
        {
            this.Answere = Answere;
        }
    }
    struct ans2
    {
        public string Answere;
        public ans2(string Answere)
        {
            this.Answere = Answere;
        }
    }
    struct ans3
    {
        public string Answere;
        public ans3(string Answere)
        {
            this.Answere = Answere;
        }
    }
    struct surveyParticipant
    {
        public string Name;
        ans1 answer1;
        ans2 answer2;
        ans3 answer3;
        public surveyParticipant(string name, ans1 answere1, ans2 answere2, ans3 answere3)
        {
            this.Name = name;
            this.answer1 = answere1;
            this.answer2 = answere2;
            this.answer3 = answere3;
        }
    }
    static int Main()
    {
        Console.WriteLine("Enter the number of survey participant: ");
        int n;
        int.TryParse(Console.ReadLine(), out n);
        if (n <= 4) { Console.WriteLine("Incorrect data!!!"); return 0; }
        ans1[] answe1 = new ans1[n];
        ans2[] answe2 = new ans2[n];
        ans3[] answe3 = new ans3[n];
        surveyParticipant[] participants = new surveyParticipant[n];
        for (int i=0; i<n; i++)
        {
            Console.WriteLine("Enter the Name of participant number " + (i+1) + " :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the answere for question 'What animal do you associate with Japan and the Japanese?' of participant <" + name +">:");
            Console.WriteLine("If there is no answere, then enter '-'.");
            string answer1 = Console.ReadLine();
            Console.WriteLine("Enter the answere for question 'What character trait is inherent in the Japanese the most?' of participant <" + name + ">:");
            Console.WriteLine("If there is no answere, then enter '-'.");
            string answer2 = Console.ReadLine();
            Console.WriteLine("Enter the answere for question 'What inanimate object or concept do you associate with Japan?' of participant <" + name + ">:");
            Console.WriteLine("If there is no answere, then enter '-'.");
            string answer3 = Console.ReadLine();
            //if (name == null || answer1 == null || answer2==null || answer3 == null) { Console.WriteLine("Incorrect data!!!"); return 0; }
            answe1[i] = new ans1(answer1);
            answe2[i] = new ans2(answer2);
            answe3[i] = new ans3(answer3);
            participants[i] = new surveyParticipant(name, answe1[i], answe2[i], answe3[i]);
        }
        string[] a1 = new string[n];
        string[] a2 = new string[n];
        string[] a3 = new string[n];
        double[] ind1 = new double[n];
        double[] ind2 = new double[n];
        double[] ind3 = new double[n];
        double[] itog1 = new double[10];
        double[] itog2 = new double[10];
        double[] itog3 = new double[10];
        for (int i=0; i<n; i++)
        {
            a1[i] = answe1[i].Answere;
            a2[i] = answe2[i].Answere;
            a3[i] = answe3[i].Answere;
            ind1[i] = 0;
            ind2[i] = 0;
            ind3[i] = 0;
            itog1[i] = 0;
            itog2[i] = 0;
            itog3[i] = 0;
        }


        for (int i=0; i<n; i++)
        {
            string buffer1;
            buffer1 = a1[i];
            for (int j=0; j<n; j++)
            {
                if (buffer1 == "-") break;
                if (a1[j] == buffer1) { a1[j] = "-"; ind1[i]++; }
            }
            buffer1 = a2[i];
            for (int j = 0; j < n; j++)
            {
                if (buffer1 == "-") break;
                if (a2[j] == buffer1) { a2[j] = "-"; ind2[i]++; }
            }
            buffer1 = a3[i];
            for (int j = 0; j < n; j++)
            {
                if (buffer1 == "-") break;
                if (a3[j] == buffer1) { a3[j] = "-"; ind3[i]++; }
            }
        }

        double sum1 = 0;
        double sum2 = 0;
        double sum3 = 0;
        for (int i=0; i<n; i++)
        {
            sum1 = sum1 + ind1[i];
            sum2 = sum2 + ind2[i];
            sum3 = sum3 + ind3[i];
        }
        for (int i=0; i<5; i++)
        {
            for (int j=0; j<n; j++)
            {
                if (ind1[j] == ind1.Max()) { itog1[i] = j; itog1[5+i] = ind1[j]; ind1[j] = ind1.Min() - 1; break; }
            }
            for (int j = 0; j < n; j++)
            {
                if (ind2[j] == ind2.Max()) { itog2[i] = j; itog2[5 + i] = ind2[j]; ind2[j] = ind2.Min() - 1; break; }
            }
            for (int j = 0; j < n; j++)
            {
                if (ind3[j] == ind3.Max()) { itog3[i] = j; itog3[5 + i] = ind3[j]; ind3[j] = ind3.Min() - 1; break; }
            }
        }
        int v1 = 0;
        int v2 = 0;
        int v3 = 0;
        for (int i=0; i<5; i++)
        {
            if (itog1[i + 5] > 0) v1++;
            if (itog2[i + 5] > 0) v2++;
            if (itog3[i + 5] > 0) v3++;
        }
        if (v1 > 0)
        {
            Console.WriteLine("Statistics on the first question: ");
            for (int j = 0; j < v1; j++)
            {
                Console.WriteLine(answe1[Convert.ToInt32(itog1[j])].Answere + " - " + (itog1[j + 5] / sum1 * 100) + "%.");
            }
        }
        if (v2 > 0)
        {
            Console.WriteLine("Statistics on the second question: ");
            for (int j = 0; j < v2; j++)
            {
                Console.WriteLine(answe2[Convert.ToInt32(itog2[j])].Answere + " - " + (itog2[j + 5] / sum2 * 100) + "%.");
            }
        }
        if (v3 > 0)
        {
            Console.WriteLine("Statistics on the third question: ");
            for (int j = 0; j < v3; j++)
            {
                Console.WriteLine(answe3[Convert.ToInt32(itog3[j])].Answere + " - " + (itog3[j + 5] / sum3 * 100) + "%.");
            }
        }
        return 0;
    }
}
