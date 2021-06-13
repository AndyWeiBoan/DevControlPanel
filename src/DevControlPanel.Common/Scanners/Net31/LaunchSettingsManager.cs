using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DevControlPanel.Common.Scanners.Net31
{
    internal sealed class LaunchSetting
    {
        [JsonProperty("commandName")]
        public string CommandName { get; set; }

        [JsonProperty("launchBrowser")]
        public bool LaunchBrowser { get; set; }

        [JsonProperty("applicationUrl")]
        public string ApplicationUrl { get; set; }

        [JsonProperty("environmentVariables.ASPNETCORE_ENVIRONMENT")]
        public string EnvironmentVariables { get; set; }

        [JsonIgnore]
        public string Name { get; set; }
    }

    internal sealed class LaunchSettingApplyResult
    {
        public bool Success { get; set; }
        public string FailureReason { get; set; }
        public LaunchSetting LaunchSetting { get; set; }
    }

    internal static class LaunchSettingsManager
    {

        const string profiles = "profiles";
        const string environmentVariablesToken = "environmentVariables";

        internal static async ValueTask<LaunchSettingApplyResult> GetAppliedResultAsync(string launchFilePath)
        {
            if (!File.Exists(launchFilePath))
            {
                return new LaunchSettingApplyResult { Success = false, FailureReason = $"file not exist: {launchFilePath} " };
            }

            var jsonString = await File.ReadAllTextAsync(launchFilePath);
            if (string.IsNullOrEmpty(jsonString))
            {
                return new LaunchSettingApplyResult { Success = false, FailureReason = $"file no content: {launchFilePath} " };
            }
            try
            {
                var jObj = JObject.Parse(jsonString);
                if(!jObj.TryGetValue(profiles, out var profilesToken))
                {
                    return new LaunchSettingApplyResult { Success = false, FailureReason = $"No {profiles} object: {launchFilePath} " };
                }

                var child = profilesToken.Children<JProperty>().FirstOrDefault();
                if (child == default)
                {
                    return new LaunchSettingApplyResult { Success = false, FailureReason = $"{profiles} no content: {launchFilePath} " };
                }

                var setting = child.Value.ToObject<LaunchSetting>();
                if (setting == default) 
                {
                    return new LaunchSettingApplyResult { Success = false, FailureReason = $"{profiles} parse error: {launchFilePath} " };
                };

                var envToken = child.Value.SelectToken(environmentVariablesToken);
                if (envToken != default)
                {
                    setting.EnvironmentVariables = envToken.Value<string>("ASPNETCORE_ENVIRONMENT");
                }
                setting.Name = child.Name;

                return new LaunchSettingApplyResult
                {
                    LaunchSetting = setting,
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                return new LaunchSettingApplyResult { 
                    Success = false, 
                    FailureReason = $"{ex.Message}: {launchFilePath}" 
                };
            }
        }
    }
}
