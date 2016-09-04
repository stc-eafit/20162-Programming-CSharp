using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hilos1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task uno= Task.Run(() => { Loop1(); });
            Task.WaitAny(uno);
            Task.Run(() => { Loop2(); });
            Console.WriteLine("Despues de loop");
            Console.ReadKey();
        }

        static void Loop1()
        {
            for(int i = 0; i < 3000; i++)
            {
                if(i % 2 == 0)
                Console.WriteLine(i);
            }
        }
        static void Loop2()
        {
            for (int i = 0; i < 3000; i++)
            {
                if (i % 2 == 1)
                    Console.WriteLine(i);
            }
        }
    }
}
