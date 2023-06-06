using System.Text;

namespace Builder
{
    internal class Implementation
    {
        internal class Car
        {
            private readonly List<string> parts = new();
            private readonly string carType;

            public Car(string carType)
            {
                this.carType = carType;
            }

            public void AddPart(string part)
            {
                parts.Add(part);
            }

            public override string ToString()
            {
                StringBuilder sb = new();
                foreach (string part in parts) 
                {
                    sb.Append(part).Append("|");
                }
                return $"Type: {carType}\n{sb}"; 
            }
        }

        internal abstract class CarBuilder
        {
            public Car Car { get; private set; }

            public CarBuilder(string carType)
            {
                Car = new Car(carType);
            }

            public abstract void BuildEngine();
            public abstract void BuildFrame();
        }

        internal class MiniBuilder : CarBuilder
        {
            public MiniBuilder() : base("Mini")
            {

            }

            public override void BuildEngine()
            {
                Car.AddPart("'not a V8'");
            }

            public override void BuildFrame()
            {
                Car.AddPart("'3-door with stripes'");
            }
        }

        internal class BMWBuilder : CarBuilder
        {
            public BMWBuilder() : base("BMW")
            {

            }

            public override void BuildEngine()
            {
                Car.AddPart("'a fancy V8 engine'");
            }

            public override void BuildFrame()
            {
                Car.AddPart("'5-door with metallic finish'");
            }
        }

        internal class Garage
        {
            private CarBuilder? builder;

            public Garage()
            {
                    
            }

            public void Construct(CarBuilder builder)
            {
                this.builder = builder;
                builder.BuildEngine();
                builder.BuildFrame();
            }

            public void Show()
            {
                Console.WriteLine(builder?.Car.ToString());
            }
        }
    }
}
