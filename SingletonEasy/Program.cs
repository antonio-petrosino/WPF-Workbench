using System;
using System.Diagnostics;
using static SingletonEasy.CustomFunctions;

namespace SingletonEasy
{
    delegate void LoggerDelegate(string message);

    class Transazione
    {
        LoggerDelegate? metodoLogger = null;

        public Transazione(LoggerDelegate metodoLogger)
        {
            this.metodoLogger = metodoLogger;
        }

        public void AddDelegates(LoggerDelegate metodoLogger)
        {
            this.metodoLogger += metodoLogger;
        }

        public void Check(DateTime dateTime)
        {
            bool condizione = false;

            condizione = true;

            if (metodoLogger is not null)
            {
                if (condizione)
                {
                    metodoLogger(dateTime.ToString()); // qui useremo il delegate
                }
            }
            else
            {
                Console.WriteLine("metodoLogger è null");
            }
        }
    }



    class Program
    {

        static void PrimoTipoDiLog(string message)
        {
            Console.WriteLine($"PrimoTipoDiLog: {message}");
        }

        static void SecondoTipoDiLog(string message)
        {
            Console.WriteLine($"SecondoTipoDiLog: {message}");
        }

        static void TerzoTipoDiLog(string message)
        {
            Console.WriteLine($"TerzoTipoDiLog: {message}");
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



            Transazione t1 = new Transazione(PrimoTipoDiLog);
            Transazione t2 = new Transazione(SecondoTipoDiLog);
            Transazione t3 = new Transazione(TerzoTipoDiLog);

            t1.Check(DateTime.Now);
            Thread.Sleep(1000);
            t2.Check(DateTime.Now);
            Thread.Sleep(1500);
            t3.Check(DateTime.Now);
            Thread.Sleep(2000);

            Console.WriteLine("Aggiungo un altro metodo di log al delegate");
            t1.AddDelegates(SecondoTipoDiLog);
            t1.Check(DateTime.Now);
            

            

            stopwatch.Stop();   
            Console.WriteLine($"Tempo di esecuzione: {stopwatch.ElapsedMilliseconds} ms");

        }
    }

}