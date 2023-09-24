using System.Text;

namespace First_task
{
    class Cube
    {
        public double edge { get; set; }
        public bool Correct() 
        {
            return edge > 0;
        }
        public double Area() 
        {
            return 6 * Math.Pow(edge,2);
        }
        public double Volume()
        {
            return Math.Pow(edge, 3);
        }
        public void Print()
        {
            Console.WriteLine("Ребро куба дорівнює: " + edge);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding= Encoding.UTF8;
            Cube cube = new Cube();
            try
            {
                Console.Write("Введіть значення ребра: ");
                cube.edge = Convert.ToDouble(Console.ReadLine());
                cube.Print();
                if(cube.Correct())
                {
                    Console.WriteLine(@"Площа поверхні куба: {0:F3}", cube.Area());
                    Console.WriteLine(@"Об’єм куба: {0:F3}", cube.Volume());
                }
                else
                {
                    Console.WriteLine("Такого куба не може існувати! Його ребро має бути додатнім і не дорівнювати нулю!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Некоректне введення даних!");
            }
        }
    }
}