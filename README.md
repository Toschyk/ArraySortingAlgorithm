# ArraySortingAlgorithm
Обратное проектирование алгоритма (Консольное приложение .NET Framework)

Задание:

В этой лабораторной работе необходимо провести обратное проектирование алгоритма, реализованного в исходном коде на C# с использованием .NET Framework. В процессе работы нужно проанализировать исходный код, выделить основные этапы алгоритма, предложить улучшения и описать алгоритм.

Для примера мы будем работать с алгоритмом сортировки массива двумя методами.

Шаг 1: Исходный код на C#

Рассмотрим алгоритм сортировки массива методами SortAscending и SortDescending.

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


Шаг 2: Анализ исходного кода

Описание алгоритма:
Этот код реализует программу на C#, которая выполняет несколько операций с массивами: сортировку массивов по возрастанию и убыванию, а также их объединение. Давайте разберем алгоритм шаг за шагом.

1. Сортировка массива по возрастанию (SortAscending)


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


Описание:
- Это классическая реализация алгоритма сортировки выбором (Selection Sort).
- Проходим по массиву и для каждого элемента находим минимальный элемент в оставшейся части массива.
- Меняем местами минимальный элемент с текущим, если они не совпадают.

2. Сортировка массива по убыванию (SortDescending)


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


Описание:
- Это аналогичная реализация сортировки выбором, но с изменением порядка сравнения для сортировки по убыванию.
- На каждом шаге ищется максимальный элемент в оставшейся части массива, и он меняется местами с текущим элементом.

3. Объединение двух массивов (`ConcatArrays`)


static int[] ConcatArrays(int[] a, int[] b)
{
    int[] c = new int[a.Length + b.Length]; //длина навого массива равна сумме длин исходных массивов
    for (int i = 0; i < a.Length; i++) //переносим числа из массива A в масси C
        c[i] = a[i];
    for (int i = a.Length; i < a.Length + b.Length; i++) //переносим числа из массива B в масси C, начиная с индекса a.Length
        c[i] = b[i - a.Length]; //не забываем, что у массива B индекс очередного элемента на a.Length меньше, чем у C!
    return c;
}


Описание:
- Функция принимает два массива `a` и `b` и создает новый массив `c`, который содержит все элементы из массивов `a` и `b`.
- Для этого сначала копируются все элементы из массива `a` в новый массив `c`, а затем все элементы из массива `b`.
- Новый массив имеет длину, равную сумме длин массивов `a` и `b`.

4. Основной метод `Main`


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


Описание:
- В методе `Main` создаются два массива: `a` и `b`.
- Массив `a` сортируется по возрастанию с помощью `SortAscending`, а массив `b` сортируется по убыванию с помощью `SortDescending`.
- Далее два массива объединяются с помощью метода `ConcatArrays`.
- Итоговый массив выводится на консоль.

Шаг 3: Описание алгоритма

Вывод:

После выполнения программы на экране будет выведен объединенный и отсортированный массив.

Пример вывода:

Для массивов:
- a = {2, 4, 5, 1, 4}
- b = {9, 1, 4, -1, 2}

После сортировки:
- a = {1, 2, 4, 4, 5} (по возрастанию)
- b = {9, 4, 2, 1, -1} (по убыванию)

После объединения:
- Итоговый массив: {1, 2, 4, 4, 5, 9, 4, 2, 1, -1}.

Таким образом, вывод будет:

1 2 4 4 5 9 4 2 1 -1


Шаг 4:  Возможные улучшения

Обратите внимание на два метода сортировки массивов — SortAscending и SortDescending. Эти методы отличаются друг от друга ровно одним символом! Конечно же, это совсем не рационально и не правильно, как минимум по двум причинам:
    1. Если потребуется изменить метод сортировки массива — придется проводить двойную работу и вносить изменения в оба метода;
    2. «Портянки» дублирующего кода — признак плохого кода.
Намного лучше, если сортировкой массива будет заниматься один метод, который на входе будет получать не только массив для сортировки, но и какой-либо параметр, указывающий на то, в каком порядке массив сортировать — для этих целей как нельзя лучше нам подойдут перечисления.  Перепишем метод сортировки массива следующим образом:

Пример улучшенного кода с проверкой на отсутствие изменений:


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

