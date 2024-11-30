using System;
using System.Collections.Generic;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create Tree and two Decorators
            Tree c = new Tree();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            Garland d2 = new Garland();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d1.AddDecoration("a snowflake");
            d1.AddDecoration("a candy cane"); 
            d2.GetTreeState();

            // Wait for user
            Console.Read();
        }
    }
    // "ITree"
    abstract class ITree
    {
        public abstract void GetTreeState();
    }

    // "Tree"
    class Tree : ITree
    {
        public override void GetTreeState()
        {
            Console.WriteLine("A completely normal tree         // Tree.Operation()");
        }
    }
    // "Decorator"
    abstract class Decorator : ITree
    {
        protected ITree _tree;

        public void SetComponent(ITree tree)
        {
            this._tree = tree;
        }
        public override void GetTreeState()
        {
            if (_tree != null)
            {
                _tree.GetTreeState();
            }
        }
    }

    // "ConcreteDecoratorA"
    class ConcreteDecoratorA : Decorator
    {
        private List<string> _decorations = new List<string>();

        public void AddDecoration(string decoration)
        {
            _decorations.Add(decoration);
        }

        public override void GetTreeState()
        {
            base.GetTreeState();
            foreach (string decoration in _decorations)
            {
                Console.Write("with " + decoration);
                Console.WriteLine("         // Decorator.GetTreeState()");
            }
        }
    }

    // "Garland" 
    class Garland : Decorator
    {
        public override void GetTreeState()
        {
            base.GetTreeState();
            Console.WriteLine("glimmers joyously!        // Garland.GetTreeState()");
        }
    }
}
