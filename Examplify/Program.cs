
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;



namespace Examplify{
    internal class Program{
        internal class Car {}
        internal class Truck : Car {}
        public void AssignBrandToVehicle(Vehicle vehicle, string brandName)
        {
            vehicle.Brand = brandName;
        }
        public static void Main(string[] args){
            void Swap(int[] array, int index1, int index2){
                array[index1] ^= array[index2];
                array[index2] ^= array[index1];
                array[index1] ^= array[index2];
            }
            int a = 2;
            int b = 3;
            Console.WriteLine(a ^= b);
            Console.WriteLine(b ^= a);
            Console.WriteLine(a ^= b);
            object o1 = new object();
            object o2 = new Car();
            object o3 = new Truck();
            object o4 = o3;
            Car car1 = new Car();
            Car car2 = new Truck();
            Truck truck1 = new Truck();
            Car car4 = truck1;
            Truck truck4 = (Truck)truck1;
            Truck truck5 = (Truck)car2;
            Car car6 = (Truck)car2;
            Car xdd;
            bool on = false;
            Console.WriteLine(on ? "ConsoleYeah" : "Console GRAYCEN");



        }
        public delegate void Action();
        public delegate void Action<in T>(T obj);

        

    }
    public class Vehicle
    {
        public string Brand { get; set; }
    }

    public class Car : Vehicle
    {
        public int Doors { get; set; }
    }

    public class Bike : Vehicle
    {
        public bool HasPedals { get; set; }
    }

}
