using System;
using System.Diagnostics;
using ComprasUAQ.DAO;
using ComprasUAQ.POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ComprasUAQTests.DAOTest
{
    [TestClass]
    public class ProveedorDAOTest
    {
        /// <summary>
        /// Prueba de busqueda del proveedor por id
        /// </summary>
        [TestMethod]
        public void FindByIdProveedor()
        {
            ProveedorDAO proveedorDAO = new ProveedorDAO();

            Proveedor proveedor =  proveedorDAO.FindById(76);
        }

        /// <summary>
        /// Prueba de busqueda de todos los proveedores
        /// </summary>
        [TestMethod]
        public void FindAllProveedor()
        {
            ProveedorDAO proveedorDAO = new ProveedorDAO();

            List<Proveedor> proveedor = proveedorDAO.FindAll();
        }

        /// <summary>
        /// Prueba de insercion de un proveedor
        /// </summary>
        [TestMethod]
        public void InsertProveedor()
        {
            Proveedor proveedor = new Proveedor();

            proveedor.SetNombre("Dell");
            proveedor.SetPersonaMoral(true);

            ProveedorDAO proveedorDAO = new ProveedorDAO();

            proveedorDAO.Insert(proveedor);

            proveedor = proveedorDAO.FindByNombre("Dell");

            proveedorDAO.Delete(proveedor);
        }

        /// <summary>
        /// Prueba de borrado de un proveedor
        /// </summary>
        [TestMethod]
        public void DeleteProveedor()
        {
            Proveedor proveedor = new Proveedor();

            proveedor.SetId(2);
            proveedor.SetNombre("Dell");
            proveedor.SetPersonaMoral(true);

            ProveedorDAO proveedorDAO = new ProveedorDAO();


            proveedorDAO.Delete(proveedor);

        }

        /// <summary>
        /// Prueba de actualizacion de un proveedor
        /// </summary>
        [TestMethod]
        public void UpdateProveedor()
        {
            Proveedor proveedor = new Proveedor();

            proveedor.SetId(3);
            proveedor.SetNombre("Asus");
            proveedor.SetPersonaMoral(true);

            ProveedorDAO proveedorDAO = new ProveedorDAO();

            proveedorDAO.Update(proveedor);
        }
    }
}
