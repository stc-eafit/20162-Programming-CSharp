using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejemplo1
{
    /** 
     * Ejemplo de lectura de archivo
     * **/
    class Program
    {

        static void Main(string[] args)
        {   
            // Por fallos
            try
            {
                // Liberar apenas termine con using
                using (StreamReader st = new StreamReader(@"C:\Users\Sebastian\OneDrive\Documentos\Microsoft\STC2016\CSharp\Ejemplo1\Ejemplo1\ejemplo.txt"))
                {
                    string line;
                    while ((line = st.ReadLine())!= null)
                    {
                        System.Console.WriteLine(line);
                    }
                }
                Task tarea = Task.Run(()=> {
                    using (StreamReader st = new StreamReader(@"C:\Users\Sebastian\OneDrive\Documentos\Microsoft\STC2016\CSharp\Ejemplo1\Ejemplo1\ejemplo.txt"))
                    {
                        string line;
                        while ((line = st.ReadLine()) != null)
                        {
                            System.Console.WriteLine(line);
                        }
                    }

                });
                Console.WriteLine("Despues de tara");
                Task.WaitAll(tarea);
                Console.WriteLine("Fin tarea");
            }
            catch(Exception ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
