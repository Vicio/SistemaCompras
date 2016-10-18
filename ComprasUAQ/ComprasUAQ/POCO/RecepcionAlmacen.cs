using System;

namespace ComprasUAQ.POCO
{
    /// <summary>
    /// Se inicia la clase RecepcionAlmacen
    /// </summary>
    public class RecepcionAlmacen
    {
        /// <summary>
        /// Se declaran los atributos: clave, fechaEntrega, fechaRecepcion,
        /// montoRecepcion, numeroResguardo.
        /// </summary>
        private long id;
        private Requisicion requisicion;
        private Remitente remitente;
        private int clave;
        private DateTime fechaRecepcion;
        private decimal? monto;
        private DateTime? fechaEntregaDeAlmacen;
        private string numeroResguardo;

        /// <summary>
        /// Constructor vacío: id, clave, monto = 0; requisicion, remitente = new; fechas = new DateTime
        /// </summary>
        public RecepcionAlmacen()
        {
            id = 0;
            requisicion = new Requisicion();
            remitente = new Remitente();
            clave = 0;
            fechaEntregaDeAlmacen = new DateTime();
            fechaRecepcion = new DateTime();
            monto = 0;
            numeroResguardo = "";
        }

        /// <summary>
        /// Constructor de la recepcion de almacen con todos los parametros
        /// </summary>
        /// <param name="id">El id de la recepcion de almacen</param>
        /// <param name="requisicion">La requisicion a la que pertenece la recepcion de almacen</param>
        /// <param name="remitente">El remitente encargado de la recepcion</param>
        /// <param name="clave">La clave de la recepcion de almacen</param>
        /// <param name="fechaEntregaDeAlmacen">La fecha de entrega al centro de gasto desde el almacen</param>
        /// <param name="fechaRecepcion">La fecha de recepcion</param>
        /// <param name="monto">El monto de la recepcion</param>
        /// <param name="numeroResguardo">El numero de resguardo de la recepcion</param>
        public RecepcionAlmacen(long id, Requisicion requisicion, Remitente remitente,
            int clave, DateTime? fechaEntregaDeAlmacen, DateTime fechaRecepcion, 
            decimal? monto, string numeroResguardo)
        {
            this.id = id;
            this.requisicion = requisicion;
            this.remitente = remitente;
            this.clave = clave;
            this.fechaRecepcion = fechaRecepcion;
            this.monto = monto;
            this.fechaEntregaDeAlmacen = fechaEntregaDeAlmacen;
            this.numeroResguardo = numeroResguardo;
        }

        /// <summary>
        /// Obtencion del id
        /// </summary>
        /// <returns>El id de la recepcion de almacen</returns>
        public long GetId()
        {
            return id;
        }

        /// Insercion del id
        /// <param name="id">El id de la recepcion de almacen</param>
        public void SetId(long id)
        {
            this.id = id;
        }

        /// <summary>
        /// Obtencion de la reqisicion
        /// </summary>
        /// <returns>La requisicion que corresponde a la recepcion de almacen</returns>
        public Requisicion GetRequisicion()
        {
            return requisicion;
        }

        /// <summary>
        /// Insercion de la requisicion
        /// </summary>
        /// <param name="">La requisicion que corresponde a la recepcion de almacen</param>
        public void SetRequisicion(Requisicion requisicion)
        {
            this.requisicion = requisicion;
        }

        /// <summary>
        /// Obtencion del Remitente
        /// </summary>
        /// <returns>El remitente asignado a la recepcion en almacen</returns>
        public Remitente GetRemitente()
        {
            return remitente;
        }

        /// <summary>
        /// Inserccion del Remitente
        /// </summary>
        /// <param name="remitente">El remitente asignado a la recepcion en almacen</param>
        public void SetRemitente(Remitente remitente)
        {
            this.remitente = remitente;
        }

        /// <summary>
        /// Obtencion de la clave
        /// </summary>
        /// <returns>La clave de la recepcion</returns>
        public int GetClave()
        {
            return clave;
        }

        ///Insercion de la clave
        /// <param name="clave">La clave de la recepcion</param>
        public void SetClave(int clave)
        {
            this.clave = clave;
        }

        /// <summary>
        /// Obtencion de la fecha de Recepcion
        /// </summary>
        /// <returns>La fecha de recepcion al almacen</returns>
        public DateTime GetFechaRecepcion()
        {
            return fechaRecepcion;
        }

        /// Insercion de la fecha de Recepcion
        /// <param name="fechaRecepcion">La fecha de recepcion al almacen</param>
        public void SetFechaRecepcion(DateTime fechaRecepcion)
        {
            this.fechaRecepcion = fechaRecepcion;
        }

        /// <summary>
        /// Obtencion del monto de Recepcion
        /// </summary>
        /// <returns>El monto del producto recibido en almacen</returns>
        public decimal? GetMonto()
        {
            return monto;
        }

        /// Insercion del monto de Recepcion
        /// <param name="monto">El monto del producto recibido en almacen</param>
        public void SetMonto(decimal? monto)
        {
            this.monto = monto;
        }

        /// <summary>
        /// Obtencion de la fecha de Entrega
        /// </summary>
        /// <returns>La fecha de entrega al centro de gasto</returns>
        public DateTime? GetFechaEntregaDeAlmacen()
        {
            return fechaEntregaDeAlmacen;
        }

        /// Insercion de la fecha de Entraga
        /// <param name="fechaEntrega">La fecha de entrega al centro de gasto</param>
        public void SetFechaEntregaDeAlmacen(DateTime? fechaEntregaDeAlmacen)
        {
            this.fechaEntregaDeAlmacen = fechaEntregaDeAlmacen;
        }

        /// <summary>
        /// Obtencion del numero de Resguardo
        /// </summary>
        /// <returns>El numero de resguardo de almacen</returns>
        public string GetNumeroResguardo()
        {
            return numeroResguardo;
        }

        /// Insercion del numero de Resguardo
        /// <param name="numeroResguardo">El numero de resguardo de almacen</param>
        public void SetNumeroResguardo(string numeroResguardo)
        {
            this.numeroResguardo = numeroResguardo;
        }
     }///Termina clase RecepcionAlmacen
}