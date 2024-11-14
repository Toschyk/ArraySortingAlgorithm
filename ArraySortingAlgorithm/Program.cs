using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortingAlgorithm
{

    class Program
    {
        enum SortParam { ASC, DESC };

        static void SortArray(int[] intArray, SortParam sortParam)
        {
            int indx;
            for (int i = 0; i < intArray.Length; i++)
            {
                indx = i;
                for (int j = i; j < intArray.Length; j++)
                {
                    //ASC = по возврастанию (intArray[j] < intArray[indx])
                    //DESC = по убыванию (intArray[j] > intArray[indx])
                    if (((intArray[j] < intArray[indx]) && (sortParam == SortParam.ASC)) || ((intArray[j] > intArray[indx]) && (sortParam == SortParam.DESC)))
                    {
                        indx = j;
                    }
                }
                if (intArray[indx] == intArray[i])
                    continue;
                int temp = intArray[i];
                intArray[i] = intArray[indx];
                intArray[indx] = temp;
            }
        }

        static int[] ConcatArrays(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length]; //длина навого массива равна сумме длин исходных массивов
            for (int i = 0; i < a.Length; i++) //переносим числа из массива A в масси C
                c[i] = a[i];
            for (int i = a.Length; i < a.Length + b.Length; i++) //переносим числа из массива B в масси C, начиная с индекса a.Length
                c[i] = b[i - a.Length]; //не забываем, что у массива B индекс очередного элемента на a.Length меньше, чем у C!
            return c;
        }

        static string ArrayToString(int[] array)
        {
            string s = string.Empty;
            foreach (int i in array)
                s += $"{i} ";
            return s;
        }

        static void Main(string[] args)
        {
            int[] a = new int[5] { 2, 4, 5, 1, 4 };
            int[] b = new int[5] { 9, 1, 4, -1, 2 };

            Console.WriteLine($"Исходный массив A: {ArrayToString(a)}");
            SortArray(a, SortParam.ASC); //отсортировли первый массив по возрастанию
            Console.WriteLine($"Отсортированный массив A: {ArrayToString(a)}");

            Console.WriteLine($"Исходный массив B: {ArrayToString(b)}");
            SortArray(b, SortParam.DESC);//отсортировали второй массив по убыванию
            Console.WriteLine($"Отсортированный B: {ArrayToString(b)}");

            int[] c = ConcatArrays(a, b); //объединили массивы
            Console.WriteLine($"Итоговый массив С: {ArrayToString(c)}");
            Console.ReadKey();
        }
    }
}