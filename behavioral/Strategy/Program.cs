using static Strategy.Implementation;

Console.Title = "Strategy";

var order = new Order("Marvin");
order.ExportService = new CSVExportService();
order.Export();

order.ExportService = new JsonExportService();
order.Export();

order.ExportService = new XMLExportService();
order.Export();