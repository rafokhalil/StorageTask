using System;
using System.Collections.Generic;
using System.Text;
namespace Storage
{
    class InsufficientMemoryException : ApplicationException
    {
        public DateTime ErrorTime { get; set; }
        public InsufficientMemoryException(string message) : base(message)
        {
            ErrorTime = DateTime.Now;
        }
    }
}
