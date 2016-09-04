using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task tarea1 = Task.Run(()=> { EjemploAsincronico(); });
            Console.WriteLine("Tarea2");
            Task tarea2 = Task.Run(() => { EjemploConImpares(); });
            Task.WaitAll(tarea1, tarea2);
            Console.ReadKey();
        }

        static void EjemploAsincronico()
        {
            for (int i = 0; i < 100;i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void EjemploConImpares()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
