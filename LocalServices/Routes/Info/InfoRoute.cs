using Sparker_Service.Utils;

namespace Sparker_Service.LocalServices.Routes.Info;



public static class InfoRoute
{
  public record ApproachArguments(bool WithMacAddress = false);
  public record ApproachInfo(bool Reached = true, string? MacAddress = null);
  public record BasicInfo(string? MacAddress, bool? HibernateEnabled);

  public static ApproachInfo Approach(ApproachArguments args)
  {
    var macAddress = args.WithMacAddress ? NetworkUtils.GetEthernetMacAddress() : null;
    return new ApproachInfo(MacAddress: macAddress);
  }
  
  public static BasicInfo GetBasicInfo()
  {
    var macAddress = NetworkUtils.GetEthernetMacAddress();
    return new BasicInfo(macAddress, PowerManager.IsHibernateEnabled());
  }
}
