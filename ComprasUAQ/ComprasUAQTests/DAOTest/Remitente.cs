using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComprasUAQ.POCO
{
    /// <summary>
    /// Clase Remitente
    /// </summary>
    public class Remitente : Persona
    {
        /// <summary>
        /// Constructor vacío
        /// </summary>
        public Remitente()
        {
        }

        /// <summary>
        /// Constructor con todos los parámetros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellidoPaterno"></param>
        /// <param name="apellidoMaterno"></param>
        public Remitente(int id, string nombre, string apellidoPaterno, string apellidoMaterno) : base(id, nombre, apellidoPaterno, apellidoMaterno)
        {
        }
    }
}
