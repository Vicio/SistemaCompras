using System;
using System.Diagnostics;
using ComprasUAQ.DAO;
using ComprasUAQ.POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ComprasUAQTests.DAOTest
{
        [TestClass]
        public class RemitenteDAOTest
        {
            /// <summary>
            /// Prueba de busqueda del remitente por id
            /// </summary>
            [TestMethod]
            public void FindById()
            {
                RemitenteDAO remitenteDAO = new RemitenteDAO();

                Remitente remitente = remitenteDAO.FindById(76);
            }
            
            /// <summary>
            /// Prueba de busqueda de todos los remitentes
            /// </summary>
            [TestMethod]
            public void FindAll()
            {
                RemitenteDAO remitenteDAO = new RemitenteDAO();

                List<Remitente> remitente = remitenteDAO.FindAll();
            }

        /// <summary>
        /// Prueba de insercion de un remitente
        /// </summary>
        [TestMethod]
        public void InsertRemitente()
        {
            Remitente remitente = new Remitente();

            remitente.SetNombre("Alvaro");
            remitente.SetApellidoPaterno("Salvador");
            remitente.SetApellidoMaterno("Hernandez");

            RemitenteDAO remitenteDAO = new RemitenteDAO();

            remitenteDAO.Insert(remitente);
        }

        /// <summary>
        /// Prueba de borrado de un remitente
        /// </summary>
        [TestMethod]
        public void DeleteRemitente()
        {
            Remitente remitente= new Remitente();

            remitente.SetId(2);
            remitente.SetNombre("Alvaro");
            remitente.SetApellidoPaterno("Salvador");
            remitente.SetApellidoMaterno("Hernandez");

            RemitenteDAO remitenteDAO = new RemitenteDAO();


            remitenteDAO.Delete(remitente);

        }

        /// <summary>
        /// Prueba de actualizacion de un remitente
        /// </summary>
        [TestMethod]
        public void UpdateRemitente()
        {
            Remitente remitente = new Remitente();

            remitente.SetId(1);
            remitente.SetNombre("Alvaro");
            remitente.SetApellidoPaterno("Salvador");
            remitente.SetApellidoMaterno("Hernandez");

            RemitenteDAO remitenteDAO = new RemitenteDAO();

            remitenteDAO.Update(remitente);
        }

    }
}
