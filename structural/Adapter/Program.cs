Console.Title = "Adpater";

Adapter.ObjectAdapterImplementation.ICityAdapter objAdapter = new Adapter.ObjectAdapterImplementation.CityAdapter();
var objCity = objAdapter.GetCity();

Console.WriteLine(objCity);


Adapter.ClassAdapterImplementation.ICityAdapter classAdapter = new Adapter.ClassAdapterImplementation.CityAdapter();
var classCity = classAdapter.GetCity();

Console.WriteLine(classCity);
