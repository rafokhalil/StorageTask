using System;
using System.Collections.Generic;
using System.Text;
namespace Storage
{
    public interface IDataTransferTimeCalculate
    {
        TimeSpan Calculate(decimal dataSize);
    }
}
