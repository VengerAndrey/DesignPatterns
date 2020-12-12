using System;
using System.Collections.Generic;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayCollection arrayCollection = new ArrayCollection(5);

            for (int i = 0; i < arrayCollection.Length(); i++)
            {
                arrayCollection[i] = new Item($"Item {i}");
            }

            IIterator arrayIterator = arrayCollection.GetIterator();

            Console.WriteLine("Array collection iteration:");

            while (arrayIterator.HasMore())
            {
                Console.WriteLine(arrayIterator.GetNext().Name);
            }

            Console.WriteLine();

            DictionaryCollection dictionaryCollection = new DictionaryCollection();

            for (int i = 0; i < 10; i++)
            {
                dictionaryCollection[$"Key {i}"] = new Item($"Item {i}");
            }

            IIterator dictionaryIterator = dictionaryCollection.GetIterator();

            Console.WriteLine("Dictionary collection iteration:");

            while (dictionaryIterator.HasMore())
            {
                Console.WriteLine(dictionaryIterator.GetNext().Name);
            }
        }
    }

    class Item
    {
        public string Name { get; set; }

        public Item(string name)
        {
            Name = name;
        }
    }

    interface IIterator
    {
        Item GetNext();
        bool HasMore();
    }

    interface ICollection
    {
        IIterator GetIterator();
    }

    class ArrayCollection : ICollection
    {
        private Item[] items;

        public ArrayCollection(int size)
        {
            items = new Item[size];
        }

        public Item this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }

        public int Length()
        {
            return items.Length;
        }

        public IIterator GetIterator()
        {
            return new ArrayCollectionIterator(this);
        }
    }

    class ArrayCollectionIterator : IIterator
    {
        private ArrayCollection collection;

        private int currentIndex;

        public ArrayCollectionIterator(ArrayCollection collection)
        {
            this.collection = collection;
            currentIndex = 0;
        }

        public Item GetNext()
        {
            return collection[currentIndex++];
        }

        public bool HasMore()
        {
            return currentIndex < collection.Length();
        }
    }

    class DictionaryCollection : ICollection
    {
        private List<string> keys= new List<string>();
        private List<Item> values = new List<Item>();

        public Item this[string key]
        {
            get => values[keys.IndexOf(key)];
            set
            {
                keys.Add(key);
                values.Add(value);
            }
        }

        public List<string> GetKeys()
        {
            return keys;
        }

        public IIterator GetIterator()
        {
            return new DictionaryCollectionIterator(this);
        }
    }

    class DictionaryCollectionIterator : IIterator
    {
        private DictionaryCollection collection;
        private int currentIndex;

        public DictionaryCollectionIterator(DictionaryCollection collection)
        {
            this.collection = collection;
            currentIndex = 0;
        }

        public Item GetNext()
        {
            return collection[collection.GetKeys()[currentIndex++]];
        }

        public bool HasMore()
        {
            return currentIndex < collection.GetKeys().Count;
        }
    }
}
