﻿using System;
using System.Collections.Generic;
using System.Text;
namespace Storage
{
    static class StorageSizeConverter
    {
        public static decimal ConvertKbToMb(decimal kb)
        {
            return kb / StorageSizes.MbToKb;
        }
        public static decimal ConvertKbToGb(decimal kb)
        {
            return kb / StorageSizes.GbToKb;
        }
        public static decimal ConvertKbToTb(decimal kb)
        {
            return kb / StorageSizes.TbToKb;
        }
        public static decimal ConvertGbToKb(decimal gb)
        {
            return gb * StorageSizes.GbToKb;
        }
        public static decimal ConvertGbToMb(decimal gb)
        {
            return gb * StorageSizes.GbToMB;
        }
    }
}
