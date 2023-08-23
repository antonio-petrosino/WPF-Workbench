using ConsoleApplicationTest;
using System;

using static ConsoleApplicationTest.CustomFunction;

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

            //String TypeOfMain = "Test1";
            //String TypeOfMain = "Thread";
            //String TypeOfMain = "Task";
            String TypeOfMain = "AsyncAwait";

            switch (TypeOfMain)
            {
                case "Test1":
                    TestUno();
                    break;
                case "Thread":
                    ThreadUno();
                    break;
                case "Task":
                    TaskUno();
                    break;
                case "AsyncAwait":
                    SyncORAsync();
                    break;
                default:
                    Console.WriteLine("Nessun caso");
                    break;
            }

            //if (TypeOfMain == "Test1")
            //{
            //    TestUno();
            //}
            //else if (TypeOfMain == "Thread")
            //{

            //   ThreadUno();

            //}else if (TypeOfMain == "Task") {
            //    TaskUno();               

            //}else if(TypeOfMain == "AsyncAwait")
            //{
            //    SyncORAsync();
            //}


        }



        static void TestUno()
        {
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

        static void ThreadUno()
        {
            //StreamWriter streamWriter = new StreamWriter("log.txt");
            //Thread t1 = new Thread(() => thread1(streamWriter));
            //Thread t2 = new Thread(() => thread2(streamWriter));
            //Thread t3 = new Thread(() => thread3(streamWriter));

            StreamWriter? streamWriter = null;
            Thread t1 = new Thread(() => thread1(streamWriter));
            Thread t2 = new Thread(() => thread2(streamWriter));
            Thread t3 = new Thread(() => thread3(streamWriter));


            t1.Start();
            t2.Start();
            t3.Start();


            t1.Join();
            t2.Join();
            t3.Join();

            streamWriter?.Close();


            Thread t0 = new Thread(thread_with_param);
            Thread t00 = new Thread(thread_with_param);
            Thread t000 = new Thread(thread_with_param);
            t0.Start(new String("Chao!!!"));
            t00.Start(2);
            t000.Start("Chao###");

            t0.Join();
            t00.Join();
            t000.Join();


            // la scrittura su file è sequenziale, thread concorrenti non hanno senso
            // se scrivo su console invece è visibile
        }

        static void TaskUno()
        {
            StreamWriter? streamWriter = null;


            Task t1 = new Task(() => thread1(streamWriter));
            Task t2 = new Task(() => thread2(streamWriter));
            Task t3 = new Task(() => thread3(streamWriter));


            t1.Start();
            t2.Start();
            t3.Start();

            Task.WaitAll(t1, t2, t3);

            Console.WriteLine("Task completati");

            int[] v = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            Task<int> somma = Task<int>.Run(() => TaskSomma(v));
            //Task.WaitAll();
            int[] v2 = new int[] { 1, 2, 3 };
            Task<int> somma2 = Task<int>.Run(() => TaskSomma(v2));
            var aw = somma2.GetAwaiter();

            aw.OnCompleted(() => Console.WriteLine($"Task completato, somma = {aw.GetResult()}"));


            while (true)
            {
                Console.WriteLine($"Stato: {somma.Status}");

                //if(somma.IsCompleted)
                //    break;  
                if (somma.Status == TaskStatus.RanToCompletion)
                {
                    break;
                }
                if (somma.Status == TaskStatus.Faulted)
                {
                    Console.WriteLine($"Task fallito: {somma.Exception}");
                    break;
                }

                Thread.Sleep(300);
            }



            //il write line è bloccante, quindi aspetta che il task sia completato
            Console.WriteLine($"Task completati, somma = {somma.Result}");
        }

        static void SyncORAsync()
        {
            DownloadSync();
            //DownloadAsync();
            string user = "";
            Console.WriteLine("Premi un tasto per uscire");

            user = Console.ReadLine();
        }



    }
}


