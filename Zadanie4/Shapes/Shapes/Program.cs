using System;

namespace Program
{
    class Program
    {
 
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Square(2));
            shapes.Add(new Rectangle(3, 5));
            shapes.Add(new Triangle(3, 4, 5));
            shapes.Add(new Circle(2));
            printShapes(shapes);
        }
        static void printShapes(List<Shape> shapes)
        {
            foreach (Shape shape in shapes)
            {
                Console.WriteLine("Figura: " + shape.getShapeName());
                Console.WriteLine("Pole: " + shape.calculateArea());
                Console.WriteLine("Obwód: " + shape.calculatePerimeter());
                Console.WriteLine();
            }
        }



    }

    public abstract class Shape
    {
        public abstract double calculateArea();
        public abstract double calculatePerimeter();
        public abstract string getShapeName();
    }

    public class Rectangle : Shape
    {
        protected double height;
        private double width;

        public Rectangle (double height, double width)
        {
            this.height = height;  
            this.width = width; 
        }

        public override double calculateArea()
        {
            return height * width;
        }

        public override double calculatePerimeter()
        {
            return height * 2 + width * 2;
        }

        public override string getShapeName()
        {
            return "Prostokąt";
        }
    }

    public class Square : Rectangle
    {
        public Square (double height) : base(height, 0)
        {
        }
        public override double calculateArea()
        {
            return height * height;
        }

        public override double calculatePerimeter()
        {
            return height * 4; 
        }

        public override string getShapeName()
        {
            return "Kwadrat";
        }
    }

    public class Triangle : Shape
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle (double sideA, double sideB, double sideC) {
            this.sideA = sideA;
            this.sideB = sideB; 
            this.sideC = sideC;
        }
        public override double calculateArea()
        {
            double p = calculatePerimeter() / 2;
            return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
        }

        public override double calculatePerimeter()
        {
            return sideA + sideB + sideC;
        }
        public override string getShapeName()
        {
            return "Trójkąt";
        }

    }

    public class Circle : Shape
    {
        private double radius;

        public Circle (double radius)
        {
            this.radius = radius;   
        }

        public override double calculateArea()
        {
            return 3.14 * radius * radius;
        }

        public override double calculatePerimeter()
        {
            return 2 * 3.14 * radius;
        }
        public override string getShapeName()
        {
            return "Koło";
        }
    }

    
}



