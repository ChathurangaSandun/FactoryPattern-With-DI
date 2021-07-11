using System;

namespace ConsoleApp4
{
  public static class Extenstions
  {
    public static T ToEnum<T>(this string value, bool ignoreCase = true)
    {
      return (T)Enum.Parse(typeof(T), value, ignoreCase);
    }
  }


}
