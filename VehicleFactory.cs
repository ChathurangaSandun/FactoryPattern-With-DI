using Microsoft.Extensions.Options;
using System;

namespace ConsoleApp4
{
  public class VehicleFactory : IVehicleFactory
  {
    private readonly Func<BikeService>  _bikeService;
    private readonly Func<CarService> _carService;
    private readonly MainReportInformationSettings _mainInfo;

    public VehicleFactory(Func<BikeService> bikeService, Func<CarService> carService, IOptions<ApplicationSettings> appSettings)
    {
      _bikeService = bikeService;
      _carService = carService;
      _mainInfo = appSettings.Value.SimpleReportInformation;
    }
    
    public BaseVehicleSerive Create(VehicleTypes type, string weel)
    {
      BaseVehicleSerive vehicleService = null;
      switch (type)
      {
        case VehicleTypes.Bike:
          vehicleService = _bikeService.Invoke().BuildService(weel); // using a func
          break;
        case VehicleTypes.Car:
          vehicleService = _carService.Invoke();
          break;
      }

      return vehicleService;
    }
  }
}


