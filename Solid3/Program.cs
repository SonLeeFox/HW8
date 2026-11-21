using System;

namespace Solid3
{
    // Порушено принцип підстановки Лісков (LSP): Square змінював поведінку базового класу Rectangle (при зміні однієї сторони змінювалась інша),
    // що призводило до площі 100 замість очікуваних 50.
    // Вирішення: виділено спільний інтерфейс IShape для незалежної реалізації прямокутника та квадрата.
    interface IShape
    {
        int GetArea();
    }

    class Rectangle : IShape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    class Square : IShape
    {
        public int Side { get; set; }

        public int GetArea()
        {
            return Side * Side;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IShape rect = new Rectangle { Width = 5, Height = 10 };
            Console.WriteLine(rect.GetArea()); // 50

            IShape square = new Square { Side = 5 };
            Console.WriteLine(square.GetArea()); // 25

            Console.ReadKey();
        }
    }
}
