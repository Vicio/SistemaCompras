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
    /// <summary>
    /// Clase Data Access Object de RecepcionAlmacen
    /// </summary>
    public class RecepcionAlmacenDAO
    {
        /// <summary>
        /// Encontrar Recepcion Almacen por ID
        /// </summary>
        /// <param name="id">id de la recepcion a encontrar</param>
        /// <returns></returns>
        public RecepcionAlmacen FindById(int id)
        {
            DAODataContext contexto = new DAODataContext();
            RequisicionDAO requisicionDAO = new RequisicionDAO();
            RemitenteDAO remitenteDAO = new RemitenteDAO();
            using (contexto)
            {
                var resultado =
                (

                    from recepcionAlmacen in contexto.recepciones_almacens
                    where recepcionAlmacen.id_recepcion_almacen == id
                    select new RecepcionAlmacen
                    (
                        recepcionAlmacen.id_recepcion_almacen,
                        requisicionDAO.FindById(recepcionAlmacen.id_requisicion),
                        remitenteDAO.FindById(recepcionAlmacen.id_remitente),
                        recepcionAlmacen.clave_recepcion_almacen,
                        recepcionAlmacen.fecha_entrega_de_almacen,
                        recepcionAlmacen.fecha_recepcion_almacen,
                        recepcionAlmacen.monto_recepcion_almacen,
                        recepcionAlmacen.num_resguardo_almacen 

                    )
                );
                return resultado.FirstOrDefault();
            }
        }
        /// <summary>
        /// Encontrar todas las Recepciones
        /// </summary>
        /// <returns>Lista de las recepciones</returns>
        public List<RecepcionAlmacen> FindAll()
        {
            DAODataContext contexto = new DAODataContext();
            RequisicionDAO requisicionDAO = new RequisicionDAO();
            RemitenteDAO remitenteDAO = new RemitenteDAO();
            using (contexto)
            {


                var resultado =
                (
                    from recepcionAlmacen in contexto.recepciones_almacens
                    select new RecepcionAlmacen
                    (
                        recepcionAlmacen.id_recepcion_almacen,
                        requisicionDAO.FindById(recepcionAlmacen.id_requisicion),
                        remitenteDAO.FindById(recepcionAlmacen.id_remitente),
                        recepcionAlmacen.clave_recepcion_almacen,
                        recepcionAlmacen.fecha_entrega_de_almacen,
                        recepcionAlmacen.fecha_recepcion_almacen,
                        recepcionAlmacen.monto_recepcion_almacen,
                        recepcionAlmacen.num_resguardo_almacen

                    )
                );

                return resultado.ToList();
            }
        }
        /// <summary>
        /// Inserccion del objeto Recepcion
        /// </summary>
        /// <param name="recepcionAlmacen"></param>
        /// <returns>El código de error, 0 si el resultado es exitoso</returns>
        public int Insert(RecepcionAlmacen recepcionAlmacen)
        {
            recepciones_almacen recepcionAlmacenTable = new recepciones_almacen
            {
               id_requisicion = recepcionAlmacen.GetRequisicion().GetId(),
               id_remitente = recepcionAlmacen.GetRemitente().GetId(),
               clave_recepcion_almacen = recepcionAlmacen.GetClave(),
               fecha_recepcion_almacen = recepcionAlmacen.GetFechaRecepcion(),
               monto_recepcion_almacen = recepcionAlmacen.GetMonto(),
               fecha_entrega_de_almacen = recepcionAlmacen.GetFechaEntregaDeAlmacen(),
               num_resguardo_almacen = recepcionAlmacen.GetNumeroResguardo(),
            };

            DAODataContext contexto = new DAODataContext();
            contexto.recepciones_almacens.InsertOnSubmit(recepcionAlmacenTable);
            contexto.SubmitChanges();

            return 0;
        }
        /// <summary>
        /// Inserccion del objeto Recepcion
        /// </summary>
        /// <param name="requisicion"></param>
        /// <param name="remitente"></param>
        /// <param name="clave"></param>
        /// <param name="fecha"></param>
        /// <param name="monto"></param>
        /// <param name="fechaEntrega"></param>
        /// <param name="numResguardo"></param>
        /// <returns>El código de error, 0 si el resultado es exitoso</returns>
        public int Insert(Requisicion requisicion, Remitente remitente, int clave, DateTime fecha, decimal monto, DateTime fechaEntrega, string numResguardo)
        {

            recepciones_almacen recepcionAlmacenTable = new recepciones_almacen
            {
               id_requisicion =requisicion.GetId(),
               id_remitente = remitente.GetId(),
               clave_recepcion_almacen= clave,
               fecha_recepcion_almacen=fecha,
               monto_recepcion_almacen=monto,
               fecha_entrega_de_almacen=fechaEntrega,
               num_resguardo_almacen=numResguardo
            };


            DAODataContext contexto = new DAODataContext();
            contexto.recepciones_almacens.InsertOnSubmit(recepcionAlmacenTable);
            contexto.SubmitChanges();

            return 0;
        }
        /// <summary>
        /// Eliminacion del objeto Rececpcion
        /// </summary>
        /// <param name="recepcionAlmacen"></param>
        /// <returns>El código de error, 0 si el resultado es exitoso</returns>
        public int Delete(RecepcionAlmacen recepcionAlmacen)
        {
            recepciones_almacen recepcionAlmacenTable = new recepciones_almacen
            {
                id_recepcion_almacen = recepcionAlmacen.GetId(),
                clave_recepcion_almacen=recepcionAlmacen.GetClave(),
                fecha_recepcion_almacen =recepcionAlmacen.GetFechaRecepcion(),
                monto_recepcion_almacen = recepcionAlmacen.GetMonto(),
                fecha_entrega_de_almacen = recepcionAlmacen.GetFechaEntregaDeAlmacen(),
                num_resguardo_almacen = recepcionAlmacen.GetNumeroResguardo()
            };

            DAODataContext contexto = new DAODataContext();
            contexto.recepciones_almacens.Attach(recepcionAlmacenTable);
            contexto.recepciones_almacens.DeleteOnSubmit(recepcionAlmacenTable);
            contexto.SubmitChanges();
            return 0;
        }
        /// <summary>
        /// Eliminacion del objeto Recepcion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clave"></param>
        /// <param name="fecha"></param>
        /// <param name="monto"></param>
        /// <param name="fechaEntrega"></param>
        /// <param name="numResguardo"></param>
        /// <returns>El código de error, 0 si el resultado es exitoso</returns>
        public int Delete(int id, int clave, DateTime fecha, decimal monto, DateTime fechaEntrega, string numResguardo)
        {
            RecepcionAlmacen recepcionAlmacen = new RecepcionAlmacen();

            recepcionAlmacen = FindById(id);

            recepciones_almacen recepcionAlmacenTable = new recepciones_almacen
            {
                id_recepcion_almacen = recepcionAlmacen.GetId(),
                clave_recepcion_almacen=recepcionAlmacen.GetClave(),
                fecha_recepcion_almacen=recepcionAlmacen.GetFechaRecepcion(),
                monto_recepcion_almacen = recepcionAlmacen.GetMonto(),
                fecha_entrega_de_almacen = recepcionAlmacen.GetFechaEntregaDeAlmacen(),
                num_resguardo_almacen = recepcionAlmacen.GetNumeroResguardo()
            };

            DAODataContext contexto = new DAODataContext();
            contexto.recepciones_almacens.Attach(recepcionAlmacenTable);
            contexto.recepciones_almacens.DeleteOnSubmit(recepcionAlmacenTable);
            contexto.SubmitChanges();
            return 0;
        }
        /// <summary>
        /// Actualizacion del objeeto Recepcion
        /// </summary>
        /// <param name="recepcionAlmacen"></param>
        /// <returns>El código de error, 0 si el resultado es exitoso</returns>
        public int Update(RecepcionAlmacen recepcionAlmacen)
        {
            DAODataContext contexto = new DAODataContext();

            recepciones_almacen recepcionAlmacenTable = contexto.recepciones_almacens.Single(recepcionAlmacenRow => recepcionAlmacenRow.id_recepcion_almacen == recepcionAlmacen.GetId());

            recepcionAlmacenTable.id_recepcion_almacen = recepcionAlmacen.GetId();
            recepcionAlmacenTable.clave_recepcion_almacen = recepcionAlmacen.GetClave();
            recepcionAlmacenTable.fecha_recepcion_almacen = recepcionAlmacen.GetFechaRecepcion();
            recepcionAlmacenTable.monto_recepcion_almacen = recepcionAlmacen.GetMonto();
            recepcionAlmacenTable.fecha_entrega_de_almacen = recepcionAlmacen.GetFechaEntregaDeAlmacen();
            recepcionAlmacenTable.num_resguardo_almacen = recepcionAlmacen.GetNumeroResguardo();

            contexto.SubmitChanges();

            return 0;
        }
        /// <summary>
        /// Actualizacion del objeto Recepcion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clave"></param>
        /// <param name="fecha"></param>
        /// <param name="monto"></param>
        /// <param name="fechaEntrega"></param>
        /// <param name="numResguardo"></param>
        /// <returns>El código de error, 0 si el resultado es exitoso</returns>
        public int Update(int id, int clave, DateTime fecha, decimal monto, DateTime fechaEntrega, string numResguardo)
        {
            DAODataContext contexto = new DAODataContext();

            recepciones_almacen recepcionAlmacenTable = contexto.recepciones_almacens.Single(recepcionAlmacenRow => recepcionAlmacenRow.id_recepcion_almacen == id);

            recepcionAlmacenTable.clave_recepcion_almacen = clave;
            recepcionAlmacenTable.fecha_recepcion_almacen = fecha;
            recepcionAlmacenTable.monto_recepcion_almacen = monto;
            recepcionAlmacenTable.fecha_entrega_de_almacen = fechaEntrega;
            recepcionAlmacenTable.num_resguardo_almacen = numResguardo;

            contexto.SubmitChanges();

            return 0;
        }
        public int Update(int claveActual, int claveNuevo)
        {
            DAODataContext contexto = new DAODataContext();

            recepciones_almacen recepcionAlmacenTable = contexto.recepciones_almacens.Single(recepcionAlmacenRow => recepcionAlmacenRow.clave_recepcion_almacen == claveActual);

            recepcionAlmacenTable.clave_recepcion_almacen = claveNuevo;

            contexto.SubmitChanges();
            return 0;
        }
        public int Update(DateTime fechaRecActual, DateTime fechaReNuevo)
        {
            DAODataContext contexto = new DAODataContext();

            recepciones_almacen recepcionAlmacenTable = contexto.recepciones_almacens.Single(recepcionAlmacenRow => recepcionAlmacenRow.fecha_recepcion_almacen == fechaRecActual);

            recepcionAlmacenTable.fecha_recepcion_almacen = fechaReNuevo;

            contexto.SubmitChanges();
            return 0;
        }
        public int Update(decimal montoActual, decimal montoNuevo)
        {
            DAODataContext contexto = new DAODataContext();

            recepciones_almacen recepcionAlmacenTable = contexto.recepciones_almacens.Single(recepcionAlmacenRow => recepcionAlmacenRow.monto_recepcion_almacen == montoActual);

            recepcionAlmacenTable.monto_recepcion_almacen = montoNuevo;

            contexto.SubmitChanges();
            return 0;
        }
    }
}
