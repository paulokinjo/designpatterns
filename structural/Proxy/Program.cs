using static Proxy.Implementation;

Console.Title = "Proxy";

Console.WriteLine("Constructing document.");
var doc = new Document("Sample.pdf");
Console.WriteLine("Document constructed.");
doc.DisplayDocument();

Console.WriteLine();


Console.WriteLine("Construction document proxy.");
var docProxy = new DocumentProxy("SampleProxy.pdf");
Console.WriteLine("Document proxy constructed.");
docProxy.DisplayDocument();

Console.WriteLine();

Console.WriteLine("Constructing protected document proxy.");
var docProtected = new ProtectedDocumentProxy("Protected.pdf", "Viewer");
Console.WriteLine("Protected document proxy constructed");
docProtected.DisplayDocument();

Console.WriteLine();

Console.WriteLine("Constructing protected document proxy.");
docProtected = new ProtectedDocumentProxy("Protected.pdf", "AnotherRole");
Console.WriteLine("Protected document proxy constructed");
docProtected.DisplayDocument();


