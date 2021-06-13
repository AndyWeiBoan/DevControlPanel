﻿namespace DevControlPanel.Common.Models
{
    public sealed class Net31Configuration : ProjectConfiguration
    {
        public string host { get; set; }
        public string CommandName { get; set; }
        public bool LaunchBrowser { get; set; }
        public string EnvironmentVariables { get; set; }
    }
}