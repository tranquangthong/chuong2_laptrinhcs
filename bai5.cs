using System;
namespace TranQuangThong
{
  public enum PoinColor
  {
    LightBlue,
    BloodRed,
    God
  }
  public class Point
  {
    public int X { get; set; }
    public int Y { get; set; }
    public PointColor Color { get; set; }
    public Point (int x, int y, Point color) 
    {
      X = x;
      Y = y;
      Color = color;
    }
    public void DisplayStatus()
    {
      Console.WriteLine($"Point ({X}, {Y} - Color: {Color})");
    }
  }
  class Program
  {
    static void Main()
    {
      
    }
  }
}

