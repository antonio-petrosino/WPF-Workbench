using ConsoleApplicationTest;
using System;

namespace es_01
{
    class Program
    {
        // static serve a far si che il metodo sia accessibile senza istanziare la classe
        // solo quando serve

        public static void Main(string[] args)
        {
            // struct conviene rispetto alla class solo se occupa uno spazio inferire a 16 byte
            // struct è un tipo di dato valore, class è un tipo di dato riferimento

            // Console.WriteLine("Hello World! Mio");
            Application app = new Application("CLEAN App1", 100, 50);


            Console.WriteLine("Con questo caso, sporco l'oggetto satellite.");
            Satellite satellite_s = new Satellite("Satellite1", 100, 50, app);

            Console.WriteLine(satellite_s.ToString());

            app.Name = "Modified App1";

            Console.WriteLine(satellite_s.ToString());


            Console.WriteLine("Con questo caso, invece, costruendo un clone, non sporco l'oggetto satellite.");
            app.Name = "Clean APP1";
            Satellite satellite = new Satellite("Satellite1", 100, 50, app.Clone());
            
            Console.WriteLine(satellite.ToString());

            app.Name = "Modified APP1";

            Console.WriteLine(satellite.ToString());

            var (name_deco, velocity_deco, altitude_deco, app2_deco) = satellite;
            Console.WriteLine($"DECONSTRUCTOR: Name: {name_deco}, Velocity: {velocity_deco}, Altitude: {altitude_deco}, Application: {app2_deco}");

            Console.WriteLine("TEST: Overload of the Operator +!!!!");
            Satellite s_somma = satellite + satellite;
            Console.WriteLine(s_somma.ToString());

        }
    }
}

