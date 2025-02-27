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
  public class Rectangle
  {
    public Point UpperLeft { get; set; }
    public Point BottomRight { get; set; }

    public Rectangle(Point upperLeft, Point bottomRight)
    {
        UpperLeft = upperLeft;
        BottomRight = bottomRight;
    }

    public void DisplayStatus()
    {
        Console.WriteLine("Rectangle Information:");
        Console.Write("Upper Left: ");
        UpperLeft.DisplayStatus();
        Console.Write("Bottom Right: ");
        BottomRight.DisplayStatus();
    }
  }
  class Program
  {
    static void Main()
    {
        Point p1 = new Point(2, 3, PointColor.LightBlue);
        Point p2 = new Point(10, 8, PointColor.BloodRed);
        Console.WriteLine("Points:");
        p1.DisplayStatus();
        p2.DisplayStatus();
        Rectangle rect = new Rectangle(p1, p2);
        Console.WriteLine("\nRectangle:");
        rect.DisplayStatus();
    }
  }
}

