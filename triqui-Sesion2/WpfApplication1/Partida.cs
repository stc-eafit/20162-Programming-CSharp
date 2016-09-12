using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    ///<summary>
    /// Esta clase representa el juego, unifica el comportamiento del juego
    /// independiente  de la GUI
    /// </summary> 
    class Partida
    {

        private Jugador persona;
        public Jugador Persona { get { return persona; } }
        private Maquina oponente;
        public Maquina Oponente { get { return oponente; } }
        public Jugador Ganador { get; set; }
        private int partidasHechas;
        /// <summary>
        /// Propiedad para saber quien va
        /// </summary>
        /// <value>true = persona</value>
        /// <value>false = maquina</value>
        public bool Turno { get; set; }
        private int[] tablero = new int[9];
        /// <summary>
        /// Nos indica si no ha terminado la partida
        /// </summary>
        private bool partidaActiva;
        /// <summary>
        /// Constructor para la partida
        /// </summary>
        /// <param name="jugador">Para permitir libertad de eleccion en la figura</param>
        /// <param name="maquina">Figura para la maquina</param>
        public Partida(Figuras jugador, Figuras maquina)
        {
            this.persona = new Jugador(jugador);
            this.persona.Nombre = "La Persona";
            this.oponente = new Maquina(maquina);
        }
        /// <summary>
        /// Reinicia los valores para volver a jugar sin borrar las puntuaciones
        /// </summary>
        public void Iniciar()
        {
            partidaActiva = true;
            partidasHechas = 0;
            this.Turno = true;
            tablero = new int[9] {2,2,2,2,2,2,2,2,2};
            Ganador = null;
        }
        /// <summary>
        ///  Metodo para hacer la jugada, es quizas el metodo mas importante, desde aqui se indentifica jugada de
        ///  maquina o persona
        /// </summary>
        /// <param name="jugada"> string de la casilla: ex: c1  </param>
        /// <returns>Retorna la casilla donde se hace la jugada. Si no es válida es ""</returns>
        public string HacerJugada(string jugada = "")
        {
            string casillaDondeSejuega = "";
            if(partidasHechas >= 9 || !partidaActiva )
            {
                return "";
            }
            if (Turno)
            {
                //Si es el turno de la persona
                int casilla = (int)Char.GetNumericValue(jugada.ElementAt(1));
                tablero[casilla] = (int)persona.Signo;
                Turno = false;
                casillaDondeSejuega = "c" + casilla;
                partidasHechas++;
            }else
            {
                // Turno de la maquina
                casillaDondeSejuega = oponente.HacerJugada(ref tablero,ref partidasHechas, ref tablero);
                Turno = true;
            }
            // Revisamos si ya se acabo el juego
            ComprobarPartida();
            // Revisamos quien gano
            RevisarGanador();
            // Retornamos la jugada
            return casillaDondeSejuega;
        }
        /// <summary>
        /// Metodo para saber cual figura se dibuja desde la GUI
        /// </summary>
        /// <returns>Figura de la persona que tiene el turno</returns>
        public Figuras FiguraADibujar()
        {
            if (!Turno)
            {
                return persona.Signo;
            }
            else
            {
                return oponente.Signo;
            }
        }
        /// <summary>
        /// Revisar si la partida sigue
        /// </summary>
        private void ComprobarPartida()
        {
            if(partidasHechas >= 9)
            {
                partidaActiva = false;
            }
        }
        /// <summary>
        /// Revisar quien gano teniendo encuenta el tablero
        /// </summary>
        private void RevisarGanador()
        {
            int gana1 = 2;
            for (int i = 0; i < 2;i++)
            {
                if (tablero[0] == tablero[1] && tablero[0] == tablero[2] && tablero[0] == i)
                {
                    gana1 = i;
                }
                if (tablero[3] == tablero[4] && tablero[3] == tablero[5] && tablero[3] == i)
                {
                    gana1 = i;
                }
                if (tablero[6] == tablero[7] && tablero[6] == tablero[8] && tablero[6] == i)
                {
                    gana1 = i;
                }
                if (tablero[0] == tablero[3] && tablero[0] == tablero[6] && tablero[6] == i)
                {
                    gana1 = i;
                }
                if (tablero[1] == tablero[4] && tablero[1] == tablero[7] && tablero[1] == i)
                {
                    gana1 = i;
                }
                if (tablero[2] == tablero[5] && tablero[2] == tablero[8] && tablero[2] == i)
                {
                    gana1 = i;
                }
                if (tablero[0] == tablero[4] && tablero[0] == tablero[8] && tablero[0] == i)
                {
                    gana1 = i;
                }
                if (tablero[2] == tablero[4] && tablero[2] == tablero[6] && tablero[2] == i)
                {
                    gana1 = i;
                }
                
            }
            if ((int)persona.Signo == gana1)
            {
                // Gana la persona
                Ganador = persona;
                persona.Puntuacion++;
                partidaActiva = false;
            }
            else if ((int)oponente.Signo == gana1)
            {
                // Gana la maquina
                Ganador = oponente;
                oponente.Puntuacion++;
                partidaActiva = false;
            }
        }
    }
}
