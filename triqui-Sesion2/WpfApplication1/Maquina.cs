using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    /// <summary>
    /// La maquina tiene las operaciones de un jugador pero se agrega el metodo para hacer su jugada
    /// </summary>
    class Maquina : Jugador
    {
        /// <summary>
        ///  Constructor indicando la figura y llamando al constructor del padre
        /// </summary>
        /// <param name="figura">Figura a usar por la maquina</param>
        public Maquina(Figuras figura) : base(figura)
        {
            this.Nombre = "La Maquina";
        }
        /// <summary>
        /// Metodo para que la maquina escoja aleatoriamente una casilla para jugar.
        /// Como reto: Mejorar la jugada de la maquina
        /// </summary>
        /// <param name="arregloCasillas"> referencia al arreglo que contiene</param>
        /// <param name="jugadasHechas"> referencia a l cantidad de jugadas hechas, no conviene paso por valor.
        /// Es referencia para cambiar el campo</param>
        /// <param name="tablero">referencia al tablero de juego</param>
        /// <returns>string jugada de la maquina. Ex: c5</returns>
        public string HacerJugada(ref int[] arregloCasillas, ref int jugadasHechas, ref int[] tablero)
        {
            Random casillaAleatoria = new Random();
            int numeroAl = casillaAleatoria.Next(0, 9);
            while (arregloCasillas[numeroAl] != 2)
            {
                numeroAl = casillaAleatoria.Next(0, 9);
            }
            tablero[numeroAl] = (int)this.Signo;
            jugadasHechas++;
            return "c"+numeroAl;
        }
    }
}
