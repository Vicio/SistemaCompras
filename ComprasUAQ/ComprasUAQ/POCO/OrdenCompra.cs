using System;

namespace ComprasUAQ.POCO
{
    /// <summary>
    /// Clase de la orden de compra
    /// </summary>
    public class OrdenCompra
    {
        /// <summary>
        /// Declaracion de Atributos
        /// </summary>
        
        private long id;
        private Requisicion requisicion;
        private int? clave;
        private char tipoDeOrden;
        private decimal monto;
        private DateTime fechaOrdenCompra;
        private DateTime? fechaLimiteElaboracion;
        private DateTime? fechaEnviadaFirma;
        private DateTime? fechaDevueltaDeFirma;
        
        
        
        /// <summary>
        /// Constructor vacio: id, clave, monto = 0; requisicion = new, fechas = new
        /// </summary>
        public OrdenCompra()
        {
            id = 0;
            requisicion = new Requisicion();
            clave = 0;
            tipoDeOrden = '\0';
            monto = 0;
            fechaOrdenCompra = new DateTime();
            fechaLimiteElaboracion = new DateTime();
            fechaEnviadaFirma = new DateTime();
            fechaDevueltaDeFirma = new DateTime();
        }

        /// <summary>
        /// Constructor de la orden de compra con todos los parámetros
        /// </summary>
        /// <param name="id">El id de la orden de compra</param>
        /// <param name="requisicion">La requisicion a la que pertenece la orden de compra</param>
        /// <param name="clave">La clave de la orden de compra</param>
        /// <param name="tipoDeOrden">El tipo de orden de compra</param>
        /// <param name="monto">El monto de la orden de compra</param>
        /// <param name="fechaOrdenCompra">La fecha de la orden de compra</param>
        /// <param name="fechaLimiteElaboracion">La fecha limite para elaboracion de la orden cde compra</param>
        /// <param name="fechaEnviadaFirma">La fecha en que la orden de compra fue enviada a firma</param>
        /// <param name="fechaDevueltaDeFirma">La fecha en que la orden de compra fue devuelta de firma</param>
        public OrdenCompra(long id, Requisicion requisicion, int? clave,
            char tipoDeOrden, decimal monto, DateTime fechaOrdenCompra,
            DateTime? fechaLimiteElaboracion, DateTime? fechaEnviadaFirma,
            DateTime? fechaDevueltaDeFirma) 
        {
            this.id = id;
            this.requisicion = requisicion;
            this.clave = clave;
            this.tipoDeOrden = tipoDeOrden;
            this.monto = monto;
            this.fechaOrdenCompra = fechaOrdenCompra;
            this.fechaLimiteElaboracion = fechaLimiteElaboracion;
            this.fechaEnviadaFirma = fechaEnviadaFirma;
            this.fechaDevueltaDeFirma = fechaDevueltaDeFirma;
        }

        /// <summary>
        /// Obtencion del id de la orden de compra
        /// </summary>
        /// <returns>El id de la orden de compra</returns>
        public long GetId()
        {
            return id;
        }

        /// <summary>
        /// Inserta el id de la orden de la compra
        /// </summary>
        /// <param name="id">El id de la orden de compra</param>
        public void SetId(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Obtencion de la requisicion
        /// </summary>
        /// <returns>La requisicion que corresponde a la orden de compra</returns>
        public Requisicion GetRequisicion()
        {
            return requisicion;
        }

        /// <summary>
        /// Inserta un objeto requisicion al que poertenece la orden de compra
        /// </summary>
        /// <param name="requisicion">La requisicion que corresponde a la orden de compra</param>
        public void SetRequisicion(Requisicion requisicion)
        {
            this.requisicion = requisicion;
        }

        /// <summary>
        /// Obtencion de la clave de compra
        /// </summary>
        /// <returns>La clave de la orden de compra</returns>
        public int? GetClave()
        {
            return clave;
        }

        /// <summary>
        /// Inserta la clave de la compra
        /// </summary>
        /// <param name="clave">La clave de la orden de compra</param>
        public void SetClave(int clave)
        {
            this.clave = clave;
        }

        /// <summary>
        /// Obtencion del tipo de la orden de compra
        /// </summary>
        /// <returns>El tipo de orden de compra</returns>
        public char GetTipoDeOrden()
        {
            return tipoDeOrden;
        }

        /// <summary>
        /// Inserta el tipo de la orden de compra
        /// </summary>
        /// <param name="tipoDeOrden">El tipo de orden de compra</param>
        public void SetTipoDeOrden(char tipoDeOrden)
        {
            this.tipoDeOrden = tipoDeOrden;
        }

        /// <summary>
        /// Obtencion del monto de la compra
        /// </summary>
        /// <returns>El monto de la orden de compra</returns>
        public decimal GetMonto()
        {
            return monto;
        }

        /// <summary>
        /// Inserta el monto de la orden de compra
        /// </summary>
        /// <param name="monto">El monto de la orden de compra</param>
        public void SetMonto(decimal monto)
        {
            this.monto = monto;
        }

        /// <summary>
        /// Obtencion de la fecha de la orden de compra
        /// </summary>
        /// <returns>La fecha de generacion del registro de orden de compra</returns>
        public DateTime GetFechaOrdenCompra()
        {
            return fechaOrdenCompra;
        }

        /// <summary>
        /// Inserta la fecha de la orden de la compra
        /// </summary>
        /// <param name="fechaOrdenCompra">La fecha de generacion del registro de orden de compra</param>
        public void SetFechaOrdenCompra(DateTime fechaOrdenCompra)
        {
            this.fechaOrdenCompra = fechaOrdenCompra;
        }

        /// <summary>
        /// Obtencion de la fecha limite de la elaboracion de la orden de compra 
        /// </summary>
        /// <returns>La fecha limite de elabiracion de la orden de compra</returns>
        public DateTime? GetFechaLimiteElaboracion()
        {
            return fechaLimiteElaboracion;
        }

        /// <summary>
        /// Inserta la fecha limite de elaboracion de la orden de compra
        /// </summary>
        /// <param name="fechaLimiteElaboracion">La fecha limite de elabiracion de la orden de compra</param>
        public void SetFechaLimiteElaboracion(DateTime fechaLimiteElaboracion)
        {
            this.fechaLimiteElaboracion = fechaLimiteElaboracion;
        }

        /// <summary>
        /// Obtencion de la fecha en que la orden de compra es enviada a firma
        /// </summary>
        /// <returns>La fecha en que la orden fue enviada a firma</returns>
        public DateTime? GetFechaEnviadaFirma()
        {
            return fechaEnviadaFirma;
        }

        /// <summary>
        /// Inserta la fecha en que la orden de compra es enviada a firma
        /// </summary>
        /// <param name="fechaEnviadaFirma">La fecha en que la orden fue enviada a firma</param>
        public void SetFechaEnviadaFirma(DateTime fechaEnviadaFirma)
        {
            this.fechaEnviadaFirma = fechaEnviadaFirma;
        }

        /// <summary>
        /// Obtencion de la fecha de regreso de la obtencion de la firma de la orden de compra
        /// </summary>
        /// <returns>La fecha en que la orden fue devuelta de firma</returns>
        public DateTime? GetFechaDevueltaDeFirma()
        {
            return fechaDevueltaDeFirma;
        }

        /// <summary>
        /// Inserta la fecha de vuelta de la firma de la orden de compra
        /// </summary>
        /// <param name="fechaDevueltaDeFirma">La fecha en que la orden fue devuelta de firma</param>
        public void SetFechaDevueltaDeFirma(DateTime fechaDevueltaDeFirma)
        {
            this.fechaDevueltaDeFirma = fechaDevueltaDeFirma;            
        }
    }
}
