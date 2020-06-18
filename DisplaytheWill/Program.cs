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
            Read();
            Display();
            
        }

        private void Read()
        {
            if (!File.Exists("test.txt"))
            {
                StreamWriter writer = new StreamWriter("test.txt");
                writer.WriteLine("File created using StreamWriter class.");
                writer.Close();
            }
            string readText = File.ReadAllText("test.txt");
            Console.WriteLine(readText);
        }

        private void Display()
        {
            StreamWriter writer = new StreamWriter("E:\\KBTest.txt");
            writer.WriteLine("File created using StreamWriter class.");
            writer.Close();
        }
    }
}
