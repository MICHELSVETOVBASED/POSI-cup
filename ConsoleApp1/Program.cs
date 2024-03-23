using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

class Program{
    public static Random _random = new Random();

    public static void Main(){
        var Customer = new object?[]{Console.ReadLine()?.Split().ToArray()};
        
    }
    
}

class Viewer{
    private string _name;

    public string Name{
        get{ return _name; }
        set{ _name = value; }
    }

    public virtual int Row{ get; set; }
    public virtual int Price{ get; set; }
    public virtual double NumberOfTickets{ get; set; } = 0;

}

class Regular : Viewer{
    public override int Row{
        get => base.Row;
        set{
            if (value <= 200){
                
            }
        }
    }
    public override int Price{
        get => base.Row;
        set{
            double ValueGetter = value;
            if (Row < 200){
                
            }
        } 
    }
    public override int NumberOfTickets{ get; set; }
}
