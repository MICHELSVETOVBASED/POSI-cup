using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography;
using static System.Math;

public class Program{
    public static Random _random = new Random();

    

   
    public static void Main(){
        viewer ClassChanger(string WhichClass, int Row, double Price,int NumberOfTickets){
            if (WhichClass == "regular"){
                regular Regular = new regular(Row,Price,NumberOfTickets);
                return Regular;
            }

            if (WhichClass == "student"){
                student Student = new student(Row, Price, NumberOfTickets);
                return Student;
            }

            if (WhichClass == "pensioner"){
                pensioner Pensioner = new pensioner(Row, Price, NumberOfTickets);
                return Pensioner;
            }

            if (WhichClass == "viewer"){
                viewer Viewer = new viewer(Row, Price, NumberOfTickets);
            }
            

            return null;
        }
        viewer CustomerObj;
        object[] Customer = new object[]{Console.ReadLine()?.Split().ToArray()};
        if (Customer[0] is string[]details&&
            details.Length == 4&&
            int.TryParse(details[1],out int Row)&&
            double.TryParse(details[2],out double Price)&&
            int.TryParse(details[3],out int NumberOfTickets)){
            
            string name = details[0];
            if (name == "regular"){
                CustomerObj = (regular)ClassChanger(name, Row, Price, NumberOfTickets);
            }
            else if (name == "student"){
                CustomerObj = (student)ClassChanger(name, Row, Price, NumberOfTickets);
            }
            else if (name == "pensioner"){
                CustomerObj = (pensioner)ClassChanger(name, Row, Price, NumberOfTickets);
            }
            else if(name == "viewer"){
                CustomerObj = (viewer)ClassChanger(name, Row, Price, NumberOfTickets);
            }
            else{
                CustomerObj = null;
            }

        }
        else{
            throw new Exception("NNONOONONON");
        }

        
        //var CustomerObj = new Viewer((string)Customer[0], (int)Customer[1], (double)Customer[2],(int) Customer[3])
        Console.WriteLine(CustomerObj?.GetType());

    }
    
}

public class viewer{
    private string _name;
    
    public string Name{
        get{ return _name; }
        set{ _name = value; }
    }

    public virtual int Row{ get; set; } = 0;
    public int Roww;
    public virtual double Price{ get; set; } = 0;
    public virtual int NumberOfTickets{ get; set; } = 0;
    public virtual int AfterAdditionalRow{ get; set; }
    public double DiscountedPrice;
    public double ResultPrice{ get; set; }
    private int baseDiscount; 

    public virtual int BaseDiscount{
        get{ return baseDiscount;}
        set{
            int baseDiscount = 0; 
            if (Row >= 10 && Row<=200){
                baseDiscount = (int)Floor(Row / 10f);
            }
            this.baseDiscount = baseDiscount;
        }
    }

    
    public viewer(int Row, double Price, int NumberOfTickets){
        
        this.Row = Row;
        this.Price = Price;
        this.NumberOfTickets = NumberOfTickets;
    }

    public viewer(){
    }

}

public class regular : viewer{
    public regular(int Row, double Price, int NumberOfTickets) : base(Row, Price, NumberOfTickets){
}
    public regular(){
        RefresherCost();
    }
    public override int Row{ get; set; }
    /*public override double Price{
        get => base.Price;
        set{
            double ValueSetter = value;
            double resultPrice = Price;
            if (Row <= 200){
                ValueSetter *= base.Row/100;
                resultPrice -= ValueSetter;
                base.Price = resultPrice;
            }
            else{
                ValueSetter *= 1.20;
                base.Price = ValueSetter;
            }
        } 
    }*/
    public override double Price{
        get => base.Price;
        set{
            Price = value;//ставится значение
        }
    }

    public override int NumberOfTickets{ get; set; } = 0; 
    public void RefresherCost(){//чтоб за каждый билет обновлял цену, скидка меняется после прохождения 10
        for (int i = 0; i < NumberOfTickets; i++){
            base.Row++;
            if (base.Row % 10 == 0){
                BaseDiscount++;
                Price -= Price * ((double)BaseDiscount / 100);
            } 
            else{
                Price -= Price * ((double)BaseDiscount / 100);
            }
        }
    }
}
public class student : viewer{
    public student(int Row, double Price, int NumberOfTickets) : base(Row, Price, NumberOfTickets){
    }
}

public class pensioner : viewer{
    public pensioner(int Row, double Price, int NumberOfTickets) : base(Row, Price, NumberOfTickets){
    }
}
