using System;
using System.Diagnostics;
using ComprasUAQ.DAO;
using ComprasUAQ.POCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ComprasUAQTests.DAOTest
{
    [TestClass]
    public class CentroGastoDAOTest
    {
        /// <summary>
        /// Prueba de busqueda del centro de gastos por id
        /// </summary>
        [TestMethod]
        public void FindById()
        {
            CentroGastoDAO centroGastoDAO = new CentroGastoDAO();

            CentroGasto centoGasto = centroGastoDAO.FindById(18); 
        }

        /// <summary>
        /// Prueba de busqueda de todos los centros de gastos
        /// </summary>
        [TestMethod]
        public void FindAll()
        {
            CentroGastoDAO centroGastoDAO = new CentroGastoDAO();
            List<CentroGasto> centoGasto = centroGastoDAO.FindAll();
        }

        /// <summary>
        /// Prueba de insercion de un centro de gasto
        /// </summary>
        [TestMethod]
        public void InsertCentroGasto()
        {
            CentroGasto centroGasto = new CentroGasto();

            centroGasto.SetNombre("Facultad de Ciencias Políticas");

            CentroGastoDAO centroGastoDAO = new CentroGastoDAO();

            centroGastoDAO.Insert(centroGasto);

            centroGasto = centroGastoDAO.FindByNombre(centroGasto.GetNombre());

            centroGastoDAO.Delete(centroGasto);
        }

        /// <summary>
        /// Prueba de borrado de un centro de gasto
        /// </summary>
        [TestMethod]
        public void DeleteCentroGasto()
        {
            CentroGasto centroGasto = new CentroGasto();

            centroGasto.SetId(1);
            centroGasto.SetNombre("Dell S.A");

            CentroGastoDAO centroGastoDAO = new CentroGastoDAO();


            centroGastoDAO.Delete(centroGasto);
        }

        /// <summary>
        /// Prueba de actualizacion de un Centro de gasto
        /// </summary>
        [TestMethod]
        public void UpdateCentroGasto()
        {
            CentroGasto centroGasto = new CentroGasto();

            centroGasto.SetId(2);
            centroGasto.SetNombre("Asus S.A");

            CentroGastoDAO centroGastoDAO = new CentroGastoDAO();

            centroGastoDAO.Update(centroGasto);
        }
    }
}
