using System;
using System.Collections.Generic;
using System.Text;

namespace DevControlPanel.Common.Models
{
    public enum Culture
    {
        EN_US = 0x0409,
        ZH_TW = 0x0404,
    }

    public sealed class SystemOptions
    {
        public string RootDirectory { get; set; }

        public Culture CultureCode { get; set; }

        public string DataBase { get; set; }
    }
}
