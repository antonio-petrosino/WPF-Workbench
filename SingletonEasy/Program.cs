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
        interface IPersonaggio
        {
            public void IncreaseExperience(int quantity);
            public int GetExperience();

            public void IncreaseLevel();
            public int GetLevel();
        }


        class Druido : IPersonaggio
        {
            private int _experience_of_the_druid = 0;
            private int _level_of_the_druid = 0;

            public void IncreaseExperience(int quantity) { _experience_of_the_druid += quantity; Console.WriteLine($"Nuova esperienza del druido: {_experience_of_the_druid}"); }
            public int GetExperience() { return _experience_of_the_druid; }

            public void IncreaseLevel() { _level_of_the_druid++; }
            public int GetLevel() { return _level_of_the_druid; }
        }

        class Guerriero : IPersonaggio
        {
            private int _experience_of_the_warrior = 0;
            private int _level_of_the_warrior = 0;

            public void IncreaseExperience(int quantity) { _experience_of_the_warrior += quantity; Console.WriteLine($"Nuova esperienza del guerriero: {_experience_of_the_warrior}"); }
            public int GetExperience() { return _experience_of_the_warrior; }

            public void IncreaseLevel() { _level_of_the_warrior++; }
            public int GetLevel() { return _level_of_the_warrior; }
        }

        class Mago : IPersonaggio
        {
            private int _experience_of_the_mage = 0;
            private int _level_of_the_mage = 0;

            public void IncreaseExperience(int quantity) { _experience_of_the_mage += quantity; Console.WriteLine($"Nuova esperienza del mago: {_experience_of_the_mage}"); }
            public int GetExperience() { return _experience_of_the_mage; }

            public void IncreaseLevel() { _level_of_the_mage++; }
            public int GetLevel() { return _level_of_the_mage; }
        }

        interface ICustomClonable<TEntity>
        {
            TEntity Clone();    
            
            void CustomConsoleWriter();
        }

        class CustomString : ICustomClonable<CustomString>
        {

            static public int NumberOfCreatedObject;

            private String _stringa = null;

            public String Stringa { get { return _stringa; } set { _stringa = value; } }

            public void Edit(String value)
            {
                _stringa = value;
            }
            
            public CustomString(String elem) { _stringa = elem; NumberOfCreatedObject++; }

            public CustomString Clone()
            {
                return new CustomString(this._stringa);
            }

            public void CustomConsoleWriter()
            {
                Console.WriteLine($"Stringa: {_stringa}");
            }
            public override string ToString()
            {
                return $"{_stringa}";
            }
        }


        static void Scambia<TEntity>(ref TEntity a, ref TEntity b)
        {
            //TEntity temp = a;
            //a = b;
            //b = temp;
            (b, a) = (a, b);
            Console.WriteLine($"Scambio: {a} <-> {b}");
        }

        class MyList<TEntity> where TEntity : ICustomClonable<TEntity> // where UEntity : TEntity vincolo di ereditarietà
        {
            TEntity[] _array = null;
            int _count = 0;

            int _capacita { get; set; }

            public int Count { get { return _count; } }
            public int Capacita { get { return _capacita; } }


            public MyList(int cap = 1)
            {
                _capacita = cap;

                _array = new TEntity[_capacita];
                
                for(int i = 0; i < _capacita; i++)
                {
                    _array[i] = default;
                }

            }

            public void Add(TEntity nuovo)
            {
                if (_count == _capacita) Espandi();
                                
                _array[_count] = nuovo.Clone();
                // grazie a questa riga con il clona non avrò più il riferimento all'oggetto di provenienza
                // evitando errori propagati da modifiche successive

                //_array[_count] = nuovo;
                _count++; 

                Console.WriteLine($"Aggiunto elemento: {_array[_count - 1]}");
            }

            public void Espandi(int new_elements = 1)
            {                
                TEntity[] _new_array = new TEntity[_capacita + new_elements];
                _array.CopyTo(_new_array, 0);
                _array = _new_array;
                _capacita += new_elements;
                Console.WriteLine($"Espansione a {_capacita} elementi");
            }

            public TEntity this[int index]
            {
                get { return _array[index]; }
                set { _array[index] = value; }
            }
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MyList<CustomString> list = new MyList<CustomString>();

            // utilizzo di un parametro statico, viene inizializzato una sola volta
            Console.WriteLine($"Numero di oggetti creati: {CustomString.NumberOfCreatedObject}");

            CustomString prova1 = new CustomString("Stringa1");

            Console.WriteLine($"Numero di oggetti creati: {CustomString.NumberOfCreatedObject}");

            CustomString prova2 = new CustomString("Stringa2");
            Console.WriteLine($"Numero di oggetti creati: {CustomString.NumberOfCreatedObject}");

            CustomString prova3 = new CustomString("Stringa3");

            Console.WriteLine($"Numero di oggetti creati: {CustomString.NumberOfCreatedObject}");
            CustomString prova4 = new CustomString("Stringa4");

            Console.WriteLine($"Numero di oggetti creati: {CustomString.NumberOfCreatedObject}");
            CustomString prova5 = new CustomString("Stringa5");

            Console.WriteLine($"Numero di oggetti creati: {CustomString.NumberOfCreatedObject}");


            Scambia(ref prova1, ref prova2);
            Scambia(ref prova3, ref prova4);


            list.Add(prova1);
            list.Add(prova2);
            list.Add(prova3);
            list.Add(prova4);
            list.Add(prova5);


            prova1.Edit("MOD:Stringa1");
            prova2.Edit("MOD:Stringa2");
            prova3.Edit("MOD:Stringa3");

            Console.WriteLine("Custom MyList() with generics");
            list[0].CustomConsoleWriter();
            list[1].CustomConsoleWriter();
            list[2].CustomConsoleWriter();
            list[3].CustomConsoleWriter();
            list[4].CustomConsoleWriter();

            Console.WriteLine("var");
            Console.WriteLine($"prova1: {prova1}");
            Console.WriteLine($"prova2: {prova2}");
            Console.WriteLine($"prova3: {prova3}");
            Console.WriteLine($"prova4: {prova4}");
            Console.WriteLine($"prova5: {prova5}");


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