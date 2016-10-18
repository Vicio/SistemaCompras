namespace ComprasUAQ.POCO
{
    /// <summary>
    /// Clase Comprador
    /// </summary>
    public class Comprador : Persona
    {
        /// <summary>
        /// Constructor vacío: id = 0, nombre = "", apellidos = ""
        /// </summary>
        public Comprador()
        {
            SetId(0);
            SetNombre("");
            SetApellidoMaterno("");
            SetApellidoPaterno("");
        }
        /// <summary>
        /// Constructor de comprador con todos los parámetros
        /// </summary>
        /// <param name="id">El id del comprador</param>
        /// <param name="nombre">El nombre del comprador</param>
        /// <param name="apellidoPaterno">El apellido paterno del comprador</param>
        /// <param name="apellidoMaterno">El apellido materno del comprador</param>
        public Comprador(int id,string nombre, string apellidoPaterno, string apellidoMaterno)
            : base(id, nombre, apellidoPaterno, apellidoMaterno)
        {
        }
    }
}
