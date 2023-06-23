namespace Strategy
{
    internal class Implementation
    {
        internal class Order
        {
            public string Name { get; internal set; }

            public Order(string name)
            {
                Name = name;
            }

            public IExportService? ExportService { get; internal set; }

            public void Export()
            {
                ExportService?.Export(this);
            }
        }

        internal interface IExportService
        {
            void Export(Order order);
        }

        internal class JsonExportService : IExportService
        {
            public void Export(Order order)
            {
                Console.WriteLine($"Exporting {order.Name} to Json.");
            }
        }

        internal class XMLExportService : IExportService
        {
            public void Export(Order order)
            {
                Console.WriteLine($"Exporting {order.Name} to XML.");
            }
        }

        internal class CSVExportService : IExportService
        {
            public void Export(Order order)
            {
                Console.WriteLine($"Exporting {order.Name} to CSV.");
            }
        }
    }
}
