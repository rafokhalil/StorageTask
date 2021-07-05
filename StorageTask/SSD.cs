using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;
namespace Storage
{
    class SSD : Flash
    {
        public SSD(decimal capacity, double speed) : base(capacity, speed)
        {
        }
        public override void Copy(decimal size)
        {
            if (size > FreeMemory())
                throw new InsufficientMemoryException("There is no sufficient memory in SSD!");
            Used += size;
            Thread.Sleep(Convert.ToInt32(Calculate(StorageSizeConverter.ConvertKbToGb(size)).TotalSeconds) * 1000);
        }
        public override void DeviceInfo()
        {
            Console.SetCursorPosition(40, 7);
            Console.WriteLine("----------- SSD Info ----------- ");
            Console.WriteLine(this);
            this.SizeAndSpeedInfo();
        }
    }
}
