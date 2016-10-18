namespace ComprasUAQ.POCO
{
    /// <summary>
    /// Inicia clase Proveedor
    /// </summary>
    public class Proveedor : Organizacion
    {
        /// <summary>
        /// Se declaran atributos
        /// </summary>
        private bool personaMoral;

        /// <summary>
        /// Constructor vacío: id = 0, nombre = "", persona moral = false
        /// </summary>
        public Proveedor()
        {
            SetId(0);
            SetNombre("");
            personaMoral = false;
        }
        
        /// <summary>
        /// Constructor del proveedor con todos los parametros
        /// </summary>
        /// <param name="id">El id del proveedor</param>
        /// <param name="nombre">El nombre del proveedor</param>
        /// <param name="personaMoral">El valor que define si es persona moral o fisica</param>
        public Proveedor(int id, string nombre, bool personaMoral)
            : base(id, nombre)
        {
            this.personaMoral = personaMoral;
        }

        /// <summary>
        /// Obtencion de personaMoral
        /// </summary>
        /// <returns>Verdadero si es persona moral, falso si es persona fisica</returns>
        public bool EsPersonaMoral()
        {
            return personaMoral;
        }

        /// <summary>
        /// Insercion de personaMoral
        /// </summary>
        /// <param name="personaMoral">Verdadero si es persona moral, falso si es persona fisica</param>
        public void SetPersonaMoral(bool personaMoral)
        {
            this.personaMoral = personaMoral;
        }
    }
}
