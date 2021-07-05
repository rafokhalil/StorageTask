using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
namespace Storage
{
    abstract class Storage
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public double Speed { get; protected set; }
        public decimal Capacity { get; protected set; }
        public decimal Used { get; protected set; }
        public decimal FreeMemory() => Capacity - Used;
        public override string ToString()
        {
            string prnt()
            {

                Console.SetCursorPosition(40, 8);
                Console.WriteLine($"Name: {Name}\n\t\t\t\t\tModel: {Model}\n");
                return null;
            }
            return prnt();
        }
        public abstract void Copy(decimal size);
        public abstract void DeviceInfo();
        public void SizeAndSpeedInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(40, 11);
            Console.WriteLine($"Speed: {StorageSizeConverter.ConvertKbToMb((decimal)Speed):F} MBpS");
            Console.SetCursorPosition(40, 12);
            Console.WriteLine($"Capacity: {StorageSizeConverter.ConvertKbToGb(Capacity):F} GB");
            Console.SetCursorPosition(40, 13);
            Console.WriteLine($"Used: {StorageSizeConverter.ConvertKbToGb(Used):F} GB");
            Console.SetCursorPosition(40, 14);
            Console.WriteLine($"Free: {StorageSizeConverter.ConvertKbToGb(FreeMemory()):F} GB");
        }
        protected TimeSpan Calculate(decimal dataSize)
        {
            var t = (double)(StorageSizeConverter.ConvertGbToMb(dataSize) / StorageSizeConverter.ConvertKbToMb((decimal)Speed));
            return TimeSpan.FromSeconds(t);
        }
        public void ShowTransferTime(decimal dataSize)
        {
            var timespan = Calculate(dataSize);
            Console.SetCursorPosition(35, 11);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Data will be transfer in {timespan.Days} days, {timespan.Hours} hours, {timespan.Minutes} minutes, {timespan.Seconds} seconds, {timespan.Milliseconds} milliseconds.");
        }
    }
}
