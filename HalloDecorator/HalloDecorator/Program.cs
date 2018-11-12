using System;

namespace HalloDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Decorator!");

            var pizza = new Salami(new Käse(new Käse(new Pizza())));

            Console.WriteLine($"{pizza.Name} {pizza.Preis:c}");

            Console.ReadLine();
        }
    }


    public class Salami : Deco
    {
        public override string Name => parent.Name + " Salami";

        public override decimal Preis => parent.Preis + 2m;

        public Salami(IComponent comp) : base(comp)
        { }
    }

    public class Käse : Deco
    {
        public override string Name => parent.Name + " Käse";

        public override decimal Preis => parent.Preis + 1m;

        public Käse(IComponent comp) : base(comp)
        { }
    }


    public abstract class Deco : IComponent
    {
        public abstract string Name { get; }

        public abstract decimal Preis { get; }

        protected IComponent parent;

        public Deco(IComponent parent)
        {
            this.parent = parent;
        }
    }

    public class Pizza : IComponent
    {
        public string Name => "Pizza";

        public decimal Preis => 5m;
    }

    public interface IComponent
    {
        string Name { get; }
        decimal Preis { get; }
    }
}
