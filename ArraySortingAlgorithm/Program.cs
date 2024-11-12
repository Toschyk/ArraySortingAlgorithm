using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortingAlgorithm
{

    class Program
    {
        static void SortAscending(int[] intArray)
        {
            int indx; //переменная для хранения индекса минимального элемента массива
            for (int i = 0; i < intArray.Length; i++) //проходим по массиву с начала и до конца
            {
                indx = i; //считаем, что минимальный элемент имеет текущий индекс 
                for (int j = i; j < intArray.Length; j++) //ищем минимальный элемент в неотсортированной части
                {
                    if (intArray[j] < intArray[indx])
                    {
                        indx = j; //нашли в массиве число меньше, чем intArray[indx] - запоминаем его индекс в массиве
                    }
                }
                if (intArray[indx] == intArray[i]) //если минимальный элемент равен текущему значению - ничего не меняем
                    continue;
                //меняем местами минимальный элемент и первый в неотсортированной части
                int temp = intArray[i]; //временная переменная, чтобы не потерять значение intArray[i]
                intArray[i] = intArray[indx];
                intArray[indx] = temp;
            }
        }

        static void SortDescending(int[] intArray)
        {
            int indx;
            for (int i = 0; i < intArray.Length; i++)
            {
                indx = i;
                for (int j = i; j < intArray.Length; j++)
                {
                    if (intArray[j] > intArray[indx]) //заменяем знак сравнения на противоположный
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

        static void Main(string[] args)
        {
            int[] a = new int[5] { 2, 4, 5, 1, 4 };
            int[] b = new int[5] { 9, 1, 4, -1, 2 };
            SortAscending(a); //отсортировли первый массив по возрастанию
            SortDescending(b); //отсортировали второй массив по убыванию
            int[] c = ConcatArrays(a, b); //объединили массивы
            /*Выводим итоговый массив в консоль*/
            foreach (int i in c)
                Console.Write($"{i} ");
            Console.ReadKey();
        }
    }
}