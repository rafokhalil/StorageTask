﻿using System;
using System.Collections.Generic;
using System.Text;
namespace Storage
{
    static class StorageSizes
    {
        public static string Kb => "KB";
        public static string Mb => "MB";
        public static string Gb => "GB";
        public static string Tb => "TB";
        public static decimal MbToKb => 1024;
        public static decimal GbToKb => 1024 * 1024;
        public static decimal GbToMB => 1024;
        public static decimal TbToKb => 1024 * 1024 * 1024;
    }
}
