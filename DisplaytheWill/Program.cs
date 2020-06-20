using System;
using System.IO;

namespace DisplaytheWill
{
    static class StartClass
    {
        static void Main(string[] args)
        {
            MainClass mc = new MainClass();

            //Console.Write("Input Key to Close");
            //Console.ReadKey();
        }
    }

    class MainClass
    {
        const string CONFIG_FILE_NAME = "config.ini";
        const string WILL_FILE_NAME = "will.txt";
        const string LOG_FILE_NAME = "time.log";

        private int timeOutDay = 5;

        public MainClass()
        {
            CheckWillFile();
            ReadConfig();
            ReadLog();
        }

        private void CheckWillFile()
        {
            if (!File.Exists(WILL_FILE_NAME))
            {
                Console.WriteLine("Not found config the Will! \n Plaese check it.");
                WaitKey("Input Key to Close");
                Environment.Exit(-1);
            }
        }

        private void ReadConfig()
        {
            if (!File.Exists(CONFIG_FILE_NAME))
            {
                Console.WriteLine("Not found config file! \n Using default setting");
                WaitKey("Input Key to Continue");
            }
        }

        private void ReadLog()
        {    
            if (!File.Exists(LOG_FILE_NAME))
            {
                WriteFile(LOG_FILE_NAME, DateTime.Now.ToString());
            }

            string readText = File.ReadAllText(LOG_FILE_NAME);
            TimeCheck(readText);

            
            Console.WriteLine("Log In:");
            WriteFile(LOG_FILE_NAME, DateTime.Now.ToString());
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
                Console.WriteLine("Log file was deleted and newed");
                WriteFile(LOG_FILE_NAME, DateTime.Now.ToString());
                WaitKey("Input Key to Continue");
            }

            TimeSpan diffTime = DateTime.Now - saveData;

            Console.WriteLine("Last login is");
            Console.Write(diffTime);
            Console.WriteLine(" before.");

            if (diffTime.Days > timeOutDay)
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

        private void WaitKey(string message)
        {
            Console.Write(message);
            Console.ReadKey();
        }
    }
}
