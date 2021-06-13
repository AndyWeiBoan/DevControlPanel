using DevControlPanel.Common.Models;
using System.Collections.Generic;

namespace DevControlPanel.Common.Scanners
{
    public interface IProjScanner<TConfiguration> where TConfiguration : ProjectConfiguration
    {
        IAsyncEnumerable<Project<TConfiguration>> GetProjectsAsync(string rootDirectory);
    }
}
