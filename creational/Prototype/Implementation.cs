using Newtonsoft.Json;

namespace Prototype
{
    internal class Implementation
    {
        internal abstract class Person
        {
            public abstract string Name { get; set; }
            public abstract Person Clone(bool deepClone);
        }

        internal class Manager : Person
        {
            public override string Name { get; set; }

            public Manager(string name)
            {
                Name = name;
            }

            public override Person Clone(bool deepClone = false)
            {
                if (deepClone)
                {
                    var objectAsJson = JsonConvert.SerializeObject(this);
                    return JsonConvert.DeserializeObject<Manager>(objectAsJson);
                }
                return (Person)MemberwiseClone();
            }
        }

        internal class Employee : Person
        {
            public Manager Manager { get; private set; }

            public override string Name { get; set; }

            public Employee(string name, Manager manager)
            {
                Name = name;
                Manager = manager;
            }

            public override Person Clone(bool deepClone = false)
            {
                if (deepClone)
                {
                    var objectAsJson = JsonConvert.SerializeObject(this);
                    return JsonConvert.DeserializeObject<Employee>(objectAsJson);
                }
                return (Person)MemberwiseClone();
            }
        }
    }
}
