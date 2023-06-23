using static TemplateMethod.Implementation;

Console.Title = "Template Method";

ExchangeMailParser exchange = new();
Console.WriteLine(exchange.ParseMailBody(Guid.NewGuid().ToString()));
Console.WriteLine();

ApacheMailParser apache = new();
Console.WriteLine(apache.ParseMailBody(Guid.NewGuid().ToString()));
Console.WriteLine();

EudoraMailParser eudora = new();
Console.WriteLine(eudora.ParseMailBody(Guid.NewGuid().ToString()));
Console.WriteLine();