using System;

namespace homework3Answer
{
    class Program
    {
        static void Main(string[] args)
        {
            User.GraphCreate();
            Console.WriteLine("pause any key to quit");
            Console.ReadKey();
        }
    }

    class User
    {
        static public Graph GraphCreate()
        {
            Console.Write("Input the type of your graph(Triangle,Square,Rectangle,Circle)：");
            Graph inputGraph = GraphFactory.CreateGraph(Console.ReadLine());
            if (inputGraph == null)
            {
                GraphCreate();
            }
            else
            {
                inputGraph.InputDate();
                inputGraph.ShowArea();
            }

            return inputGraph;
        }
    }

    class GraphFactory
    {
        static public Graph CreateGraph(string graphType)
        {
            Graph inputGraph = null;

            if (graphType.Equals("Triangle"))
            {
                inputGraph = new Triangle();
            }
            else if (graphType.Equals("Rectangle"))
            {
                inputGraph = new Rectangle();
            }
            else if (graphType.Equals("Square"))
            {
                inputGraph = new Square();
            }
            else if (graphType.Equals("Circle"))
            {
                inputGraph = new Circle();
            }
            else
            {
                Console.WriteLine("Input error!\n");
                return null;
            }
            return inputGraph;
        }
    }

    abstract class Graph
    {
        public abstract void InputDate();

        public abstract double Area
        {
            get;
        }

        public abstract void ShowArea();
    }

    class Triangle : Graph
    {
        private double height;
        private double bottomLength;

        public override void InputDate()
        {
            try
            {
                Console.Write("Input the height of the Triangle：");
                this.height = double.Parse(Console.ReadLine());
                Console.Write("Input the bottomlength of the Triangle：");
                this.bottomLength = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Input error!\n");
                InputDate();
            }
        }

        public override double Area
        {
            get
            {
                return height * bottomLength / 2;
            }
        }

        public override void ShowArea()
        {
            Console.WriteLine("The area of the Triangle is：" + Area);
        }
    }

    class Rectangle : Graph
    {
        private double width;
        private double length;

        public override void InputDate()
        {
            try
            {
                Console.Write("Input the length of the Rectangle：");
                this.length = double.Parse(Console.ReadLine());
                Console.Write("Input the width of the Rectangle：");
                this.width = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Input error!\n");
                InputDate();
            }
        }

        public override double Area
        {
            get
            {
                return length * width;
            }
        }

        public override void ShowArea()
        {
            Console.WriteLine("The area of the Rectangle is：" + Area);
        }
    }

    class Square : Graph
    {
        private double Length;

        public override void InputDate()
        {
            try
            {
                Console.Write("Input the length of the Square：");
                this.Length = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Input error!\n");
                InputDate();
            }
        }

        public override double Area
        {
            get
            {
                return Length * Length;
            }
        }

        public override void ShowArea()
        {
            Console.WriteLine("The area of the Square is：" + Area);
        }
    }

    class Circle : Graph
    {
        private double radius;

        public override void InputDate()
        {
            try
            {
                Console.Write("Input the radius of the Circle：");
                this.radius = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Input error!\n");
                InputDate();
            }
        }

        public override double Area
        {
            get
            {
                return radius * radius * 3.14159;
            }
        }

        public override void ShowArea()
        {
            Console.WriteLine("The area of the Circle is：" + Area);
        }
    }
}
