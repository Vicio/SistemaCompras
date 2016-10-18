using System;
using System.Diagnostics;
using ComprasUAQ.DAO;
using ComprasUAQ.POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ComprasUAQTests.DAOTest
{
    [TestClass]
    public class RecepcionAlmacenDAOTest
    {
        /// <summary>
        /// Prueba de busqueda de la recepcion de almacen
        /// </summary>
        [TestMethod]
        public void FindById()
        {
            RecepcionAlmacenDAO recepcionAlmacenDAO = new RecepcionAlmacenDAO();

            RecepcionAlmacen recepcionAlmacen = recepcionAlmacenDAO.FindById(76);
        }

        /// <summary>
        /// Prueba de busqueda de todas las recepciones de almacen
        /// </summary>
        [TestMethod]
        public void FindAll()
        {
            RecepcionAlmacenDAO recepcionAlmacenDAO = new RecepcionAlmacenDAO();

            List<RecepcionAlmacen> recepcionAlmacen = recepcionAlmacenDAO.FindAll();
        }

        /// <summary>
        /// Prueba de insercion de una recepcion de almacen
        /// </summary>
        [TestMethod]
        public void InsertRecepcionAlmacen()
        {
            RecepcionAlmacen recepcionAlmacen = new RecepcionAlmacen();
            RemitenteDAO remitenteDAO = new RemitenteDAO();
            RequisicionDAO requisicionDAO = new RequisicionDAO();
            CentroGastoDAO centroGastoDAO = new CentroGastoDAO();
            ProveedorDAO proveedorDAO = new ProveedorDAO();
            CompradorDAO compradorDAO = new CompradorDAO();

            remitenteDAO.Insert("Elias","Rosales","Martinez");
            Remitente remitente = remitenteDAO.FindByNombre("Elias");

            centroGastoDAO.Insert("Facultad de Bellas Artes");
            CentroGasto centroGasto = centroGastoDAO.FindByNombre("Facultad de Bellas Artes");

            proveedorDAO.Insert("HP", true);
            Proveedor proveedor = proveedorDAO.FindByNombre("HP");

            compradorDAO.Insert("Alejandro", "Martínez", "Pérez");
            Comprador comprador = compradorDAO.FindByNombre("Alejandro");

            requisicionDAO.Insert(centroGasto.GetId(),comprador.GetId(),proveedor.GetId(),"hola",DateTime.Now,DateTime.Now.AddMonths(3),
                'e',"hola",DateTime.Now.AddMonths(5),"ninguna");
            Requisicion requisicion = requisicionDAO.FindById(4);

            recepcionAlmacen.SetRemitente(remitente);
            recepcionAlmacen.SetRequisicion(requisicion);
            recepcionAlmacen.SetClave(1);
            recepcionAlmacen.SetFechaRecepcion(DateTime.Now);
            recepcionAlmacen.SetMonto(190);
            recepcionAlmacen.SetFechaEntregaDeAlmacen(DateTime.Now);
            recepcionAlmacen.SetNumeroResguardo("12");

            RecepcionAlmacenDAO recepcionAlmacenDAO = new RecepcionAlmacenDAO();

            recepcionAlmacenDAO.Insert(recepcionAlmacen);
        }

        /// <summary>
        /// Prueba de borrado de una recepcion de almacen
        /// </summary>
        [TestMethod]
        public void DeleteRecepcionAlmacen()
        {
            RecepcionAlmacen recepcionAlmacen = new RecepcionAlmacen();
            Requisicion requisicion = new Requisicion();
            Remitente remitente = new Remitente();

            recepcionAlmacen.SetRemitente(remitente);
            recepcionAlmacen.SetRequisicion(requisicion);
            recepcionAlmacen.SetClave(3);
            recepcionAlmacen.SetFechaRecepcion(DateTime.Now);
            recepcionAlmacen.SetMonto(190);
            recepcionAlmacen.SetFechaEntregaDeAlmacen(DateTime.Now);
            recepcionAlmacen.SetNumeroResguardo("12");

            RecepcionAlmacenDAO recepcionAlmacenDAO = new RecepcionAlmacenDAO();

            recepcionAlmacenDAO.Delete(recepcionAlmacen);
        }

        /// <summary>
        /// Prueba de actualizacion de una recepcion de almacen
        /// </summary>
        [TestMethod]
        public void UpdateRecepcionAlmacen()
        {
            RecepcionAlmacen recepcionAlmacen = new RecepcionAlmacen();
            RemitenteDAO remitenteDAO = new RemitenteDAO();
            RequisicionDAO requisicionDAO = new RequisicionDAO();
            CentroGastoDAO centroGastoDAO = new CentroGastoDAO();
            ProveedorDAO proveedorDAO = new ProveedorDAO();
            CompradorDAO compradorDAO = new CompradorDAO();

            remitenteDAO.Insert("Elias", "Rosales", "Martinez");
            Remitente remitente = remitenteDAO.FindByNombre("Elias");

            centroGastoDAO.Insert("Facultad de Bellas Artes");
            CentroGasto centroGasto = centroGastoDAO.FindByNombre("Facultad de Bellas Artes");

            proveedorDAO.Insert("HP", true);
            Proveedor proveedor = proveedorDAO.FindByNombre("HP");

            compradorDAO.Insert("Alejandro", "Martínez", "Pérez");
            Comprador comprador = compradorDAO.FindByNombre("Alejandro");

            requisicionDAO.Insert(centroGasto.GetId(), comprador.GetId(), proveedor.GetId(), "hola", DateTime.Now, DateTime.Now.AddMonths(3),
                'e', "hola", DateTime.Now.AddMonths(5), "ninguna");
            Requisicion requisicion = requisicionDAO.FindById(5);

            recepcionAlmacen.SetId(1);
            recepcionAlmacen.SetRemitente(remitente);
            recepcionAlmacen.SetRequisicion(requisicion);
            recepcionAlmacen.SetClave(8);
            recepcionAlmacen.SetFechaRecepcion(DateTime.Now);
            recepcionAlmacen.SetMonto(180);
            recepcionAlmacen.SetFechaEntregaDeAlmacen(DateTime.Now);
            recepcionAlmacen.SetNumeroResguardo("12");

            RecepcionAlmacenDAO recepcionAlmacenDAO = new RecepcionAlmacenDAO();

            recepcionAlmacenDAO.Update(recepcionAlmacen);
        }
    }
}
