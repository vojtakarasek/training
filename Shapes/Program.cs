using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 50;
            int height = 20;

            var shapes = new List<IShapeArea>();
            shapes.Add(Shift(new TriangleArea(10, 10, true), 15, 0));
            shapes.Add(new TriangleArea(9, 10, false));
            shapes.Add(Shift(new BoxArea(8, 8), 9, 5));
            shapes.Add(Shift(new CircleArea(5), 6, 6));

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var fillCount = 0;
                    foreach (var shape in shapes)
                    {
                        if (shape.IsFilled(x, y))
                            fillCount++;
                    }
                    PrintChar(fillCount);
                }
                Console.WriteLine("");
            }

        }

        static IShapeArea Shift(IShapeArea shape, int offsetX, int offsetY)
        {
            return new ShiftedShape(shape, offsetX, offsetY);
        }

        static void PrintChar(int fillCount)
        {
            switch (fillCount)
            {
                case 0:
                    Console.Write(' ');
                    break;
                case 1:
                    Console.Write('-');
                    break;
                case 2:
                    Console.Write('+');
                    break;
                default:
                    Console.Write('*');
                    break;
            }
        }
    }
}
