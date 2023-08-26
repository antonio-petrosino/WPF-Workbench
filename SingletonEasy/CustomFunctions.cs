using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonEasy
{
   
    internal class CustomFunctions
    {
        public class MySingletonClass
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

            private MySingletonClass()
            {
                Console.WriteLine("COSTRUTTORE: Oggetto creato.");
            }
        }

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



        public interface ICustomClonable<TEntity>
        {
            TEntity Clone();

            void CustomConsoleWriter();
        }

        public class CustomString : ICustomClonable<CustomString>
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


        public static void Scambia<TEntity>(ref TEntity a, ref TEntity b)
        {
            //TEntity temp = a;
            //a = b;
            //b = temp;
            (b, a) = (a, b);
            Console.WriteLine($"Scambio: {a} <-> {b}");
        }

        public class MyList<TEntity> where TEntity : ICustomClonable<TEntity> // where UEntity : TEntity vincolo di ereditarietà
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

                for (int i = 0; i < _capacita; i++)
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


    }
}
