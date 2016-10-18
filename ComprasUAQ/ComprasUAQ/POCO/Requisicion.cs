using System;

namespace ComprasUAQ.POCO
{
    /// <summary>
    /// Inicia clase Requisicion
    /// </summary>
    public class Requisicion
    {
        /// <summary>
        /// Se declaran los atributos
        /// </summary>
        private long id;
        private CentroGasto centroGasto;
        private Comprador comprador;
        private Proveedor proveedor;
        private string clave;
        private DateTime fechaElaboracion;
        private DateTime? fechaEntrega;
        private char? estado;
        private string cartaCompromiso;
        private DateTime? fechaPromesaEntrega;
        private string observaciones;

        /// <summary>
        /// Constructor vacio: id = 0; centroGasto, comprador, proveedor = new; clave, carta, observaciones = ""; fechas = new Date, estado = null
        /// </summary>
        public Requisicion ()
        {
            id = 0;
            centroGasto = new CentroGasto();
            comprador = new Comprador();
            proveedor = new Proveedor();
            clave = "";
            fechaElaboracion = new DateTime();
            fechaEntrega = new DateTime();
            estado = '\0';
            cartaCompromiso = "";
            fechaPromesaEntrega = new DateTime();
            observaciones = "";
        }

        /// <summary>
        /// Constructor de la requisicion con todos los parámetros
        /// </summary>
        /// <param name="id">El id de la requisicion</param>
        /// <param name="centroGasto">El centro de gasto al que pertenece la requisicion</param>
        /// <param name="comprador">El comprador al que se le asignó la requisicion</param>
        /// <param name="proveedor">El proveedor del centro de gasto</param>
        /// <param name="clave">La clave de la requisicion</param>
        /// <param name="fechaElaboracion">La fecha de elaboracion de la requisicion</param>
        /// <param name="fechaEntrega">La fecha de entrega</param>
        /// <param name="estado">El estado de la requisicion</param>
        /// <param name="cartaCompromiso">La ubicacion(directorio) donde se va a guardar la carta compromiso</param>
        /// <param name="fechaPromesaEntrega">La fecha de promesa de entrega del producto</param>
        /// <param name="observaciones">Observaciones concernientes a la requisicion</param>
        public Requisicion(long id, CentroGasto centroGasto, Comprador comprador,
            Proveedor proveedor, string clave, DateTime fechaElaboracion,
            DateTime? fechaEntrega, char? estado,  string cartaCompromiso,
            DateTime? fechaPromesaEntrega, string observaciones)
        {
            this.id = id;
            this.centroGasto = centroGasto;
            this.comprador = comprador;
            this.proveedor = proveedor;
            this.clave = clave;
            this.fechaElaboracion = fechaElaboracion;
            this.fechaEntrega = fechaEntrega;
            this.estado = estado;
            this.cartaCompromiso = cartaCompromiso;
            this.fechaPromesaEntrega = fechaPromesaEntrega;
            this.observaciones = observaciones;
        }

        /// <summary>
        /// Obtencion del id de Requisicion
        /// </summary>
        /// <returns>El id de la requisicion</returns>
        public long GetId()
        {
            return id;
        }

        /// <summary>
        /// Insercion de idRequisicion
        /// </summary>
        /// <param name="id">El id de la requisicion</param>
        public void SetId(long id)
        {
            this.id = id;
        }
         /// <summary>
         /// Obtencion de centroGasto
         /// </summary>
         /// <returns>El centro de gasto que solicito la requisicion</returns>
        public CentroGasto GetCentroGasto()
        {
            return centroGasto;
        }

        /// <summary>
        /// Insercion de centroGasto
        /// </summary>
        /// <param name="centroGasto">El centro de gasto que solicito la requisicion</param>
        public void SetCentroGasto(CentroGasto centroGasto)
        {
            this.centroGasto = centroGasto;
        }

        /// <summary>
        /// Obtencion el comprador
        /// </summary>
        /// <returns>El comprador asignado a la requisicion</returns>
        public Comprador GetComprador()
        {
            return comprador;
        }

        /// <summary>
        /// Insercion el IdComprador
        /// </summary>
        /// <param name="comprador">El comprador asignado a la requisicion</param>
        public void SetComprador(Comprador comprador)
        {
            this.comprador = comprador;
        }

        /// <summary>
        /// Obtencion del idProveedor
        /// </summary>
        /// <returns>El proveedor del centro de gasto</returns>
        public Proveedor GetProveedor()
        {
            return proveedor;
        }

        /// <summary>
        /// Insercion de Proveedor
        /// </summary>
        /// <param name="proveedor">El proveedor del centro de gasto</param>
        public void SetProveedor(Proveedor proveedor)
        {
            this.proveedor = proveedor;
        }

        /// <summary>
        /// Obtencion de la clave de Requisicion
        /// </summary>
        /// <returns>La clave de la requisicion</returns>
        public string GetClave()
        {
            return clave;
        }

        /// <summary>
        /// Insercion de claveRequisicion
        /// </summary>
        /// <param name="clave">La clave de la requisicion</param>
        public void SetClave(string clave)
        {
            this.clave = clave;
        }

        /// <summary>
        /// Obtencion de la fecha de Elavoracion de la Requisicion
        /// </summary>
        /// <returns>La fecha de elaboracion de la requisicion</returns>
        public DateTime GetFechaElaboracion()
        {
            return fechaElaboracion;
        }

        /// <summary>
        /// Insercion de fechaElavoracionRequisicion
        /// </summary>
        /// <param name="fechaElaboracion">La fecha de elaboracion de la requisicion</param>
        public void SetFechaElaboracion(DateTime fechaElaboracion)
        {
            this.fechaElaboracion = fechaElaboracion;
        }

        /// <summary>
        /// Obtencion de la fecha de Entrega de la Requisicion
        /// </summary>
        /// <returns>La fecha de entrega</returns>
        public DateTime? GetFechaEntrega()
        {
            return fechaEntrega;
        }

        /// <summary>
        /// Insercion de fechaEntregaRequisicion
        /// </summary>
        /// <param name="fechaEntrega">La fecha de entrega</param>
        public void SetFechaEntrega(DateTime fechaEntrega)
        {
            this.fechaEntrega = fechaEntrega;
        }

        /// <summary>
        /// Obtencion del estado de la Requisicion
        /// </summary>
        /// <returns>El estado de la requisicion</returns>
        public char? GetEstado()
        {
            return estado;
        }

        /// <summary>
        /// Insercion de estadoRequisicion
        /// </summary>
        /// <param name="estado">El estado de la requisicion</param>
        public void SetEstado(char? estado)
        {
            this.estado = estado;
        }

        /// <summary>
        /// Obtencion de cartaCompromisoRequisicion
        /// </summary>
        /// <returns>El directorio donde se encuentra la carta compromiso</returns>
        public string GetCartaCompromiso()
        {
            return cartaCompromiso;
        }

        /// <summary>
        /// Insercion de cartaCompromisoRequisicion
        /// </summary>
        /// <param name="cartaCompromiso">El directorio donde se encuentra la carta compromiso</param>
        public void SetCartaCompromiso(string cartaCompromiso)
        {
            this.cartaCompromiso = cartaCompromiso;
        }

        /// <summary>
        /// Obtencion de la fecha de Promesa de Entrega
        /// </summary>
        /// <returns>La fecha de promesa de entrega del producto</returns>
        public DateTime? GetFechaPromesaEntrega()
        {
            return fechaPromesaEntrega;
        }

        /// <summary>
        /// Insercion de fechaPromesoEntrega
        /// </summary>
        /// <param name="fechaPromesaEntrega">La fecha de promesa de entrega del producto</param>
        public void SetFechaPromesaEntrega(DateTime fechaPromesaEntrega)
        {
            this.fechaPromesaEntrega = fechaPromesaEntrega;
        }

        /// <summary>
        /// Obtencion de las observaciones de la Requisicion
        /// </summary>
        /// <returns>Las observaciones correspondientes a la requisicion</returns>
        public string GetObservaciones()
        {
            return observaciones;
        }

        /// <summary>
        /// Insercion de observacionRequisicion
        /// </summary>
        /// <param name="observaciones">Las observaciones correspondientes a la requisicion</param>
        public void SetObservaciones(string observaciones)
        {
            this.observaciones = observaciones;
        }
    }
    ///Termina clase Requisicion
}
