using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Laba1_1GB
{
    public static class Sort
    {
        public static long sizeInputFile = 1024 * 1024 * 1024; //розмір вхідного файла в байтах
        public static int countServ = 4;
        public static long servSize = sizeInputFile / countServ;  //розмір куска для сортування (128 мб)
        public static long countIntInServ = servSize / 32;  //кількість чисел в порції для сортування
        //"12345678" = 32 bytes;
        public static long countIntInFIle = sizeInputFile / 32; //кількість чисел у всьому файлі
        public static string inputPath = "input.txt";
        public static void CreateFile() //метод для створення файлу
        {
            var random = new Random();
            using var writer = new StreamWriter(inputPath, false, Encoding.UTF32);
            for (long i = 0; i < countIntInFIle; i++)
            {
                writer.WriteLine(random.Next(10000000, 99999999).ToString());
            }
        }

        public static string StartSort() //початок сорутвання
        {
            var paths = CreateServFile(); //шляхи до створених файлів
            while (paths.Count !=1) //поки не залишиться один (відсортований) файл
            {
                var p = new List<string>();
                for (int i = 0; i < paths.Count; i++)
                {
                    p.Add(paths[i] + paths[i+1]); //два файли зливаються і утворюють ім'я яке є сумою їх назв (наприкоад: input.txt0input.txt1)
                    SplitTwoFilesInOne(paths[i], paths[i+1]);  //злиття файлу в один
                    i++;
                }

                foreach (var path in paths) //видалення непотрібних файлів
                {
                    File.Delete(path);
                }
                paths = p;
            }
            return paths.First();
        }

        public static void SplitTwoFilesInOne(string path1, string path2)
        {
            using var reader1 = new StreamReader(path1, Encoding.UTF32);
            using var reader2 = new StreamReader(path2, Encoding.UTF32);
            string resPath = path1 + path2; //назва вихідного файлу
            var writer = new StreamWriter(resPath, true, Encoding.UTF32);
            bool flag1 = true, flag2 = true; //вони потрібні щоб числа з одного файлу записувались в вихідний, доки вони менші за число з другого файлу 
            string num1 = String.Empty, num2 = String.Empty;
            while (true)
            {
                if (flag1)
                {
                    num1 = reader1.ReadLine();
                }
                if (flag2)
                {
                    num2 = reader2.ReadLine();
                }
                if (num1 == null) //якщо один з зчитаних рядків порожній, то ми досягли кінця файу
                {
                    Write(reader2, writer);
                    return;
                }
                if (num2 == null)
                {
                    Write(reader1, writer);
                    return;
                }
                int a = int.Parse(num1);
                int b = int.Parse(num2);
                if (a > b) //порівняння двох файлів і запис меншого в файл
                {
                    writer.WriteLine(b);
                    flag1 = false; //завдяки цьому нове число не буде зчитане з файлу, а буде порівнюватися з числами з іншого файлу, доки не буде записане 
                    flag2 = true;
                }
                else if (a < b)
                {
                    writer.WriteLine(a);
                    flag1 = true;
                    flag2 = false;
                }
                else 
                {
                    writer.WriteLine(a);
                    writer.WriteLine(b);
                    flag1 = true;
                    flag2 = true;
                }
            }
        }
        //якщо дані з одного файла були записані в рузультуючий, а в іншому залишились (це відсортовані числа які більші ніж останнє число файлу який закінчився),
        //то вони записуються в кінець результуючого файлу
        public static void Write(StreamReader reader, StreamWriter writer) 
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine(line);
            }
        }
        public static List<string> CreateServFile() //метод для розділення файлу на 4 частини
        {
            using var reader = new StreamReader(inputPath, Encoding.UTF32);
            var paths = new string[countServ];
            for (int i = 0; i < countServ; i++)
            {
                paths[i] = inputPath + i; //створення імені нового файлу (наприклад: input.txt0)
                using var writer = new StreamWriter(paths[i], false, Encoding.UTF32);
                var arr = new int[countIntInServ];
                for (int j = 0; j < countIntInServ; j++) //запис частини файлу в масив
                {
                    arr[j] = int.Parse(reader.ReadLine());
                }
                ///////
                Array.Sort(arr); //сортування масиву
                //це операція використовує найбільше оперативної пам'яті в програмі (розмір файлу (1.2 гб) / countServ), в даному випадку це 300 мегабайт
                //при збільшенні кількості частин (countServ = 16) оперативної пам'яті буде використовуватися менше 100 мегабайт, але час сортування збільшиться в 2 рази
                for (int j = 0; j < countIntInServ; j++) //запис відсортованого масиву в файл
                {
                    writer.WriteLine(arr[j]);
                }
            }

            return paths.ToList();
        }
        //так як вихідний файл неможливо відкрити за допомогою текстового редактора, створений метод, який
        //зчитує невелику постідовність даних для демонстрації коректності роботи програми
        public static void CheckRes(string path) 
        {                                       
            using var reader = new StreamReader(path, Encoding.UTF32);
            for (int i = 0; i < 40000; i++)
            {
                reader.ReadLine();
            }
            for (int i = 0; i < 190; i++)
            {
                Console.WriteLine(int.Parse(reader.ReadLine()));
            }
        }
    }
}