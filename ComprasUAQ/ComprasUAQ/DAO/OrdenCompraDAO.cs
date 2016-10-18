using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComprasUAQ.DataSets;
using ComprasUAQ.POCO;

namespace ComprasUAQ.DAO
{
    public class OrdenCompraDAO
    {
        /// <summary>
        /// Encuentra la orden de compra por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un objeto ordenCompra</returns>
        public OrdenCompra FindById(int id)
        {
            DAODataContext contexto = new DAODataContext();
            RequisicionDAO requisicionDAO = new RequisicionDAO();
            using (contexto)
            {
                var resultado =
                    (
                        
                        from ordenCompra in contexto.ordenes_compras
                        where ordenCompra.id_orden_compra==id
                        select new OrdenCompra
                        (
                            ordenCompra.id_orden_compra,
                            requisicionDAO.FindById(ordenCompra.id_requisicion),
                            ordenCompra.clave_orden_compra,
                            ordenCompra.tipo_orden_compra,
                            ordenCompra.monto_orden_compra,
                            ordenCompra.fecha_orden_compra,
                            ordenCompra.fecha_limite_elab_orden_compra,
                            ordenCompra.fecha_enviada_firma_orden_compra,
                            ordenCompra.fecha_devuelta_firma_orden_compra
                        )
                    );
                return resultado.FirstOrDefault();

            }
        }

        /// <summary>
        /// Regresa un arreglos con todas la ordenes de compra
        /// </summary>
        /// <returns>lista generica de ordenes_compra</returns>
        public List<OrdenCompra> FindAll()
        {
            DAODataContext contexto = new DAODataContext();
            RequisicionDAO requisicionDAO = new RequisicionDAO();
            using (contexto)
            {

                var resultado =
                (
                    from ordenCompra in contexto.ordenes_compras
                    join requisicion in contexto.requisiciones on ordenCompra.id_requisicion equals requisicion.id_requisicion
                    select new OrdenCompra
                    (
                        ordenCompra.id_orden_compra, 
                        requisicionDAO.FindById(ordenCompra.id_requisicion), 
                        ordenCompra.clave_orden_compra, 
                        ordenCompra.tipo_orden_compra, 
                        ordenCompra.monto_orden_compra, 
                        ordenCompra.fecha_orden_compra, 
                        ordenCompra.fecha_limite_elab_orden_compra, 
                        ordenCompra.fecha_enviada_firma_orden_compra, 
                        ordenCompra.fecha_devuelta_firma_orden_compra
                    )
                );

                return resultado.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordenCompra"></param>
        /// <returns></returns>
        public int Insert(OrdenCompra ordenCompra)
        {
            ordenes_compra ordenCompraTable = new ordenes_compra
            {
                id_requisicion = ordenCompra.GetRequisicion().GetId(),
                clave_orden_compra = ordenCompra.GetClave(),
                tipo_orden_compra = ordenCompra.GetTipoDeOrden(),
                monto_orden_compra = ordenCompra.GetMonto(),
                fecha_orden_compra = ordenCompra.GetFechaOrdenCompra(),
                fecha_limite_elab_orden_compra = ordenCompra.GetFechaLimiteElaboracion(),
                fecha_enviada_firma_orden_compra = ordenCompra.GetFechaEnviadaFirma(),
                fecha_devuelta_firma_orden_compra = ordenCompra.GetFechaDevueltaDeFirma()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.ordenes_compras.InsertOnSubmit(ordenCompraTable);
            contexto.SubmitChanges();
            return 0;
        }

        /// <summary>
        /// Inserta un comprador al proporcionar los parámetros adecuados, el id es autogenerado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clave"></param>
        /// <param name="tipo"></param>
        /// <param name="monto"></param>
        /// <param name="fecha"></param>
        /// <param name="fecha_limite_elab"></param>
        /// <param name="fecha_enviada_firma"></param>
        /// <param name="fecha_devuelta_firma"></param>
        /// <returns></returns>
        public int Insert(Requisicion requisicion, int? clave, char tipo, decimal monto, DateTime fecha, 
            DateTime? fecha_limite_elab, DateTime? fecha_enviada_firma,DateTime? fecha_devuelta_firma)
        {

            ordenes_compra ordenCompraTable = new ordenes_compra
            {
                id_requisicion = requisicion.GetId(),
                clave_orden_compra = clave,
                tipo_orden_compra = tipo,
                monto_orden_compra = monto,
                fecha_orden_compra = fecha,
                fecha_limite_elab_orden_compra = fecha_limite_elab,
                fecha_enviada_firma_orden_compra = fecha_enviada_firma,
                fecha_devuelta_firma_orden_compra = fecha_devuelta_firma
                
            };


            DAODataContext contexto = new DAODataContext();
            contexto.ordenes_compras.InsertOnSubmit(ordenCompraTable);
            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Borra un objeto ordenCompra
        /// </summary>
        /// <param name="ordenCompra">El objeto ordenCompra a ser borrado</param>
        public int Delete(OrdenCompra ordenCompra)
        {
            ordenes_compra ordenCompraTable = new ordenes_compra 
            {

                id_orden_compra = ordenCompra.GetId(),
                clave_orden_compra = ordenCompra.GetClave(),
                tipo_orden_compra = ordenCompra.GetTipoDeOrden(),
                monto_orden_compra = ordenCompra.GetMonto(),
                fecha_orden_compra = ordenCompra.GetFechaOrdenCompra(),
                fecha_limite_elab_orden_compra = ordenCompra.GetFechaLimiteElaboracion(),
                fecha_enviada_firma_orden_compra = ordenCompra.GetFechaEnviadaFirma(),
                fecha_devuelta_firma_orden_compra = ordenCompra.GetFechaDevueltaDeFirma()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.ordenes_compras.Attach(ordenCompraTable);
            contexto.ordenes_compras.DeleteOnSubmit(ordenCompraTable);
            contexto.SubmitChanges();
            return 0;
        }

        /// <summary>
        /// Borra una orden de compra por medio del id
        /// </summary>
        /// <param name="id">El id de la orden de compra que se desea borrar</param>
        public int Delete(int id)
        {
            OrdenCompra ordenCompra = new OrdenCompra();

            ordenCompra = FindById(id);

            ordenes_compra ordenCompraTable = new ordenes_compra
            {
                id_orden_compra = ordenCompra.GetId(),
                clave_orden_compra = ordenCompra.GetClave(),
                tipo_orden_compra = ordenCompra.GetTipoDeOrden(),
                monto_orden_compra = ordenCompra.GetMonto(),
                fecha_orden_compra = ordenCompra.GetFechaOrdenCompra(),
                fecha_limite_elab_orden_compra = ordenCompra.GetFechaLimiteElaboracion(),
                fecha_enviada_firma_orden_compra = ordenCompra.GetFechaEnviadaFirma(),
                fecha_devuelta_firma_orden_compra = ordenCompra.GetFechaDevueltaDeFirma()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.ordenes_compras.Attach(ordenCompraTable);
            contexto.ordenes_compras.DeleteOnSubmit(ordenCompraTable);
            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Actualiza los datos de la orde de compra
        /// </summary>
        /// <param name="comprador">El nuevo objeto ordenCompra que reemplazara al anterior</param>
        public int Update(OrdenCompra ordenCompra)
        {
            DAODataContext contexto = new DAODataContext();

            ordenes_compra ordenCompraTable = contexto.ordenes_compras.Single(ordenCompraRow => ordenCompraRow.id_orden_compra == ordenCompra.GetId());

            ordenCompraTable.clave_orden_compra = ordenCompra.GetClave();
            ordenCompraTable.tipo_orden_compra = ordenCompra.GetTipoDeOrden();
            ordenCompraTable.monto_orden_compra = ordenCompra.GetMonto();
            ordenCompraTable.fecha_orden_compra = ordenCompra.GetFechaOrdenCompra();
            ordenCompraTable.fecha_limite_elab_orden_compra = ordenCompra.GetFechaLimiteElaboracion();
            ordenCompraTable.fecha_enviada_firma_orden_compra = ordenCompra.GetFechaEnviadaFirma();
            ordenCompraTable.fecha_devuelta_firma_orden_compra = ordenCompra.GetFechaDevueltaDeFirma();


            contexto.SubmitChanges();

            return 0;

        }

        /// <summary>
        /// Se actualizan los datos de la orden de compra
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clave"></param>
        /// <param name="tipo"></param>
        /// <param name="monto"></param>
        /// <param name="fecha"></param>
        /// <param name="fecha_limite_elab"></param>
        /// <param name="fecha_enviada_firma"></param>
        /// <param name="fecha_devuelta_firma"></param>
        /// <returns></returns>
        public int Update(int id, int? clave, char tipo, decimal monto, DateTime fecha,
            DateTime? fecha_limite_elab, DateTime? fecha_enviada_firma, DateTime? fecha_devuelta_firma)
        {
            DAODataContext contexto = new DAODataContext();

            ordenes_compra ordenCompraTable = contexto.ordenes_compras.Single(ordenCompraRow => ordenCompraRow.id_orden_compra == id);

            ordenCompraTable.clave_orden_compra = clave;
            ordenCompraTable.tipo_orden_compra = tipo;
            ordenCompraTable.monto_orden_compra = monto;
            ordenCompraTable.fecha_orden_compra = fecha;
            ordenCompraTable.fecha_limite_elab_orden_compra = fecha_limite_elab;
            ordenCompraTable.fecha_enviada_firma_orden_compra = fecha_enviada_firma;
            ordenCompraTable.fecha_devuelta_firma_orden_compra = fecha_devuelta_firma;

            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        ///  Actualiza la fecha de elaboracion de la orden de compra
        /// </summary>
        /// <param name="fechaLimiteElabActual">La fecha que actualmente tiene</param>
        /// <param name="nuevaFecha">La fecha por la que se quiere cambiar</param>
        /// <returns></returns>
        public int UpdateFechaElab(long id, DateTime nuevaFecha)
        {
            DAODataContext contexto = new DAODataContext();

            ordenes_compra ordenCompraTable = contexto.ordenes_compras.Single(ordenCompraRow => ordenCompraRow.id_orden_compra == id);

            ordenCompraTable.fecha_limite_elab_orden_compra = nuevaFecha;

            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Actualiza la fecha de envio de firma de la orden de compra
        /// </summary>
        /// <param name="fechaEnviadaFirmaActual">La fecha que actualmente tiene</param>
        /// <param name="nuevaFecha">La fecha por la que se quiere cambiar</param>
        /// <returns></returns>
        public int UpdateFechaEnviada(long id, DateTime nuevaFecha)
        {
            DAODataContext contexto = new DAODataContext();

            ordenes_compra ordenCompraTable = contexto.ordenes_compras.Single(ordenCompraRow => ordenCompraRow.id_orden_compra == id);

            ordenCompraTable.fecha_enviada_firma_orden_compra = nuevaFecha;

            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Actualiza la fecha en la que regresa  la orden de compra ya firmada
        /// </summary>
        /// <param name="fechaDevueltaFirma">la fecha que actualmente tiene</param>
        /// <param name="nuevaFecha">La fecha por la que se quiere cambiar</param>
        /// <returns></returns>
        public int UpdateFechaDevuelta(long id, DateTime nuevaFecha)
        {
            DAODataContext contexto = new DAODataContext();

            ordenes_compra ordenCompraTable = contexto.ordenes_compras.Single(ordenCompraRow => ordenCompraRow.id_orden_compra == id);

            ordenCompraTable.fecha_devuelta_firma_orden_compra = nuevaFecha;

            contexto.SubmitChanges();

            return 0;
        }

    }
}
