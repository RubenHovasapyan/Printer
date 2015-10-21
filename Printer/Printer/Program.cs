using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.Threading;

namespace deleted
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer p1 = new Printer();
            p1.PrintStarted += P1_PrintStarted;
            p1.Printing += P1_Printing;
            p1.PrintFinished += P1_PrintFinished;
            p1.Print(5);
        }

        private static void P1_PrintFinished(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void P1_Printing(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void P1_PrintStarted(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class Printer
    {
        public delegate void PrinterDelegate(string msg);
        public event PrinterDelegate PrintStarted;
        public event PrinterDelegate Printing;
        public event PrinterDelegate PrintFinished;

        public void Print(int numPages)
        {
            if (PrintStarted != null)
            {
                PrintStarted("Print started...");
                Console.WriteLine("--------------------");
            }
            if (Printing != null)
            {
                for (int i = 1; i <= numPages; i++)
                {
                    Thread.Sleep(1000);
                    Printing(string.Format($"printing {i} out of {numPages}"));
                }
                Console.WriteLine("--------------------");
            }
            if (PrintFinished != null)
            {
                PrintFinished("Print has been finished!");
            }
        }
    }
}
