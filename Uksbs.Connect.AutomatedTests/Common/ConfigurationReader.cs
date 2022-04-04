using Microsoft.Extensions.Configuration;

namespace Uksbs.Connect.AutomatedTests.Common
{
    public static class ConfigurationReader
    {
        private static string currentEnvironment;
        public static void Read()
        {
           var config= ReadConfigurationRoot();
            currentEnvironment = config.GetSection("ENVIRONMENT_SETTINGS").GetValue<string>("CURRENT_ENVIRONMENT_SETTINGS");
            var appSettingsSection = config.GetSection(currentEnvironment);
            Settings.ConnectWebUrl = appSettingsSection.GetValue<string>("connectWebUrl");
            Settings.EmpUserName = appSettingsSection.GetValue<string>("empUserName");
            Settings.EmpPassword = appSettingsSection.GetValue<string>("empPassword");
            Settings.MgrUserName = appSettingsSection.GetValue<string>("mgrUserName");
            Settings.MgrPassword = appSettingsSection.GetValue<string>("mgrPassword");
            Settings.HeadlessBrowser = appSettingsSection.GetValue<bool>("headlessBrowser");
            Settings.Test = appSettingsSection.GetValue<string>("test");

        }
        private static IConfigurationRoot ReadConfigurationRoot()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                             .AddJsonFile("appsettings.secret.json", optional: true, reloadOnChange: true)
                                             .Build();
        }
    }
}
