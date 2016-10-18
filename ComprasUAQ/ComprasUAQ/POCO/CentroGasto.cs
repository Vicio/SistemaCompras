namespace ComprasUAQ.POCO
{
    /// <summary>
    /// Clase centro de Gasto
    /// </summary>///jujujuj
    ///                 ^
    ///                 |
    ///                 |
    ///Vicio: dat comment lololol
    public class CentroGasto : Organizacion
    {
        /// <summary>
        /// Constructor vacio: id = 0, nombre = ""
        /// </summary>
        public CentroGasto()
        {
            SetId(0);
            SetNombre("");
        }
        /// <summary>
        /// Constructor del centro de gasto con todos los parámetros
        /// </summary>
        /// <param name="id">El id del centro de gasto</param>
        /// <param name="nombre">El nombre del centro de gasto</param>
        public CentroGasto(int id,string nombre)
            : base(id,nombre)
        {
        }
    }
}
