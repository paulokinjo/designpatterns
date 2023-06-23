using static Iterator.Implementation;

Console.Title = "Iterator";

PeopleCollection people = new();

people.Add(new Person("Paulo", "Brazil"));
people.Add(new Person("Aline", "Brazil"));
people.Add(new Person("Eliana", "Brazil"));
people.Add(new Person("Kinjo", "Brazil"));
people.Add(new Person("Airin", "Japan"));

var peopleIterator = people.CreateIterator();

Person person = peopleIterator.First();
while (!peopleIterator.IsDone)
{
    Console.WriteLine(person?.Name);
    person = peopleIterator.Next();
}