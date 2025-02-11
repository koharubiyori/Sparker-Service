using Microsoft.AspNetCore.Http;
using Sparker_Service.Preferences;

namespace Sparker_Service.LocalServices.Routes.Settings;

public static class SettingsRoute
{
  public record SettingValue<T>(T Value);
  
  public static SettingValue<bool> SetLanOnly(SettingValue<bool?> args)
  {
    if (args.Value != null)
    {
      Preference.Settings.LanOnly = (bool)args.Value;
    }
    
    return new SettingValue<bool>(Preference.Settings.LanOnly);
  }
}