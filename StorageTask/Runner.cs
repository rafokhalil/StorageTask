using System;
using System.Collections.Generic;
using System.Text;
namespace Storage
{
    public class Runner
    {
        public static void Runnerr()
        {
            Storage[] storageDisks =
            {
                new HDD(1024 * 1024 * 1024, 1024 * 210) {Name = "Seagate FireCuda Gaming (ST1000DX002)", Model = "Seagate"},
                new SSD(1024 * 1024 * 512, 1024*3480) {Name = "Gigabyte Aorus RGB (GP-ASM2NE2512GTTDR)", Model = "Gigabyte"},
                new Flash(1024 * 1024 * 64, 1024*1024*5) {Name = "Kingston DataTraveler SE9 DTSE9G2", Model = "Kingston"},
                new DVD(1024 * 1024 * 4, 1024*2) {Name = "Samsung DVD-R 4.7GB", Model = "Samsung"},
                };
            while (true)
            {
                Console.SetCursorPosition(40, 11);

                ConsoleScreen.WriteBlinkingText(" WELCOME TO THE COMPROLE, USER ! ", 4000, true);
                Console.Clear();
                Console.SetCursorPosition(40, 11);
                Console.WriteLine("Enter data size [GB] : ");
                Console.SetCursorPosition(40, 12);
                var dataSize = ConsoleScreen.InputDataSize();
                Console.Clear();
                var mainMenuLoop = true;
                while (mainMenuLoop)
                {
                    ConsoleScreen.PrintMenu(ConsoleScreen.MainMenuOptions);
                    var mainMenuChoice = ConsoleScreen.InputChoice(ConsoleScreen.MainMenuOptions.Length);
                    Console.Clear();
                    if ((MainMenuOptions)mainMenuChoice == MainMenuOptions.BACK)
                        break;
                    var storageMenuLoop = true;
                    while (storageMenuLoop)
                    {
                        ConsoleScreen.PrintMenu(ConsoleScreen.StorageMenuOptions);
                        var storageMenuChoice = ConsoleScreen.InputChoice(ConsoleScreen.StorageMenuOptions.Length);
                        Console.Clear();
                        switch ((StorageMenuOptions)storageMenuChoice)
                        {
                            case StorageMenuOptions.TRANSFERDATA:
                                {
                                    try
                                    {
                                        Console.SetCursorPosition(40, 11);
                                        Console.WriteLine("Data transfering started.");
                                        storageDisks[mainMenuChoice - 1].ShowTransferTime(dataSize);
                                        storageDisks[mainMenuChoice - 1].Copy(StorageSizeConverter.ConvertGbToKb(dataSize));
                                        Console.SetCursorPosition(40, 14);
                                        Console.WriteLine("Operation completed!");
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    ConsoleScreen.Clear();
                                    break;
                                }
                            case StorageMenuOptions.TRANSFERTIME:
                                {
                                    storageDisks[mainMenuChoice - 1].ShowTransferTime(dataSize);
                                    ConsoleScreen.Clear();
                                    break;
                                }
                            case StorageMenuOptions.DEVICEINFO:
                                {
                                    storageDisks[mainMenuChoice - 1].DeviceInfo();
                                    ConsoleScreen.Clear();
                                    break;
                                }
                            case StorageMenuOptions.BACK:
                                {
                                    storageMenuLoop = false;
                                    break;
                                }
                        }
                    }
                }
            }
        }
    }
}
