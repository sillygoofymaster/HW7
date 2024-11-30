using System;
namespace FactoryMethodExample
{
    //абстрактний клас творця, який має абстрактний метод FactoryMethod, що приймає тип продукта
    public abstract class Creator
    {
        public abstract Burger FactoryMethod(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override Burger FactoryMethod(int type)
        {
            switch (type)
            {
                //повертає об'єкт A, якщо type==1
                case 1: return new Hamburger();
                //повертає об'єкт B, якщо type==2  
                case 2: return new Cheeseburger();
                case 3: return new Somethingburger();
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class Burger { } //абстрактний клас продукт

    //конкретні продукти з різною реалізацією
    public class Hamburger : Burger 
    {
        public Hamburger()
        {
            Console.WriteLine("Hamburger created");
        }
    }

    public class Cheeseburger : Burger 
    {
        public Cheeseburger()
        {
            Console.WriteLine("Cheeseburger created");
        }
    }

    public class Somethingburger : Burger
    {
        public Somethingburger()
        {
            Console.WriteLine("Somethingburger created");
        }
    }


    class MainApp
    {
        static void Main()
        {       //створюємо творця
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 3; i++)
            {
                //створюємо спочатку продукт з типом 1, потім з типом 2
                var product = creator.FactoryMethod(i);
                Console.WriteLine("Where id = {0}, Created {1} ", i, product.GetType());
            }
            Console.ReadKey();
        }
    }
}

