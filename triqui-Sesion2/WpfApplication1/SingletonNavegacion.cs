using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApplication1
{
    /// <summary>
    /// Una forma de mostrar un patrón muy usado para la navegacion implementando Singleton
    /// </summary>
    class SingletonNavegacion
    {
        private static Inicio _inicio;
        private SingletonNavegacion()
        {

        }
        /// <summary>
        /// Metodo para ir a inicio
        /// </summary>
        /// <returns>una instancia unica de la pagina de inicio</returns>
        public static Page NavegarInicio()
        {
            if (_inicio == null)
            {
                _inicio = new Inicio();
            }
            return _inicio;
        }
    }
}
