using System;
using System.IO;

namespace DisplaytheWill
{
    static class StartClass
    {
        static void Main(string[] args)
        {
            MainClass mc = new MainClass();
            Console.ReadKey();
        }
    }

    class MainClass
    {
        public MainClass()
        {
            Console.WriteLine("new class");

            StreamWriter writer = new StreamWriter("E:\\KBTest.txt");
            writer.WriteLine("File created using StreamWriter class.");
            writer.Close();
        }
    }
}
