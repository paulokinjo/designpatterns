namespace Decorator
{
    internal class Implementation
    {
        internal interface IMailService
        {
            bool SendMail(string message);
        }

        internal class CloudMailService : IMailService
        {
            public bool SendMail(string message)
            {
                Console.WriteLine($"Message \"{message}\" " +
                    $"sent via {nameof(CloudMailService)}");
                return true;
            }
        }

        internal class OnPremiseMailService : IMailService
        {
            public bool SendMail(string message)
            {
                Console.WriteLine($"Message \"{message}\" " +
                    $"sent via {nameof(OnPremiseMailService)}");
                return true;
            }
        }

        internal abstract class MailServiceDecoratorBase : IMailService
        {
            private readonly IMailService mailService;
            public MailServiceDecoratorBase(IMailService mailService)
            {
                this.mailService = mailService;
            }

            public virtual bool SendMail(string message)
            {
                return mailService.SendMail(message);
            }
        }

        internal class StatisticsDecorator : MailServiceDecoratorBase
        {
            public StatisticsDecorator(IMailService mailService) : base(mailService) { }


            public override bool SendMail(string message)
            {
                Console.WriteLine($"Collectiing statistics in {nameof(StatisticsDecorator)}");
                return base.SendMail(message);
            }
        }

        internal class MessageDatabaseDecorator : MailServiceDecoratorBase
        {
            public MessageDatabaseDecorator(IMailService mailService) : base(mailService) { }
            public List<string> SentMessages { get; private set; } = new();

            public override bool SendMail(string message)
            {
                if (base.SendMail(message))
                {
                    SentMessages.Add(message);
                    return true;
                }
                return false;
            }
        }
    }
}
