using System;
using System.Threading;
using System.Text;
namespace Storage
{
    enum MainMenuOptions
    {
        HDD = 1, SSD, FLASH, DVD, BACK
    }
    enum StorageMenuOptions
    {
        TRANSFERDATA = 1, TRANSFERTIME, DEVICEINFO, BACK
    }
    public static class ConsoleScreen
    {
        public static string[] MainMenuOptions { get; set; }
        public static string[] StorageMenuOptions { get; set; }
        static ConsoleScreen()
        {
            MainMenuOptions = new string[] { "HDD", "SSD", "FLASH", "DVD", "Back" };
            StorageMenuOptions = new string[] { "Transfer data", "Show how long the transfer will take", "Device Info", "Back" };
        }
        public static int InputChoice(int length)
        {
            while (true)
            {
                Console.SetCursorPosition(40, 15);
                Console.Write(">> ");
                var status = int.TryParse(Console.ReadLine(), out int choice);
                if (status)
                {
                    if (choice > 0 && choice <= length)
                        return choice;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Input must be between [ 1 - {length} ]!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter numeric value!");
                }
                Console.ResetColor();
            }
        }
        public static decimal InputDataSize()
        {
            while (true)
            {
                Console.Write(">> ");
                var status = decimal.TryParse(Console.ReadLine(), out decimal size);
                if (status)
                {
                    return size;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter numeric value!");
                    Console.ResetColor();
                }
            }
        }
        public static void PrintMenu(string[] options)
        {
            int c = 10;
            for (int i = 0; i < options.Length; i++, c++)
            {
                Console.SetCursorPosition(40, c);
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.ResetColor();
        }
        public static void Clear()
        {
            Console.WriteLine("Press enter to continue!");
            Console.ReadLine();
            Console.Clear();
        }
        public static void WriteBlinkingText(string text, int delay, bool visible)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            //if (visible)
            //    Console.Write(text);
            //else
            //    for (int i = 0; i < text.Length; i++)
            //        Console.Write(" ");
            //Console.CursorLeft -= text.Length;
            //System.Threading.Thread.Sleep(delay);
            int c = 3;
            while (c > 0)
            {
                Console.Write(text);
                Thread.Sleep(1000);
                for (int j = 1; j <= text.Length + 2; j++)
                {
                    Console.Write("\b" + (char)32 + "\b");
                    if (j == text.Length + 2) Thread.Sleep(650);
                }
                c--;
            }
        }
    }
}
