using System;

namespace ConsoleApp4
{
  public abstract class BaseVehicleSerive 
  {
    public string Weels;
    public BaseVehicleSerive(string weel)
    {
      Weels = weel;
    }
    public BaseVehicleSerive()
    {
      
    }

    public abstract BaseVehicleSerive BuildService(string weel);

    public abstract void Display();

    public void GetFileConfigFiles() {
      Console.WriteLine("Base Config files 2");
    }

    
  }

}


