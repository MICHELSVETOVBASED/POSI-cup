var bar = new Bar{ Foo = new Foo() };
var foo = new Foo();
bar.Foo.SetValue(1);
foo.SetValue(1);
Console.WriteLine($"{bar.Foo.Value} {foo.Value}");

public struct Foo{
    public int Value;

    public void SetValue(int newValue){
        Value = newValue;
    }
}

public class Bar{
    public Foo Foo{ get; set; }
}