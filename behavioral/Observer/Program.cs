using static Observer.Implementation;

Console.Title = "Observer";

TicketStockService ticketStockService = new TicketStockService();
TicketResellerService ticketResellerService= new TicketResellerService();
OrderService orderService = new OrderService();

orderService.AddObserver(ticketStockService);
orderService.AddObserver(ticketResellerService);
orderService.CompleteTicketSale(1, 2);
orderService.RemoveObserver(ticketResellerService);
orderService.CompleteTicketSale(2, 4);

