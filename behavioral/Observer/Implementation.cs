namespace Observer
{
    internal class Implementation
    {
        internal class TicketChange
        {
            public int Amount { get; private set; }
            public int ArtistId { get; private set; }

            public TicketChange(int artistId, int amount)
            {
                ArtistId = artistId;
                Amount = amount;
            }
        }

        internal interface ITicketChangeListener
        {
            void ReceiveTicketChangeNotification(TicketChange ticketChange);
        }

        internal abstract class TicketChangeNotifier
        {
            private List<ITicketChangeListener> observers = new();
            public void AddObserver(ITicketChangeListener observer) => observers.Add(observer);
            public void RemoveObserver(ITicketChangeListener observer) => observers.Remove(observer);

            public void Notify(TicketChange ticketChange)
            {
                foreach (var observer in observers)
                {
                    observer.ReceiveTicketChangeNotification(ticketChange);
                }
            }
        }

        internal class OrderService : TicketChangeNotifier
        {
            public void CompleteTicketSale(int artistId, int amount)
            {
                Console.WriteLine($"{nameof(OrderService)} is changing its state.");

                Console.WriteLine($"{nameof(OrderService)} is notifying observers...");
                Notify(new TicketChange(artistId, amount));
            }
        }

        internal class TicketResellerService : ITicketChangeListener
        {
            public void ReceiveTicketChangeNotification(TicketChange ticketChange)
            {
                Console.WriteLine($"{nameof(TicketResellerService)} notified " +
                    $"of ticket change: artiist {ticketChange.ArtistId}, amount " +
                    $"{ticketChange.Amount}");
            }
        }

        internal class TicketStockService : ITicketChangeListener
        {
            public void ReceiveTicketChangeNotification(TicketChange ticketChange)
            {
                Console.WriteLine($"{nameof(TicketStockService)} notified " +
                    $"of ticket change: artiist {ticketChange.ArtistId}, amount " +
                    $"{ticketChange.Amount}");
            }
        }
    }
}
