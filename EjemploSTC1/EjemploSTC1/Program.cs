using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploSTC1
{
    class Program
    {
        private int _cantidad_estudiantes = 12;

        public int CantidadEstudiantes
        {
            get{ return _cantidad_estudiantes; }
            set{ _cantidad_estudiantes = value; }  
        }
        static void Main(string[] args)
        {
            Program ejemplo = new Program();
            Console.WriteLine(ejemplo.CantidadEstudiantes);
            ejemplo.CantidadEstudiantes = 10;
            Console.WriteLine(ejemplo.CantidadEstudiantes);
            Console.ReadKey();
        }
    }
}
