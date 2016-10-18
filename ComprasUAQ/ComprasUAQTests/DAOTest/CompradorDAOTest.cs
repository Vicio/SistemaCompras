using System;
using System.Diagnostics;
using ComprasUAQ.DAO;
using ComprasUAQ.POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ComprasUAQTests.DAOTest
{
    [TestClass]
    class CompradorDAOTest
    {
        /// <summary>
        /// Prueba de busqueda del comprador por id
        /// </summary>
        [TestMethod]
        public void FindById()
        {
            CompradorDAO compradorDAO = new CompradorDAO();
            Comprador comprador = compradorDAO.FindById(45); 

        }

        /// <summary>
        /// Prueba de busqueda de todos los Compradores
        /// </summary>
        [TestMethod]
        public void FindAll()
        {
            CompradorDAO compradorDAO = new CompradorDAO();
            List<Comprador> comprador = compradorDAO.FindAll();

        }

        /// <summary>
        /// Prueba de insercion de un comprador
        /// </summary>
        [TestMethod]
        public void InsertComprador()
        {
            Comprador comprador = new Comprador();

            comprador.SetNombre("Ricardo");
            comprador.SetApellidoPaterno("Pizano");
            comprador.SetApellidoMaterno("Perez");

            CompradorDAO compradorDAO = new CompradorDAO();

            compradorDAO.Insert(comprador);


        }

        /// <summary>
        /// Prueba de borrado de un comprador
        /// </summary>
        [TestMethod]
        public void DeleteComprador()
        {
            Comprador comprador = new Comprador();

            comprador.SetId(7);
            comprador.SetNombre("Ricardo");
            comprador.SetApellidoPaterno("Pizano");
            comprador.SetApellidoMaterno("Perez");

            CompradorDAO compradorDAO = new CompradorDAO();


            compradorDAO.Delete(comprador);

        }

        /// <summary>
        /// Prueba de actualizacion de un comprador
        /// </summary>
        [TestMethod]
        public void UpdateComprador()
        {
            Comprador comprador = new Comprador();

            comprador.SetId(7);
            comprador.SetNombre("Antonio");
            comprador.SetApellidoPaterno("Palacios");
            comprador.SetApellidoMaterno("Perez");

            CompradorDAO compradorDAO = new CompradorDAO();

            compradorDAO.Update(comprador);
        }
    }
}
