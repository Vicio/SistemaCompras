using System;
using System.Diagnostics;
using ComprasUAQ.DAO;
using ComprasUAQ.POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ComprasUAQTests.DAOTest
{
    [TestClass]
    class OrdenCompraDAOTest
    {
        /// <summary>
        /// Prueba de busqueda de orden de compra por id
        /// </summary>
        [TestMethod]
        public void FindById()
        {
            OrdenCompraDAO ordenCompraDAO = new OrdenCompraDAO();
            OrdenCompra ordenCompra = ordenCompraDAO.FindById(75);

        }

        /// <summary>
        /// Prueba de busqueda de todas las ordenes de compra
        /// </summary>
        [TestMethod]
        public void FindAll()
        {
            OrdenCompraDAO ordenCompraDAO = new OrdenCompraDAO();
            List<OrdenCompra> ordenCompra = ordenCompraDAO.FindAll();

        }

        /// <summary>
        /// Prueba de insercion de una orden de compra
        /// </summary>
        [TestMethod]
        public void InsertOrdenCompra()
        {
            OrdenCompra ordenCompra = new OrdenCompra();
            Requisicion requisicion = new Requisicion();

            ordenCompra.SetRequisicion(requisicion);
            ordenCompra.SetClave(2);
            ordenCompra.SetTipoDeOrden('A');
            ordenCompra.SetMonto(170);
            ordenCompra.SetFechaOrdenCompra(DateTime.Now);
            ordenCompra.SetFechaLimiteElaboracion(DateTime.Now);
            ordenCompra.SetFechaEnviadaFirma(DateTime.Now);
            ordenCompra.SetFechaDevueltaDeFirma(DateTime.Now);

            OrdenCompraDAO ordenCompraDAO = new OrdenCompraDAO();
            ordenCompraDAO.Insert(ordenCompra);
        }

        /// <summary>
        /// Prueba de borrado de una orden de compra
        /// </summary>
        [TestMethod]
        public void DeleteOrdenCOmpra()
        {
            OrdenCompra ordenCompra = new OrdenCompra();

            ordenCompra.SetId(2);
            ordenCompra.SetClave(2);
            ordenCompra.SetTipoDeOrden('A');
            ordenCompra.SetMonto(170);
            ordenCompra.SetFechaOrdenCompra(DateTime.Now);
            ordenCompra.SetFechaLimiteElaboracion(DateTime.Now);
            ordenCompra.SetFechaEnviadaFirma(DateTime.Now);
            ordenCompra.SetFechaDevueltaDeFirma(DateTime.Now);

            OrdenCompraDAO ordenCompraDAO = new OrdenCompraDAO();
            ordenCompraDAO.Delete(ordenCompra);
            

        }

        /// <summary>
        /// Prueba de actualizacion de una orden de compra
        /// </summary>
        [TestMethod]
        public void UpdateProveedor()
        {
            OrdenCompra ordenCompra = new OrdenCompra();

            ordenCompra.SetId(2);
            ordenCompra.SetClave(2);
            ordenCompra.SetTipoDeOrden('A');
            ordenCompra.SetMonto(190);
            ordenCompra.SetFechaOrdenCompra(DateTime.Now);
            ordenCompra.SetFechaLimiteElaboracion(DateTime.Now);
            ordenCompra.SetFechaEnviadaFirma(DateTime.Now);
            ordenCompra.SetFechaDevueltaDeFirma(DateTime.Now);

            OrdenCompraDAO ordenCompraDAO = new OrdenCompraDAO();
            ordenCompraDAO.Update(ordenCompra);
        }
    }
}

