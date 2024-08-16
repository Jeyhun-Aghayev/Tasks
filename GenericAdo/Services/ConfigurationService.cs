namespace GenericAdo.Services;

using Newtonsoft.Json.Linq;
public static class ConfigurationService
{
    public static void Configure()
    {
        string filePath = Path.Combine(Environment.CurrentDirectory, "Properties", "launchSetting.json");
        using StreamReader rd = new(filePath);


        var JObj = JObject.Parse(rd.ReadToEnd());


        var profiles = JObj["profiles"];

        if (profiles == null)
        {
            Console.WriteLine("No profiles found in the configuration file");
            return;
        }

        foreach (var profile in profiles.Children<JProperty>())
        {
            var environmentVariables = profile.Value["environmentVariables"]?.Children<JProperty>();
            if (environmentVariables != null)
            {
                foreach (var variable in environmentVariables)
                {
                    Environment.SetEnvironmentVariable(variable.Name, variable.Value.ToString());
                }
            }
        }
    }
}
