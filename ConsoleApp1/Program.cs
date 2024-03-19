using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Math;
using System.Linq;


namespace ConsoleApplication1{
    internal class Program{
        public static void Main(string[] args){
            for (;;){
                string[] array = Console.ReadLine()?.Split();
                if (array[0] == "end"){
                    break;
                }
                string name = array[2];
                int X = Convert.ToInt32(array[0]);
                int Y = Convert.ToInt32(array[1]);
                var Panda = new Pandas(X, Y, name);
                
            }

            Pandas.Allocation();
        }
    }

    interface IInterface{
        void DoSome();
    }

    class MyClass : IInterface{
        public void DoSome(){
        }
    }
    public class Pandas{
        private string _gender;
        private int _x;
        private int _y;
        static int PandasCount = 0;
        public static List<Pandas> pandas = new List<Pandas>();
        double partnerDistance = 999999;

        public static void Allocation(){
            double distanceOfTwoPandas;
            var wpans = new List<Pandas>();
            var mpans = new List<Pandas>();
            for (int i = 0; i < pandas.Count; i++){
                if (pandas[i]._gender == "female")
                    wpans.Add(pandas[i]);
            }
            for (int i = 0; i < pandas.Count; i++){
                if (pandas[i]._gender == "male")
                    mpans.Add(pandas[i]);
            }

            var alpand = new List<Pandas>();
            for (int i = 0; i < mpans.Count; i++){
                Pandas currentpanda = mpans[i];
                for (int j = 0; j < wpans.Count; j++){
                    distanceOfTwoPandas = Round(Sqrt(Pow(currentpanda._x - wpans[j]._x, 2) +
                                               Pow(currentpanda._y - wpans[j]._y, 2)),2);
                    if (distanceOfTwoPandas <= currentpanda.partnerDistance){
                        currentpanda.partnerDistance = distanceOfTwoPandas;
                        
                        if (alpand.Contains(wpans[j]) && wpans[j].partnerDistance > distanceOfTwoPandas){
                            wpans[j].partnerDistance = distanceOfTwoPandas;
                            var index = Convert.ToInt32(alpand.IndexOf(wpans[j])-1);
                            alpand.Remove(wpans[j]);
                            alpand.RemoveAt(index);
                            
                            
                            alpand.Add(currentpanda);
                            alpand.Add(wpans[j]);
                            

                        }
                        else if (!alpand.Contains(wpans[j]) && alpand.Contains(currentpanda)){
                            wpans[j].partnerDistance = distanceOfTwoPandas;
                            int index = Convert.ToInt32(alpand.IndexOf(currentpanda)+ 1);
                            
                            alpand.RemoveAt(index);
                            alpand.Remove(currentpanda);
                            alpand.Add(currentpanda);
                            alpand.Add(wpans[j]);
                        }
                        else if(!alpand.Contains(currentpanda)&& !alpand.Contains(wpans[j])){
                            alpand.Add(currentpanda);
                            alpand.Add(wpans[j]);
                            wpans[j].partnerDistance = distanceOfTwoPandas;
                        }
                        
                    }
                    else
                        continue;
                }
            }

            var remainings = new List<Pandas>();
            for (int i = 0; i < alpand.Count-1; i++){
                if (i+1 < alpand.Count && alpand[i + 1] == null)
                    remainings.Add(alpand[i]);
            }
            for (int i = 0; i < wpans.Count; i++){
                if (!alpand.Contains(wpans[i])){
                    remainings.Add(wpans[i]);
                }
            }
            for (int i = 0; i < mpans.Count; i++){
                if (!alpand.Contains(mpans[i]))
                    remainings.Add(mpans[i]);
            }
            
            //trading
            for (int i = 0; i < alpand.Count - 2; i += 2){
                for (int j = 1; j < alpand.Count-2; j += 2){
                    if (alpand[i].partnerDistance > alpand[i + 2].partnerDistance){
                        var Mexchange = alpand[i];
                        var Fexchange = alpand[j];
                        alpand[i] = Mexchange;
                        alpand[j] = Fexchange;
                        alpand[i] = alpand[i + 2];
                        alpand[j] = alpand[j + 2];
                        alpand[i + 2] = Mexchange;
                        alpand[j + 2] = Fexchange;
                    }
                }
            }

            var forending = new List<Pandas>();
            forending.AddRange(remainings.ToList());
            forending.AddRange(alpand.ToList());

            Console.WriteLine($"Total pandas count: {PandasCount}");
            for (int i = 0; i < forending.Count-1; i++ ){
                if (forending[i]._gender == "male" && forending[i+1]._gender == "male"){
                    Console.WriteLine($"Lonely {forending[i]._gender} panda at X: {forending[i].X}, Y: {forending[i].Y}");
                }//правильно
                else if (forending[i]._gender == "female" && forending[i + 1]._gender == "female" ){
                    Console.WriteLine($"Lonely {forending[i]._gender} panda at X: {forending[i].X}, Y: {forending[i].Y}");
                }
                else if ( i - 1 >= 0 && forending[i]._gender == "female" && forending[i-1]._gender =="female" && forending[i+1]._gender == "male"){
                    Console.WriteLine($"Lonely {forending[i]._gender} panda at X: {forending[i].X}, Y: {forending[i].Y}");
                }
                else{
                    Console.WriteLine(
                        $"Pandas pair at distance {forending[i].partnerDistance}, male panda at X: {forending[i].X}, Y: {forending[i].Y}, female panda at X: {forending[i+1].X}, Y: {forending[i+1].Y}");
                    i++;
                }
            }
            
        }

        public string Gender{ 
            get{ return _gender; }
            set{ _gender = value; }
        }

        public int X{
            get{ return _x; }
            set{ _x = value; }
        }

        public int Y{
            get{ return _y; }
            set{ _y = value; }
        }

        public Pandas(int x, int y, string gender){
            PandasCount++;
            Y = y;
            X = x;
            Gender = gender;
            pandas.Add(this);
        }

        public Pandas(){
            PandasCount++;
            pandas.Add(this);
        }
    }
}