namespace ComprasUAQ.POCO
{
    /// <summary>
    /// empieza clase organizacion
    /// </summary>
    public abstract class Organizacion
    {
        /// <summary>
        /// Se declaran atributos
        /// </summary>
        private int id;
        private string nombre;

        /// <summary>
        /// Constructor vacio: id = 0, nombre = ""
        /// </summary>
        public Organizacion()
        {
            id = 0;
            nombre = "";
        }

        /// <summary>
        /// Constructor de la clase abstracta organizacion con todos los parametros
        /// </summary>
        /// <param name="id">El id de la organizacion</param>
        /// <param name="nombre">El nombre de la organizacion</param>
        public Organizacion(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;

        }
        /// <summary>
        /// obtencion del id
        /// </summary>
        /// <returns>El id de la organizacion</returns>
        public int GetId()
        {
            return id;
        }

        /// <summary>
        /// Insercion del id
        /// </summary>
        /// <param name="id">El id de la organizacion</param>
        public void SetId(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// obtencion del nombre
        /// </summary>
        /// <returns>El nombre de la organizacion</returns>
        public string GetNombre()
        {
            return nombre;
        }

        /// <summary>
        /// Insercion del nombre
        /// </summary>
        /// <param name="nombre">El nombre de la organizacion</param>
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
    }
    ///Termima clase organizacion
}
