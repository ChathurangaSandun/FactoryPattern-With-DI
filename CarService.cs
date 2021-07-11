using System;

namespace ConsoleApp4
{
  public class CarService : BaseVehicleSerive
  {
    public CarService()
    {

    }

    public override BaseVehicleSerive BuildService(string weel)
    {
      base.Weels = weel;
      return this;
    }

    public override void Display()
    {
      Console.WriteLine("Car service " + Weels);
    }
  }
}


