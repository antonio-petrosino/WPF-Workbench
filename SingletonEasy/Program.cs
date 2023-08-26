using System;
using System.Diagnostics;
using static SingletonEasy.CustomFunctions;

namespace SingletonEasy
{
    delegate void LoggerDelegate(string message);

    class Cliente { int id; }

    class Transazione
    {
        LoggerDelegate? metodoLogger = null;

        Action<String>? metodoAlternativo = null;

        public Transazione(LoggerDelegate metodoLogger, Action<string> metodoAlternativo)
        {
            this.metodoLogger = metodoLogger;
            this.metodoAlternativo = metodoAlternativo;
        }

        public void AddDelegates(LoggerDelegate metodoLogger)
        {
            this.metodoLogger += metodoLogger;
        }

        public void AddAction(Action<String> metodoAlternativo)
        {
            this.metodoAlternativo += metodoAlternativo;
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

            if(metodoAlternativo is not null)
            {
                if (condizione)
                {
                      metodoAlternativo("Alternative method - " + dateTime.ToString()); // qui useremo l'action
                }
            }
        }

        // func elenca parametri + tipo restituito esempio 3 parametri + tipo restituito => Func<param1, param2, param3, tipoRestituito>
        public double Contabilizza(double acconto, Func<double, double> sconto, Predicate<Cliente> HaDirittoSconto)
        {
            // new Cliente deve essere il cliente da analizzare
            return HaDirittoSconto(new Cliente()) ? acconto - sconto(acconto) : acconto;
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

        static double ScontoCliente(double acconto)
        {
            return acconto * 0.1;
        }

        static double ScontoFornitore(double acconto)
        {
            return acconto * 0.2;
        }

        static bool ValutaSeClienteHaDirittoSconto(Cliente cliente)
        {
            return true;
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


            Console.WriteLine("######################################################################");

            Transazione t1 = new Transazione(PrimoTipoDiLog, PrimoTipoDiLog);
            Transazione t2 = new Transazione(SecondoTipoDiLog, PrimoTipoDiLog);
            Transazione t3 = new Transazione(TerzoTipoDiLog, PrimoTipoDiLog);

            t1.Check(DateTime.Now);
            Thread.Sleep(1000);
            t2.Check(DateTime.Now);
            Thread.Sleep(1500);
            t3.Check(DateTime.Now);
            Thread.Sleep(2000);

            Console.WriteLine("Aggiungo un altro metodo di log al delegate");
            t1.AddDelegates(SecondoTipoDiLog);
            t1.Check(DateTime.Now);

            Console.WriteLine("Sconto Cliente: "+t1.Contabilizza(100, ScontoCliente, ValutaSeClienteHaDirittoSconto));

            Console.WriteLine("Sconto Fornitore: "+ t1.Contabilizza(100, ScontoFornitore, ValutaSeClienteHaDirittoSconto));


            

            stopwatch.Stop();   
            Console.WriteLine($"Tempo di esecuzione: {stopwatch.ElapsedMilliseconds} ms");

        }
    }

}