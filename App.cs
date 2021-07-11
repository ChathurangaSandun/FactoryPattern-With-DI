using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp4.Program;

namespace ConsoleApp4
{
  public class App
  {
    private IVehicleFactory vehicleFactory;

    public App(IVehicleFactory vehicleFactory)
    {
      this.vehicleFactory = vehicleFactory;
    }
  
    public int Run(string subProcess, string[] parameters)
    {      
      string reportCode = parameters[0]; // Get report code
      switch (subProcess)
      {
        case "Car" or "Bike":          
          var vehicle = vehicleFactory.Create(subProcess.ToEnum<VehicleTypes>(), reportCode);
          vehicle.Display();
          return 0;
        default:
          throw new Exception();
      }
    }
  }


}
