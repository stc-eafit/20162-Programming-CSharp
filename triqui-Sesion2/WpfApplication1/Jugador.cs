using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    /// <summary>
    /// Clase que representa a un jugador dentro del juego
    /// </summary>
    class Jugador 
    {
        public string Nombre { get; set; }
        public int Puntuacion { get; set; }
        public string correo { get; set; }
        public Figuras Signo { get; set; }
        public Jugador(Figuras signo)
        {
            Signo = signo;
        }
        public void AumentarPuntuacion()
        {
            Puntuacion = Puntuacion + 1;
        }
        public override string ToString()
        {
            return $"{Nombre}, puntuación: {Puntuacion}";
        }
    }
}

