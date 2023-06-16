
Console.Title = "Composite";

var root = new Composite.Implementation.Directory("root", 0);
var topLevelFile = new Composite.Implementation.File("toplevel.txt", 100);
var topLevelDirectory1 = new Composite.Implementation.Directory("topleveldirectory1", 4);
var topLevelDirectory2 = new Composite.Implementation.Directory("topleveldirectory2", 4);

root.Add(topLevelFile);
root.Add(topLevelDirectory1);
root.Add(topLevelDirectory2);

var subLevelFile1 = new Composite.Implementation.File("sublevel1.txt", 200);
var subLevelFile2 = new Composite.Implementation.File("sublevel2.txt", 150);

topLevelDirectory2.Add(subLevelFile1);
topLevelDirectory2.Add(subLevelFile2);

Console.WriteLine($"Size of topLevelDirectory1: {topLevelDirectory1.GetSize()}");
Console.WriteLine($"Size of topLevelDirectory2: {topLevelDirectory2.GetSize()}");
Console.WriteLine($"Size of root: {root.GetSize()}");