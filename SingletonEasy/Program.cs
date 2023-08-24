using System;
using System.Diagnostics;

namespace SingletonEasy
{


    class MySingletonClass
    {

        static private readonly object _lock = new object();

        static private MySingletonClass? _instance = null;

        static public MySingletonClass Instance
        {
            get
            {

                if (_instance is null) 
                    // ho un risparmio dal punto di vista computazionale perchè non entro nel lock
                {
                    lock (_lock)
                    {
                        Console.WriteLine("COSTRUTTORE: Lock");
                        if (_instance is null)
                        {
                            _instance = new MySingletonClass();
                        }
                        
                    }
                }

                return _instance;

                //return _instance ??= new MySingletonClass();
            }
        }

        public void Metodo() { Console.WriteLine("METODO: Hello, World!"); }

        private MySingletonClass() {
            Console.WriteLine("COSTRUTTORE: Oggetto creato.");
        }
    }

    class Program
    {
        public interface IPersonaggio
        {
            public void IncreaseExperience(int quantity);
            public int GetExperience();

            public void IncreaseLevel();
            public int GetLevel();
        }


        public class Druido : IPersonaggio
        {
            private int _experience_of_the_druid = 0;
            private int _level_of_the_druid = 0;

            public void IncreaseExperience(int quantity) { _experience_of_the_druid += quantity; Console.WriteLine($"Nuova esperienza del druido: {_experience_of_the_druid}"); }
            public int GetExperience() { return _experience_of_the_druid; }

            public void IncreaseLevel() { _level_of_the_druid++; }
            public int GetLevel() { return _level_of_the_druid; }
        }

        public class Guerriero : IPersonaggio
        {
            private int _experience_of_the_warrior = 0;
            private int _level_of_the_warrior = 0;

            public void IncreaseExperience(int quantity) { _experience_of_the_warrior += quantity; Console.WriteLine($"Nuova esperienza del guerriero: {_experience_of_the_warrior}"); }
            public int GetExperience() { return _experience_of_the_warrior; }

            public void IncreaseLevel() { _level_of_the_warrior++; }
            public int GetLevel() { return _level_of_the_warrior; }
        }

        public class Mago : IPersonaggio
        {
            private int _experience_of_the_mage = 0;
            private int _level_of_the_mage = 0;

            public void IncreaseExperience(int quantity) { _experience_of_the_mage += quantity; Console.WriteLine($"Nuova esperienza del mago: {_experience_of_the_mage}"); }
            public int GetExperience() { return _experience_of_the_mage; }

            public void IncreaseLevel() { _level_of_the_mage++; }
            public int GetLevel() { return _level_of_the_mage; }
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MySingletonClass.Instance.Metodo();
            MySingletonClass.Instance.Metodo();
            MySingletonClass.Instance.Metodo();

            // non ho la threadsafety così perchè due thread possono istanziarlo contemporaneamente

            IPersonaggio player1 = new Druido();
            IPersonaggio player2 = new Guerriero();
            IPersonaggio player3 = new Mago();

            //Druido druido = new(); // targetTypedNew

            player1.IncreaseExperience(100);
            player2.IncreaseExperience(100);
            player3.IncreaseExperience(100);


            stopwatch.Stop();   
            Console.WriteLine($"Tempo di esecuzione: {stopwatch.ElapsedMilliseconds} ms");

        }
    }

}