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
    /// Clase de Data Access Object de la Requisicion
    /// </summary>
    public class RequisicionDAO
    {
        /// <summary>
        /// Encontrar la requisicion por id
        /// </summary>
        /// <param name="id">El id de la requisicion a buscar</param>
        /// <returns>La requisicion requerida</returns>
        public Requisicion FindById(long id)
        {
            DAODataContext contexto = new DAODataContext();
            ProveedorDAO proveedorDAO = new ProveedorDAO();
            CentroGastoDAO centroGastoDAO = new CentroGastoDAO();
            CompradorDAO compradorDAO = new CompradorDAO();
            using (contexto)
            {

                var resultado =
                (
                    from requisicion in contexto.requisiciones
                    where requisicion.id_requisicion == id
                    select new Requisicion(requisicion.id_requisicion, centroGastoDAO.FindById(requisicion.id_centro_gasto), 
                        compradorDAO.FindById(requisicion.id_comprador), proveedorDAO.FindById(requisicion.id_proveedor),
                        requisicion.clave_requisicion, requisicion.fecha_elaboracion_requisicion, requisicion.fecha_entrega_requisicion,
                        requisicion.estado_requisicion, requisicion.carta_compromiso_requisicion, requisicion.fecha_promesa_entrega,
                        requisicion.observacion_requisicion)
                    
                );
                return resultado.FirstOrDefault();
            }
        }

        /// <summary>
        /// Encontrar la requisiciones por el Nombre del Centro de gasto
        /// </summary>
        /// <param name="centGasto"></param>
        /// <returns></returns>
        public List<Requisicion> FindByCentroGasto(string centGasto)
        {
            DAODataContext contexto = new DAODataContext();
            ProveedorDAO proveedorDAO = new ProveedorDAO();
            CentroGastoDAO centroGastoDAO = new CentroGastoDAO();
            CompradorDAO compradorDAO = new CompradorDAO();
            using (contexto)
            {
                var resultado =
                (
                    from requisicion in contexto.requisiciones
                    from centroGasto in contexto.centros_gastos

                    where centroGasto.nombre_centro_gasto.ToUpper().Contains(centGasto) && requisicion.id_centro_gasto == centroGasto.id_centro_gasto
                    select new Requisicion(requisicion.id_requisicion, centroGastoDAO.FindById(requisicion.id_centro_gasto),
                        compradorDAO.FindById(requisicion.id_comprador), proveedorDAO.FindById(requisicion.id_proveedor),
                        requisicion.clave_requisicion, requisicion.fecha_elaboracion_requisicion, requisicion.fecha_entrega_requisicion,
                        requisicion.estado_requisicion, requisicion.carta_compromiso_requisicion, requisicion.fecha_promesa_entrega,
                        requisicion.observacion_requisicion)
                        
                );
                return resultado.ToList();
            }
        }

        /// <summary>
        /// Encontrar todas las requisiciones
        /// </summary>
        /// <returns>Una lista de objetos requisicion</returns>
        public List<Requisicion> FindAll()
        {
            DAODataContext contexto = new DAODataContext();
            ProveedorDAO proveedorDAO = new ProveedorDAO();
            CentroGastoDAO centroGastoDAO = new CentroGastoDAO();
            CompradorDAO compradorDAO = new CompradorDAO();
            using (contexto)
            {
                var resultado =
                (
                    from requisicion in contexto.requisiciones
                    select new Requisicion(requisicion.id_requisicion, centroGastoDAO.FindById(requisicion.id_centro_gasto), 
                        compradorDAO.FindById(requisicion.id_comprador), proveedorDAO.FindById(requisicion.id_proveedor),
                        requisicion.clave_requisicion, requisicion.fecha_elaboracion_requisicion, requisicion.fecha_entrega_requisicion,
                        requisicion.estado_requisicion, requisicion.carta_compromiso_requisicion, requisicion.fecha_promesa_entrega,
                        requisicion.observacion_requisicion)

                );
                return resultado.ToList();
            }
        }

        /// <summary>
        /// Insercion del objeto requisicion
        /// </summary>
        /// <param name="requisicion"></param>
        /// <returns>El código de error, 0 si el resultado es exitoso</returns>
        public int Insert(Requisicion requisicion)
        {

            requisiciones requisicionTable = new requisiciones
            {
                id_centro_gasto = requisicion.GetCentroGasto().GetId(),
                id_comprador = requisicion.GetComprador().GetId(),
                id_proveedor = requisicion.GetProveedor().GetId(),
                clave_requisicion = requisicion.GetClave(),
                fecha_elaboracion_requisicion = requisicion.GetFechaElaboracion(),
                fecha_entrega_requisicion = requisicion.GetFechaEntrega(),
                estado_requisicion = requisicion.GetEstado(),
                carta_compromiso_requisicion = requisicion.GetCartaCompromiso(),
                fecha_promesa_entrega = requisicion.GetFechaPromesaEntrega(),
                observacion_requisicion = requisicion.GetObservaciones()
            };

            DAODataContext contexto = new DAODataContext();
            contexto.requisiciones.InsertOnSubmit(requisicionTable);
            contexto.SubmitChanges();
            return 0;
        }

        /// <summary>
        /// Insercion del objeto requisicion
        /// </summary>
        /// <param name="idCentroGasto">El id del centro de gasto</param>
        /// <param name="idComprador">El id del comprador</param>
        /// <param name="idProveedor">El id del proveedor</param>
        /// <param name="clave">La clave de la requisicion</param>
        /// <param name="fechaElaboracion">La fecha de elaboracion de la requisicion</param>
        /// <param name="fechaEntrega">La fecha de entrega limite de la requisicion</param>
        /// <param name="estado">El estado de la requisicion</param>
        /// <param name="cartaCompromiso">La carta compromiso de la requisicion</param>
        /// <param name="fechaPromesaEntrega">La fecha de promesa de entrega de la requisicion</param>
        /// <param name="observaciones">Observaciones respecto a la requisicion</param>
        /// <returns>El código de error, 0 si el resultado es exitoso</returns>
        public int Insert(int idCentroGasto, int idComprador, int idProveedor,
            string clave, DateTime fechaElaboracion, DateTime? fechaEntrega, 
            char? estado, string cartaCompromiso, DateTime? fechaPromesaEntrega, string observaciones)
        {
            requisiciones requisicionTable = new requisiciones
            {
                id_centro_gasto = idCentroGasto,
                id_comprador = idComprador,
                id_proveedor = idProveedor,
                clave_requisicion = clave,
                fecha_elaboracion_requisicion = fechaElaboracion,
                fecha_entrega_requisicion = fechaEntrega,
                estado_requisicion = estado,
                carta_compromiso_requisicion = cartaCompromiso,
                fecha_promesa_entrega = fechaPromesaEntrega,
                observacion_requisicion = observaciones
            };

            DAODataContext contexto = new DAODataContext();
            contexto.requisiciones.InsertOnSubmit(requisicionTable);
            contexto.SubmitChanges();
            return 0;
        }

        /// <summary>
        /// Insercion del objeto requisicion
        /// </summary>
        /// <param name="requisicion"></param>
        /// <returns>El código de error, 0 si el resultado es exitoso</returns>
        public int Insert(Requisicion requisicion, bool agregarCentroGasto, bool agregarComprador, bool agregarProveedor)
        {
            if(agregarCentroGasto)
            {
                ///Aqui se manejara la insercion del centro de gasto
                CentroGasto centroGasto = new CentroGasto();

                CentroGastoDAO centroGastoDAO = new CentroGastoDAO();

                centroGastoDAO.Insert(centroGasto);
            }

            if(agregarComprador)
            {
                ///Aqui se manejara la insercion del comprador asignado
                Comprador comprador = new Comprador();

                CompradorDAO compradorDAO = new CompradorDAO();

                compradorDAO.Insert(comprador);
            }

            if(agregarProveedor)
            {
                ///Aqui se manejara la insercion del proveedor
                Proveedor proveedor = new Proveedor();

                ProveedorDAO proveedorDAO = new ProveedorDAO();

                proveedorDAO.Insert(proveedor);
            }

            requisiciones requisicionTable = new requisiciones
            {
                id_centro_gasto = requisicion.GetCentroGasto().GetId(),
                id_comprador = requisicion.GetComprador().GetId(),
                id_proveedor = requisicion.GetProveedor().GetId(),
                clave_requisicion = requisicion.GetClave(),
                fecha_elaboracion_requisicion = requisicion.GetFechaElaboracion(),
                fecha_entrega_requisicion = requisicion.GetFechaEntrega(),
                estado_requisicion = requisicion.GetEstado(),
                carta_compromiso_requisicion = requisicion.GetCartaCompromiso(),
                fecha_promesa_entrega = requisicion.GetFechaPromesaEntrega(),
                observacion_requisicion = requisicion.GetObservaciones()
            };

            DAODataContext contexto = new DAODataContext();
            contexto.requisiciones.InsertOnSubmit(requisicionTable);
            contexto.SubmitChanges();
            return 0;
        }

        public int Delete(Requisicion requisicion)
        {
            requisiciones requisicionTable = new requisiciones
            {
                id_requisicion = requisicion.GetId(),
                id_centro_gasto = requisicion.GetCentroGasto().GetId(),
                id_comprador = requisicion.GetComprador().GetId(),
                id_proveedor = requisicion.GetProveedor().GetId(),
                clave_requisicion = requisicion.GetClave(),
                fecha_elaboracion_requisicion = requisicion.GetFechaElaboracion(),
                fecha_entrega_requisicion = requisicion.GetFechaEntrega(),
                estado_requisicion = requisicion.GetEstado(),
                carta_compromiso_requisicion = requisicion.GetCartaCompromiso(),
                fecha_promesa_entrega = requisicion.GetFechaPromesaEntrega(),
                observacion_requisicion = requisicion.GetObservaciones()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.requisiciones.Attach(requisicionTable);
            contexto.requisiciones.DeleteOnSubmit(requisicionTable);
            contexto.SubmitChanges();
            return 0;
        }

        public int Delete(long id)
        {
            Requisicion requisicion = new Requisicion();

            requisicion = FindById(id);

            requisiciones requisicionTable = new requisiciones
            {
                id_requisicion = requisicion.GetId(),
                id_centro_gasto = requisicion.GetCentroGasto().GetId(),
                id_comprador = requisicion.GetComprador().GetId(),
                id_proveedor = requisicion.GetProveedor().GetId(),
                clave_requisicion = requisicion.GetClave(),
                fecha_elaboracion_requisicion = requisicion.GetFechaElaboracion(),
                fecha_entrega_requisicion = requisicion.GetFechaEntrega(),
                estado_requisicion = requisicion.GetEstado(),
                carta_compromiso_requisicion = requisicion.GetCartaCompromiso(),
                fecha_promesa_entrega = requisicion.GetFechaPromesaEntrega(),
                observacion_requisicion = requisicion.GetObservaciones()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.requisiciones.Attach(requisicionTable);
            contexto.requisiciones.DeleteOnSubmit(requisicionTable);
            contexto.SubmitChanges();

            return 0;
        }


        public int Update(Requisicion requisicion)
        {
            DAODataContext contexto = new DAODataContext();

            requisiciones requisicionTable = contexto.requisiciones.Single(req => req.id_requisicion == requisicion.GetId());

            requisicionTable.id_centro_gasto = requisicion.GetCentroGasto().GetId();
            requisicionTable.id_comprador = requisicion.GetComprador().GetId();
            requisicionTable.id_proveedor = requisicion.GetProveedor().GetId();
            requisicionTable.clave_requisicion = requisicion.GetClave();
            requisicionTable.fecha_elaboracion_requisicion = requisicion.GetFechaElaboracion();
            requisicionTable.fecha_entrega_requisicion = requisicion.GetFechaEntrega();
            requisicionTable.estado_requisicion = requisicion.GetEstado();
            requisicionTable.carta_compromiso_requisicion = requisicion.GetCartaCompromiso();
            requisicionTable.fecha_promesa_entrega = requisicion.GetFechaPromesaEntrega();
            requisicionTable.observacion_requisicion = requisicion.GetObservaciones();

            contexto.SubmitChanges();

            return 0;

        }


        public int Update(long id, int idCentroGasto, int idComprador, int idProveedor,
            string clave, DateTime fechaElaboracion, DateTime? fechaEntrega,
            char? estado, string cartaCompromiso, DateTime? fechaPromesaEntrega, string observaciones)
        {
            DAODataContext contexto = new DAODataContext();

            requisiciones requisicionTable = contexto.requisiciones.Single(req => req.id_requisicion == id);

            requisicionTable.id_centro_gasto = idCentroGasto;
            requisicionTable.id_comprador = idComprador;
            requisicionTable.id_proveedor = idProveedor;
            requisicionTable.clave_requisicion = clave;
            requisicionTable.fecha_elaboracion_requisicion = fechaElaboracion;
            requisicionTable.fecha_entrega_requisicion = fechaEntrega;
            requisicionTable.estado_requisicion = estado;
            requisicionTable.carta_compromiso_requisicion = cartaCompromiso;
            requisicionTable.fecha_promesa_entrega = fechaPromesaEntrega;
            requisicionTable.observacion_requisicion = observaciones;

            contexto.SubmitChanges();

            return 0;
        }
    }
}
