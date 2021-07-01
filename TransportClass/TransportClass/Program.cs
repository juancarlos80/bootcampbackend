using System;

namespace TransportClass
{

    interface ITransport
    { 
        public int LimitOfSpeed { set; get; }
        public int Capacity { set; get; }        

    }

    interface ILandTransport : ITransport
    {        
        public int NumberWheels { set; get; }

        public void Drive();        
    }

    interface IAirTransport : ITransport
    {                        
        public int MaximunHeigth { set; get; }

        public void Fly();

        public void Land();        
    }

    interface IAquaticTransport : ITransport
    {
        public void Navigate();
        
    }


    class Toyota : ILandTransport {
        
        public int NumberWheels { get; set ; }
        public int LimitOfSpeed { get; set; }
        public int Capacity { get; set; }

        public void Drive()
        {
            Console.WriteLine("Toyota on the road");
        }

        public override string ToString()
        {
            return string.Format(
                "I'm a Toyota Car capacity: {0} people, limit of speed: {1} km/h, number of wheels: {2}",
                Capacity,
                LimitOfSpeed,                
                NumberWheels);
        }
    }

    class ElectricFlyingCar : ILandTransport, IAirTransport
    {
        public int NumberWheels { get; set; }
        public int LimitOfSpeed { get; set; }
        public int Capacity { get; set; }        
        public int MaximunHeigth { get; set; }

        public void Drive()
        {
            Console.WriteLine("Electric car on the road");
        }

        public void Fly()
        {
            Console.WriteLine("Electric car flying");
        }

        public void Land()
        {
            Console.WriteLine("Electric car landing");
        }

        public override string ToString()
        {
            return string.Format(
                "I'm Electric flying Car capacity: {0} people, limit of speed: {1} km/h, maximum height: {2} km, number of wheels: {3}",
                Capacity,
                LimitOfSpeed,
                MaximunHeigth,
                NumberWheels);
        }
    }

    class Boat : IAquaticTransport
    {
        public int LimitOfSpeed { get; set; }
        public int Capacity { get; set; }

        public void Navigate()
        {
            Console.WriteLine("Boat on the water");
        }

        public override string ToString()
        {
            return string.Format(
                "I'm a Boat capacity: {0} people, limit of speed: {1} km/h",
                Capacity,
                LimitOfSpeed
                );
        }
    }

    class Boeing : IAirTransport
    {
        public int MaximunHeigth { get; set; }
        public int LimitOfSpeed { get; set; }
        public int Capacity { get; set; }

        public override string ToString()
        {
            return string.Format(
                "I'm Boeing Air transport capacity: {0} people, limit of speed: {1} km/h, maximum height: {2} km", 
                Capacity,
                LimitOfSpeed,
                MaximunHeigth);
        }
        public void Land()
        {
            Console.WriteLine("Boeing landing");
        }

        public void Fly()
        {
            Console.WriteLine("Boeing flying");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Boeing boeingBoa = new Boeing
            {
                Capacity = 400,
                MaximunHeigth = 4000,
                LimitOfSpeed = 600
            };

            Console.WriteLine(boeingBoa);
            boeingBoa.Fly();
            boeingBoa.Land();

            var superCar = new ElectricFlyingCar
            {
                NumberWheels = 3,
                MaximunHeigth = 300
            };

            Console.WriteLine(superCar);
            superCar.Fly();
            superCar.Land();
            superCar.Drive();


            Boat tinyBoat = new Boat
            {
                Capacity = 2,
                LimitOfSpeed = 50
            };

            Console.WriteLine(tinyBoat);

        }
    }
}
