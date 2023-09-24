using System.ComponentModel.Design;
using System.Text;

namespace Second_task
{
    class Ar
    {
        private int n;
        int[] a;
        int s = 0;
        public Ar(uint a, uint b)
        {
            n = (int)(b - a);
            if (n == 0)
            {
                this.a = new int[1];
                this.a[0] = (int)a;
                n = 1;
            }
            else if (a < b)
            {
                this.a = new int[++n];
                int item = (int)a;
                for (int i = 0; i < n; i++)
                {
                    this.a[i] = item;
                    item++;
                }
            }
            else
            {
                throw new Exception("Некоректно введений діапазон (a > b)!");
            }
        }
        public Ar(string name)
        {
            StreamReader sr = new StreamReader(name);
            string baseStr = sr.ReadLine();
            if (string.IsNullOrEmpty(baseStr))
            {
                throw new Exception("Файл пустий!");
            }
            else
            {
                string[] str = baseStr.Split(" ");
                a = new int[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    try
                    {
                        a[i] = Convert.ToInt32(str[i]);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Некоректний запис у файлі!");
                    }
                }
            }
            n = a.Length;
            sr.Close();
        }
        public int S 
        { 
            get 
            {
                foreach (var item in a)
                {
                    if (item % 2 != 0)
                    {
                        s += item;
                    }
                }
                return s; 
            } 
        }
        public int N { get { return n;} }
        public void Print()
        {
            Console.Write("Массив а: ");
            foreach (var item in a)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
        public int P()
        {
            for (int i = 0; i < a.Length; i++)
            {
                int number = a[i];
                if(Math.Abs(number) == 5 || Math.Abs(number) % 10 ==5)
                {
                    return i;
                }
            }
            return -1;
        }
        public int Sum(int i1, int i2)
        {
            int result = 0;
            if(i1>=0 && i2>=0 && i1<a.Length && i2 < a.Length)
            {
                if (i1 <= i2)
                {
                    for (int i = i1; i <= i2; i++)
                    {
                        result+= a[i];
                    }
                    return result;
                }
                else
                {
                    throw new Exception("Некоректно введений діапазон (i1 > i2)!");
                }
            }
            else
            {
                throw new Exception("Вказаний діапазон знаходиться поза межами масиву!");
            }
        }
    }
    internal class Program
    {
        static public void MethodForAr(Ar ar)
        {
            ar.Print();
            Console.WriteLine("Cума непарних елементів масиву: " + ar.S);
            int p =ar.P();
            if (p != -1)
            {
                Console.WriteLine("Сума всіх елементів масиву правіше знайденого елемента, який закінчується на цифру 5: " + ar.Sum(p, ar.N - 1));
            }
            else
            {
                Console.WriteLine("Такого елемента не існує, який закінчується на цифру 5!");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Ar ar;
            int numberConstructor = 0;
            Console.Write("Введіть номер конструктора (1 або 2): ");
            if(int.TryParse(Console.ReadLine(),out numberConstructor))
            {
                if (numberConstructor == 1)
                {
                    uint a, b;
                    Console.WriteLine("Введіть числа діапазону [a; b] (натуральні) для конструктора 1:");
                    if(uint.TryParse(Console.ReadLine(), out a) && uint.TryParse(Console.ReadLine(), out b) && a != 0 && b != 0)
                    {
                        try
                        {
                            ar = new Ar(a, b);
                            MethodForAr(ar);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некоректне введення даних!");
                    }
                }
                else if (numberConstructor == 2)
                {
                    try
                    {
                        ar = new Ar("D:\\text.txt");
                        MethodForAr(ar);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Такого конструктора не існує або введено некоректне значення!");
            }
        }
    }
}