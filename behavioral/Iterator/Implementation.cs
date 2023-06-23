using System.Security;

namespace Iterator
{
    internal class Implementation
    {
        internal class Person
        {
            public string Name { get; set; }
            public string Country { get; set; }

            public Person(string name, string country)
            {
                Name = name;
                Country = country;
            }
        }

        internal interface IPeopleIterator
        {
            Person First();
            Person Next();
            bool IsDone { get; }
            Person CurrentItem { get; }
        }

        internal interface IPeopleCollection
        {
            IPeopleIterator CreateIterator();
        }

        internal class PeopleCollection : List<Person>, IPeopleCollection
        {
            public IPeopleIterator CreateIterator()
            {
                return new PeopleIterator(this);
            }
        }

        internal class PeopleIterator : IPeopleIterator
        {
            private readonly List<Person> collection;
            private int current = 0;

            public PeopleIterator(PeopleCollection collection) =>
                this.collection = collection.OrderBy(p => p.Name).ToList();

            public bool IsDone => current >= collection.Count;

            public Person CurrentItem => collection[current];

            public Person First()
            {
                current = 0;
                return CurrentItem;
            }

            public Person Next()
            {
                current++;
                if (!IsDone)
                {
                    return CurrentItem;
                }

                return null;
            }
        }
    }
}
