using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility
{
    internal class Implementation
    {
        internal class Document
        {
            public string Title { get; set; }
            public DateTimeOffset LastModified { get; set; }
            public bool ApprovedByLitigation { get; set; }
            public bool ApprovedByManagement { get; set; }

            public Document(string title, DateTimeOffset lastModified, bool approvedByLitigation, bool approvedByManagement)
            {
                Title = title;
                LastModified = lastModified;
                ApprovedByLitigation = approvedByLitigation;
                ApprovedByManagement = approvedByManagement;
            }
        }

        internal interface IHandler<T> where T : class
        {
            IHandler<T> SetSuccessor(IHandler<T> successor);
            void Handle(T request);
        }

        internal class DocumentTitleHandler : IHandler<Document>
        {
            private IHandler<Document>? successor;

            public void Handle(Document document)
            {
                if (string.IsNullOrEmpty(document.Title))
                {
                    throw new ValidationException(
                        new ValidationResult(
                            "Title must be filled out",
                            new List<string>() { "Title" }), null, null);
                }

                successor?.Handle(document);
            }

            public IHandler<Document> SetSuccessor(IHandler<Document> successor)
            {
                this.successor = successor;
                return successor;
            }
        }

        internal class DocumentLastModifiedHandler : IHandler<Document>
        {
            private IHandler<Document>? successor;

            public void Handle(Document document)
            {
                if (document.LastModified < DateTime.UtcNow.AddDays(-30))
                {
                    throw new ValidationException(
                        new ValidationResult(
                            "Document must be modified in the last 30 days",
                            new List<string>() { "LastModified" }), null, null);
                }

                successor?.Handle(document);
            }

            public IHandler<Document> SetSuccessor(IHandler<Document> successor)
            {
                this.successor = successor;
                return successor;
            }
        }

        internal class DocumentApprovedByLitigationHandler : IHandler<Document>
        {
            private IHandler<Document>? successor;

            public void Handle(Document document)
            {
                if (!document.ApprovedByLitigation)
                {
                    throw new ValidationException(
                        new ValidationResult(
                            "Document must be approved by litigation",
                            new List<string>() { "ApprovedByLitigation" }), null, null);
                }

                successor?.Handle(document);
            }

            public IHandler<Document> SetSuccessor(IHandler<Document> successor)
            {
                this.successor = successor;
                return successor;
            }
        }

        internal class DocumentApprovedByManagerHandler : IHandler<Document>
        {
            private IHandler<Document>? successor;

            public void Handle(Document document)
            {
                if (!document.ApprovedByManagement)
                {
                    throw new ValidationException(
                        new ValidationResult(
                            "Document must be approved by Manager",
                            new List<string>() { "ApprovedByLitigation" }), null, null);
                }

                successor?.Handle(document);
            }

            public IHandler<Document> SetSuccessor(IHandler<Document> successor)
            {
                this.successor = successor;
                return successor;
            }
        }
    }
}
