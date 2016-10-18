namespace ComprasUAQ.POCO
{
    /// <summary>
    /// Empieza clase persona
    /// </summary>
    public abstract class Persona
    {

        /// <summary>
        /// Creacion de los atributos
        /// </summary>
        private int id; 
        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;

        /// <summary>
        /// Constructor vacio: id = 0; nombre, apellidos = ""
        /// </summary>
        public Persona()
        {
            id = 0;
            nombre = "";
            apellidoMaterno = "";
            apellidoPaterno = "";
        }

        /// <summary>
        /// Constructor con todos los parámetros
        /// </summary>
        /// <param name="id">El id de la persona</param>
        /// <param name="nombre">El nombre de la persona</param>
        /// <param name="apellidoPaterno">El apellido paterno de la persona</param>
        /// <param name="apellidoMaterno">El apellido materno de la persona</param>
        public Persona(int id, string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
        }

        /// <summary>
        /// Obtencion del id
        /// </summary>
        /// <returns>El id de la persona</returns>
        public int GetId()
        {
            return id;
        }

        /// <summary>
        /// Insercion del id
        /// </summary>
        /// <param name="id">El id de la persona</param>
        public void SetId(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Obtencion del nombre
        /// </summary>
        /// <returns>El nombre de la persona</returns>
        public string GetNombre()
        {
            return nombre;
        }

        /// <summary>
        /// Insercion de nombre
        /// </summary>
        /// <param name="nombre">El nombre de la persona</param>
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Obtencion del apellido paterno
        /// </summary>
        /// <returns>El apellido paterno de la persona</returns>
        public string GetApellidoPaterno()
        {
            return apellidoPaterno;
        }

        /// <summary>
        /// Insercion del apellido paterno
        /// </summary>
        /// <param name="apellidoPaterno">El apellido paterno de la persona</param>
        public void SetApellidoPaterno(string apellidoPaterno)
        {
            this.apellidoPaterno = apellidoPaterno;
        }

        /// <summary>
        /// Obtencion del apellido materno
        /// </summary>
        /// <returns>El apellido materno de la persona</returns>
        public string GetApellidoMaterno()
        {
            return apellidoMaterno;
        }

        /// <summary>
        /// Insercion del apellido materno
        /// </summary>
        /// <param name="apellidoMaterno">El apellido materno de la persona</param>
        public void SetApellidoMaterno(string apellidoMaterno)
        {
            this.apellidoMaterno = apellidoMaterno;
        }
    }// Termina clase persona
}


