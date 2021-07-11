using Microsoft.Extensions.Options;
using System;

namespace ConsoleApp4
{
  public class BikeService : BaseVehicleSerive
  {
    private MainReportInformationSettings _mainReportInformationSettings;
    private IGenerationService _generationService;
    public BikeService(IOptions<ApplicationSettings> appSettings, IGenerationService generationService)
    {
      _mainReportInformationSettings = appSettings.Value.SimpleReportInformation;
      _generationService = generationService;
    }

    public override BaseVehicleSerive BuildService(string weel)
    {
      base.Weels = weel;
      base.GetFileConfigFiles();
      return this;
    }

    public override void Display()
    {
      Console.WriteLine("DefaultConfigFileName =>"+_mainReportInformationSettings.DefaultConfigFileName);
      _generationService.Generation();
      Console.WriteLine("Bike service display weels =>" + Weels);
    }
  }


}


