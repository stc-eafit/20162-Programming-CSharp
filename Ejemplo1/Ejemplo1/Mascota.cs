using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo1
{
    class Mascota
    {
        private int _edad;
        private string _nombre;
        private Persona _amigo;

        public string Nombre
        {
            get { return _nombre; }
            set { this._nombre = value; }
        }

        public int GetEdad()
        {
            return this._edad;
        }
    }
}
