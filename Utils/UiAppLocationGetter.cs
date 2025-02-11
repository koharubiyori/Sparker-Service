using Microsoft.Win32;

namespace Sparker_Service.Utils;

public static class UiAppLocationGetter
{
  private const string RegValueName = "InstallLocation";

  public static string Get()
  {
    var registryKey = Registry.LocalMachine.CreateSubKey(Constants.SettingsRegKey);
    var value = registryKey.GetValue(RegValueName);
    if (value == null) throw new Exception("Failed to get UI app location");
    return registryKey.GetValue(RegValueName)!.ToString()!;
  }
}