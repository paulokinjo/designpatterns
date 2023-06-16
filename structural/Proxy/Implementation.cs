namespace Proxy
{
    internal class Implementation
    {
        internal interface IDocument
        {
            void DisplayDocument();
        }

        internal class Document : IDocument
        {
            private readonly string fileName;
            
            public string? Title { get; private set; }
            public string? Content { get; private set; }
            public int AuthorId { get; private set; }
            public DateTimeOffset LastAccessed { get; private set; }

            public Document(string fileName)
            {
                this.fileName = fileName;
                LoadDocument(fileName);
            }

            private void LoadDocument(string fileName)
            {
                Console.WriteLine("Executing expensive action: loading a file from disk");

                Thread.Sleep(1000);

                Title = "An expensive document";
                Content = "Lots and lots of content";
                AuthorId = 1;
                LastAccessed = DateTimeOffset.Now;
            }

            public void DisplayDocument()
            {
                Console.WriteLine($"Title: {Title}, Content: {Content}");
            }
        }

        internal class DocumentProxy : IDocument
        {
            private readonly Lazy<Document> document;

            public DocumentProxy(string fileName) =>
                document = new Lazy<Document>(() => new Document(fileName));

            public void DisplayDocument() => document.Value.DisplayDocument();
        }

        internal class ProtectedDocumentProxy : IDocument
        {
            private readonly DocumentProxy documentProxy;
            private readonly string userRole;

            public ProtectedDocumentProxy(string fileName, string userRole)
            {
                documentProxy = new DocumentProxy(fileName);
                this.userRole = userRole;
            }

            public void DisplayDocument()
            {
                Console.WriteLine($"Entering Display Document in {nameof(ProtectedDocumentProxy)}");

                if (userRole != "Viewer")
                {
                    throw new UnauthorizedAccessException();
                }

                documentProxy.DisplayDocument();

                Console.WriteLine($"Exiting DisplayDocument in {nameof(ProtectedDocumentProxy)}");
            }
        }
    }
}
