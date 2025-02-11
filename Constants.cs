using System.Reflection;
using Sparker_Service.Utils;

namespace Sparker_Service;

public static class Constants
{
  public static readonly int DefaultServerPort = 13001;
  public static readonly string SettingsRegKey = @"Software\Sparker\Settings";
  public static readonly string UiAppBaseDirPath = UiAppLocationGetter.Get();
  public static readonly string PreferenceDirPath = Path.Combine(UiAppBaseDirPath, "ServicePreferences");
  public static readonly string LogDirPath = Path.Combine(UiAppBaseDirPath, "Logs");
}