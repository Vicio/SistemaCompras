using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComprasUAQ.DAO;
using ComprasUAQ.POCO;
using System.Transactions;
using System.Collections.Generic;
using System.Diagnostics;

namespace ComprasUAQTests.DAOTest
{
    [TestClass]
    public class RequisicionDAOTest
    {
        [TestMethod]
        public void FindByIdRequisicion()
        {
            RequisicionDAO requisicionDAO = new RequisicionDAO();

            Requisicion requisicion = requisicionDAO.FindById(76);
        }

        [TestMethod]
        public void FindByCentroGasto()
        {
            RequisicionDAO requisicionDAO = new RequisicionDAO();

            List<Requisicion> requisicion = requisicionDAO.FindByCentroGasto("Escuela de Bachilleres");
            for (int i = 0; i < requisicion.Count ; i ++) {
                Trace.Write(requisicion[i].GetClave());
            }
        }

        [TestMethod]
        public void FindAllRequisicion()
        {
            RequisicionDAO requisicionDAO = new RequisicionDAO();
            List<Requisicion> requisicion = requisicionDAO.FindAll();
        }

        [TestMethod]
        public void InsertRequisicion()
        {
            Requisicion requisicion = new Requisicion();
            CentroGastoDAO centroGastoDAO = new CentroGastoDAO();
            ProveedorDAO proveedorDAO = new ProveedorDAO();
            CompradorDAO compradorDAO = new CompradorDAO();


            centroGastoDAO.Insert("Facultad de Bellas Artes");
            CentroGasto centroGasto = centroGastoDAO.FindByNombre("Facultad de Bellas Artes");

            proveedorDAO.Insert("HP", true);
            Proveedor proveedor = proveedorDAO.FindByNombre("HP");

            compradorDAO.Insert("Alejandro", "Martínez", "Pérez");
            Comprador comprador = compradorDAO.FindByNombre("Alejandro");

            requisicion.SetComprador(comprador);
            requisicion.SetCentroGasto(centroGasto);
            requisicion.SetProveedor(proveedor);
            requisicion.SetClave("hola");
            requisicion.SetFechaElaboracion(DateTime.Now);
            requisicion.SetFechaEntrega(DateTime.Now.AddMonths(1));
            requisicion.SetEstado('j');
            requisicion.SetCartaCompromiso("hola");
            requisicion.SetFechaPromesaEntrega(DateTime.Now.AddMonths(3));
            requisicion.SetObservaciones("ninguna");

            RequisicionDAO requisicionDAO = new RequisicionDAO();

            requisicionDAO.Insert(requisicion);

            requisicionDAO.Delete(requisicion);
            compradorDAO.Delete(comprador);
            proveedorDAO.Delete(proveedor);
            centroGastoDAO.Delete(centroGasto);

        }

        /// <summary>
        /// Prueba de borrado de una requisicion
        /// </summary>
        [TestMethod]
        public void DeleteRequisicion()
        {
            Requisicion requisicion = new Requisicion();

            requisicion.SetId(3);
            requisicion.SetClave("hola");
            requisicion.SetFechaElaboracion(DateTime.Now);
            requisicion.SetFechaEntrega(DateTime.Now.AddMonths(1));
            requisicion.SetEstado('d');
            requisicion.SetCartaCompromiso("hola");
            requisicion.SetFechaPromesaEntrega(DateTime.Now.AddMonths(3));
            requisicion.SetObservaciones("ninguna");

            RequisicionDAO requisicionDAO = new RequisicionDAO();

            requisicionDAO.Delete(requisicion);

        }

        [TestMethod]
        public void UpdateRequisicion()
        {

            Requisicion requisicion = new Requisicion();
            CentroGastoDAO centroGastoDAO = new CentroGastoDAO();
            ProveedorDAO proveedorDAO = new ProveedorDAO();
            CompradorDAO compradorDAO = new CompradorDAO();
            RequisicionDAO requisicionDAO = new RequisicionDAO();

            centroGastoDAO.Insert("Facultad de Bellas Artes");
            CentroGasto centroGasto = centroGastoDAO.FindByNombre("Facultad de Bellas Artes");

            proveedorDAO.Insert("HP", true);
            Proveedor proveedor = proveedorDAO.FindByNombre("HP");

            compradorDAO.Insert("Alejandro", "Martínez", "Pérez");
            Comprador comprador = compradorDAO.FindByNombre("Alejandro");

            requisicion.SetId(4);
            requisicion.SetCentroGasto(centroGasto);
            requisicion.SetComprador(comprador);
            requisicion.SetProveedor(proveedor);
            requisicion.SetClave("hola");
            requisicion.SetFechaElaboracion(DateTime.Now);
            requisicion.SetEstado('k');
            requisicion.SetCartaCompromiso("hallo");
            requisicion.SetFechaEntrega(DateTime.Now.AddMonths(1));
            requisicion.SetFechaPromesaEntrega(DateTime.Now.AddMonths(3));
            requisicion.SetObservaciones("ningun");

            requisicionDAO.Update(requisicion);
        }

    }
}
