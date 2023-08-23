using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest
{
    internal class CustomFunction
    {


        public static int TaskSomma(int[] v)
        {
            int somma = 0;
            foreach (int i in v)
            {
                somma += i;
                Thread.Sleep(1000);
            }
            return somma;
        }

        public static void thread_with_param(Object obj)
        {
            if (obj.GetType() != typeof(string))
            {
                Console.WriteLine($"Thread with not string param.");
            }
            else
                Console.WriteLine($"Thread with param: {obj}");
        }


        public static void thread1(StreamWriter writeHere)
        {
            if (writeHere == null)
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write("*");
                }
            }
            else
            {
                for (int i = 0; i < 1000; i++)
                {
                    writeHere.WriteLine("*");
                }
            }
        }

        public static void thread2(StreamWriter writeHere)
        {
            if (writeHere == null)
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write("#");
                }
            }
            else
            {
                for (int i = 0; i < 1000; i++)
                {
                    writeHere.WriteLine("#");
                }
            }
        }

        public static void thread3(StreamWriter writeHere)
        {
            if (writeHere == null)
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write("?");
                }
            }
            else
            {
                for (int i = 0; i < 1000; i++)
                {
                    writeHere.WriteLine("?");
                }
            }
        }

        public static Task Download(string url)
        {
            return Task.Run(() => {
                double x = 0;
                for (int i = 0; i <= 100000000; i++) x = Math.Atanh(x / 123); //simula un download
                if ((new Random()).Next() % 3 == 0) while (true) ;
                Console.WriteLine($"Download da {url} completato");
            });

        }

        public static void DownloadSync()
        {
            Task.Run(() => Download("http://www.google.com"));
            Task.Run(() => Download("http://www.microsoft.com"));
            Task.Run(() => Download("http://www.amazon.com"));
            Task.Run(() => Download("http://www.apple.com"));
            Task.Run(() => Download("http://www.facebook.com"));
            Task.Run(() => Download("http://www.twitter.com"));
            Task.Run(() => Download("http://www.stackoverflow.com"));

            Console.WriteLine("DownloadAvviati");
        }

        public static async void DownloadAsync()
        {
            await Task.Run(() => Download("http://www.google.com"));
            await Task.Run(() => Download("http://www.microsoft.com"));
            await Task.Run(() => Download("http://www.amazon.com"));
            await Task.Run(() => Download("http://www.apple.com"));
            await Task.Run(() => Download("http://www.facebook.com"));
            await Task.Run(() => Download("http://www.twitter.com"));
            await Task.Run(() => Download("http://www.stackoverflow.com"));

            Console.WriteLine("DownloadAvviati");
        }

    }

}
