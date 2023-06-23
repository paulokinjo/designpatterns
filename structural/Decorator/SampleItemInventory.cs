namespace Decorator
{
    internal class SampleItemInventory
    {

        // Interface representing the base item
        public interface IItem
        {
            void Use();
        }

        // Base item implementation
        public class BaseItem : IItem
        {
            public void Use()
            {
                Console.WriteLine("Using base item...");
            }
        }

        // Decorator representing an armor item
        public class ArmorDecorator : IItem
        {
            private readonly IItem _item;

            public ArmorDecorator(IItem item)
            {
                _item = item;
            }

            public void Use()
            {
                _item.Use();
                Console.WriteLine("Equipping armor...");
            }
        }

        // Decorator representing a non-tradable item
        public class NonTradableDecorator : IItem
        {
            private readonly IItem _item;

            public NonTradableDecorator(IItem item)
            {
                _item = item;
            }

            public void Use()
            {
                _item.Use();
                Console.WriteLine("This item is non-tradable.");
            }
        }

        // Decorator representing a stackable item
        public class StackableDecorator : IItem
        {
            private readonly IItem _item;
            private readonly int _maxStackSize;

            public StackableDecorator(IItem item, int maxStackSize)
            {
                _item = item;
                _maxStackSize = maxStackSize;
            }

            public void Use()
            {
                _item.Use();
                Console.WriteLine($"This item is stackable (Max stack size: {_maxStackSize}).");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // Creating a base item
                IItem baseItem = new BaseItem();

                // Decorating the base item with armor behavior
                IItem armoredItem = new ArmorDecorator(baseItem);

                // Decorating the armored item with non-tradable behavior
                IItem nonTradableItem = new NonTradableDecorator(armoredItem);

                // Decorating the non-tradable item with stackable behavior
                IItem stackableItem = new StackableDecorator(nonTradableItem, 10);

                // Using the final decorated item
                stackableItem.Use();
            }
        }

    }
}
