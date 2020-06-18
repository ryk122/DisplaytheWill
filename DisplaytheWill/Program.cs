using System;
using System.IO;

namespace DisplaytheWill
{
    static class StartClass
    {
        static void Main(string[] args)
        {
            MainClass mc = new MainClass();

            Console.Write("Input Key to Close");
            Console.ReadKey();
        }
    }

    class MainClass
    {
        const string LOG_FILE_NAME = "time.log";
        public MainClass()
        {
            Read();
            //Display();
        }

        private void Read()
        {
            
            if (!File.Exists(LOG_FILE_NAME))
            {
                WriteFile(LOG_FILE_NAME, DateTime.Now.ToString());
            }

            string readText = File.ReadAllText(LOG_FILE_NAME);
            TimeCheck(readText);

            WriteFile(LOG_FILE_NAME, DateTime.Now.ToString());
            Console.WriteLine("Log In:"); 
            Console.WriteLine(readText);
        }

        private void WriteFile(string filename,string data)
        {
            StreamWriter writer;
            writer = new StreamWriter(filename);
            writer.WriteLine(data);
            writer.Close();
        }

        private void TimeCheck(string timeString)
        {
            DateTime saveData;

            if (DateTime.TryParse(timeString, out saveData))
            {
                Console.WriteLine("succeeded to get log");
            }
            else
            {
                Console.WriteLine("parse error!");
                return;
            }

            TimeSpan diffTime = DateTime.Now - saveData;

            Console.WriteLine("Last login is");
            Console.Write(diffTime);
            Console.WriteLine(" before.");

            if (diffTime.Seconds > 5)
            {
                Console.WriteLine("Long Time not Login.\n File is on Desktop");
                Display();
            }
            if (diffTime.Days > 5)
            {
                Console.WriteLine("Long Time not Login.\n File is on Desktop");
                Display();
            }
        }

        private void Display()
        {
            StreamWriter writer = new StreamWriter(System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Will.txt");
            writer.WriteLine("Will will be write here");
            writer.Close();

            System.Diagnostics.Process.Start("notepad.exe", System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Will.txt");
        }
    }
}
