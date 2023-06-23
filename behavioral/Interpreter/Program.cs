using static Interpreter.Implementation;

Console.Title = "Interpreter";

var expressions = new List<RomanExpression> { new RomanOneExpression() };

var context = new RomanContext(7);
foreach(var expression in expressions)
    expression.Interpret(context);

Console.WriteLine(context.Output);