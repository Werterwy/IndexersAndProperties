using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexersAndProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*       1.	Создать индексатор, для одномерного массива, который при установке
                     значения будет возводить в квадрат передаваемое значение переменной 
                     и устанавливать его для указанного индекса. При получении элемента массива
                      по индексу будет возвращаться его текущее значение.*/
            int[] massiv = new int[10000];

            SquareArray myArray = new SquareArray(5);
            myArray[0] = 2; 
            myArray[1] = 3; 

            int value = myArray[0]; 
            Console.WriteLine(value);
            Console.WriteLine("");

            Console.Write("Введите площадь помещения (в квадратных метрах): ");
            double squareMeters = double.Parse(Console.ReadLine());

            Console.Write("Введите количество проживающих людей: ");
            int residents = int.Parse(Console.ReadLine());

            Console.Write("Введите сезон (осень/зима - 1, весна/лето - 2): ");
            int season = int.Parse(Console.ReadLine());

            Console.Write("Есть ли льготы (да - 1, нет - 2): ");
            int hasDiscount = int.Parse(Console.ReadLine());
            if (hasDiscount == 1)
            {
                Console.WriteLine("Какая у вас льгота (ветеран труда-1, ветеран войны-2): ");
                hasDiscount = int.Parse(Console.ReadLine());
            }
            else if(hasDiscount == 2)
            {
                hasDiscount = 0;
            }

            PaymentCalculator calculator = new PaymentCalculator(squareMeters, residents, season, hasDiscount);
            calculator.CalculatePayments();


        }
    }
}
