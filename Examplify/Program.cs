using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Examplify{
    internal class Program{
        public static void Main(string[] args){
            void Swap(int[] array, int index1, int index2)
            {
                array[index1] ^= array[index2];
                array[index2] ^= array[index1];
                array[index1] ^= array[index2];
            }

// Пример использования:

            int a = 2;
            int b = 3;
            Console.WriteLine(a^=b);
            Console.WriteLine(b ^= a);
            Console.WriteLine(a ^= b);

        public delegate void Action();
        public delegate void Action<in T>(T obj)
    }
    }
}