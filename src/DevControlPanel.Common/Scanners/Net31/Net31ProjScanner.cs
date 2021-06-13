using System.Collections.Generic;
using System.IO;
using DevControlPanel.Common.Models;

namespace DevControlPanel.Common.Scanners.Net31
{
    public sealed class Net31ProjScanner : IProjScanner<Net31Configuration>
    {
        async IAsyncEnumerable<Project<Net31Configuration>> IProjScanner<Net31Configuration>.GetProjectsAsync(string rootDirectory)
        {

            foreach (var proj in Directory.EnumerateFiles(rootDirectory, @"*.*proj", SearchOption.AllDirectories))
            {
                var dir = Directory.GetParent(proj);
                var launchFile = Path.Combine(dir.FullName, @"Properties\launchSettings.json");

                if (!File.Exists(launchFile)) continue;

                var result = await LaunchSettingsManager.GetAppliedResultAsync(launchFile);

                if (!result.Success) continue;

                yield return new Project<Net31Configuration>
                {
                    Path = proj,
                    Name = result.LaunchSetting.Name,
                    Configuration = new Net31Configuration
                    {
                        host = result.LaunchSetting.ApplicationUrl,
                        CommandName = result.LaunchSetting.CommandName,
                        EnvironmentVariables = result.LaunchSetting.EnvironmentVariables,
                        LaunchBrowser = result.LaunchSetting.LaunchBrowser,
                    }
                };
            }
        }
    }
}
