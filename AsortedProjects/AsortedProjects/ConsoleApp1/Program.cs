using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication_1._1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array;
            string s;
            Console.Write("arraySize=");
            s = Console.ReadLine();
            array = new int[int.Parse(s)];
            Console.WriteLine("enter array size");
            int negativeNumberCount = 0;
            int smallestEvenNumber = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int index = i + 1;
                Console.Write("enter array element " + index + " ");
                s = Console.ReadLine();
                array[i] = int.Parse(s);
                if (array[i] < 0)
                {
                    negativeNumberCount++;
                }
                if (array[i] % 2 == 0 && (array[i] < smallestEvenNumber || smallestEvenNumber == 0))
                {
                    smallestEvenNumber = array[i];
                }
            }
            Console.WriteLine("negativeNumberCount " + negativeNumberCount);
            Console.WriteLine("smallest even number " + smallestEvenNumber);
            bool hasEqualNumbers = false;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        hasEqualNumbers = true;
                        break;
                    }
                }
                if (hasEqualNumbers)
                {
                    break;
                }
            }
            Console.WriteLine("hasEqualNumbers " + hasEqualNumbers);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        (array[j], array[i]) = (array[i], array[j]);
                    }
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadKey();
        }
    }
}