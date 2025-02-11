using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Sparker_Service.LocalServices.Routes.Info;
using Sparker_Service.LocalServices.Routes.Power;
using Sparker_Service.LocalServices.Routes.Settings;

namespace Sparker_Service.LocalServices;

// Info
[JsonSerializable(typeof(InfoRoute.BasicInfo))]
[JsonSerializable(typeof(InfoRoute.ApproachArguments))]
[JsonSerializable(typeof(InfoRoute.ApproachInfo))]

// Power
[JsonSerializable(typeof(PowerRoute.ShutdownArguments))]
[JsonSerializable(typeof(PowerRoute.SleepArguments))]
[JsonSerializable(typeof(Task<IResult>))]

// Settings
[JsonSerializable(typeof(SettingsRoute.SettingValue<bool>))]
[JsonSerializable(typeof(SettingsRoute.SettingValue<bool?>))]
public partial class LocalServicesJsonGenContext : JsonSerializerContext;
