using System.ComponentModel.DataAnnotations;
using static ChainOfResponsibility.Implementation;

Console.Title = "Chain of Responsibility";

var validDocument = new Document("How to avoid Java Development",
    DateTimeOffset.Now, true, true);

var invalidDocument = new Document("How to avoid Java Development",
    DateTimeOffset.Now, false, true);

var documentHandlerChain = new DocumentTitleHandler();
documentHandlerChain
    .SetSuccessor(new DocumentLastModifiedHandler())
    .SetSuccessor(new DocumentApprovedByLitigationHandler())
    .SetSuccessor(new DocumentApprovedByManagerHandler());

try
{
    documentHandlerChain.Handle(validDocument);
    Console.WriteLine("Valid document is valid");
    documentHandlerChain.Handle(invalidDocument);
    Console.WriteLine("invalid coument is valid");
}
catch (ValidationException validationException)
{
    Console.WriteLine(validationException.Message);
}