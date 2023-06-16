namespace Adapter
{
    internal class ClassAdapterImplementation
    {
        internal class CityFromExternalSystem
        {
            public string Name { get; private set; }
            public string NickName { get; private set; }
            public int Inhanbitants { get; }
            public int Inhabitants { get; private set; }

            public CityFromExternalSystem(string name, string nickName, int inhabitants)
            {
                Name = name;
                NickName = nickName;
                Inhabitants = inhabitants;
            }
        }

        internal class ExternalSystem
        {
            public CityFromExternalSystem GetCity()
            {
                return new CityFromExternalSystem("New York", "'NY'", 1000000);
            }
        }

        internal class City
        {
            public string FullName { get; private set; }
            public long Inhabitants { get; private set; }

            public City(string fullName, long inhabitants)
            {
                FullName = fullName;
                Inhabitants = inhabitants;
            }

            public override string ToString() => $"{FullName}, {Inhabitants}";
        }

        internal interface ICityAdapter
        {
            City GetCity();
        }

        internal class CityAdapter : ExternalSystem, ICityAdapter
        {
            public City GetCity()
            {
                var cityFromExternalSystem = base.GetCity();

                return new City(
                    $"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}",
                    cityFromExternalSystem.Inhabitants);
            }
        }
    }
}
