using System.Collections.Generic;
using System.Linq;
using ComprasUAQ.DataSets;
using ComprasUAQ.POCO;

namespace ComprasUAQ.DAO
{
    public class CentroGastoDAO
    {
        /// <summary>
        /// Busqueda de todos los centros de gasto
        /// </summary>
        /// <returns>Lista generica de centros de gasto</returns>
        public List<CentroGasto> FindAll()
        {
            DAODataContext contexto = new DAODataContext();
            using (contexto)
            {

                var resultado =
                (
                    from centroGasto in contexto.centros_gastos
                    select new CentroGasto(centroGasto.id_centro_gasto, centroGasto.nombre_centro_gasto)

                );
                return resultado.ToList();
            }
        }

        /// <summary>
        /// Busqueda de centro de gasto por id
        /// </summary>
        /// <param name="id">El id del centro de gasto</param>
        /// <returns>El centro de gasto correspondiente al id</returns>
        public CentroGasto FindById(int id)
        {
            DAODataContext contexto = new DAODataContext();
            using (contexto)
            {

                var resultado =
                (
                    from centroGasto in contexto.centros_gastos
                    where centroGasto.id_centro_gasto == id
                    select new CentroGasto(centroGasto.id_centro_gasto, centroGasto.nombre_centro_gasto)

                );
                return resultado.FirstOrDefault();
            }

        }

        /// <summary>
        /// Encuentra el primer centro de gasto que cumpla parcialmente con el nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public CentroGasto FindByNombre(string nombre)
        {
            DAODataContext contexto = new DAODataContext();

            using (contexto)
            {
                var resultado =
                (
                    from centroGasto in contexto.centros_gastos
                    where centroGasto.nombre_centro_gasto.Contains(nombre)
                    select new CentroGasto(centroGasto.id_centro_gasto, centroGasto.nombre_centro_gasto)
                );

                return resultado.FirstOrDefault();
            }
        }

        /// <summary>
        /// Encuentra una lista de centros de gasto que cumplen parcialmente con el nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<CentroGasto> FindAllWithNombre(string nombre)
        {
            DAODataContext contexto = new DAODataContext();

            using (contexto)
            {
                var resultado =
                (
                    from centroGasto in contexto.centros_gastos
                    where centroGasto.nombre_centro_gasto.Contains(nombre)
                    select new CentroGasto(centroGasto.id_centro_gasto, centroGasto.nombre_centro_gasto)
                );

                return resultado.ToList();
            }
        }

        /// <summary>
        /// Inserta un objeto CentroGasto
        /// </summary>
        /// <param name="centroGasto">El centro de gasto a insertar</param>
        public int Insert(CentroGasto centroGasto)
        {
            centros_gasto centroGastoTable = new centros_gasto
            {
                nombre_centro_gasto = centroGasto.GetNombre()
            };

            DAODataContext contexto = new DAODataContext();
            contexto.centros_gastos.InsertOnSubmit(centroGastoTable);
            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Inserta un centro de gastos al proporcionar los parametros adecuados 
        /// </summary>
        /// <param name="nombre">El nombre del centro de gsto a insertar</param>
        public int Insert(string nombre)
        {

            centros_gasto centroGastoTable = new centros_gasto
            {
                nombre_centro_gasto = nombre
            };


            DAODataContext contexto = new DAODataContext();
            contexto.centros_gastos.InsertOnSubmit(centroGastoTable);
            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Borra un objeto CentroGasto
        /// </summary>
        /// <param name="centroGasto">El centro de gasto a borrar</param>
        public int Delete(CentroGasto centroGasto)
        {
            centros_gasto centroGastoTable = new centros_gasto
            {
                id_centro_gasto = centroGasto.GetId(),
                nombre_centro_gasto = centroGasto.GetNombre()                
            };

            DAODataContext contexto = new DAODataContext();
            contexto.centros_gastos.Attach(centroGastoTable);
            contexto.centros_gastos.DeleteOnSubmit(centroGastoTable);
            contexto.SubmitChanges();
            return 0;
        }

        /// <summary>
        /// Borra un centro de gastos por medio del id
        /// </summary>
        /// <param name="id">El id del centro de gasto a borrar</param>
        public int Delete(int id)
        {
            CentroGasto centroGasto = new CentroGasto();

            centroGasto = FindById(id);

            centros_gasto centroGastoTable = new centros_gasto
            {
                id_centro_gasto = centroGasto.GetId(),
                nombre_centro_gasto = centroGasto.GetNombre()
            };

            DAODataContext contexto = new DAODataContext();
            contexto.centros_gastos.Attach(centroGastoTable);
            contexto.centros_gastos.DeleteOnSubmit(centroGastoTable);
            contexto.SubmitChanges();
            return 0;
        }

        /// <summary>
        /// Actualiza los datos del centro de gastos
        /// </summary>
        /// <param name="centroGasto">El centro de gasto a actualizar (con los nuevos datos)</param>
        public int Update(CentroGasto centroGasto)
        {
            DAODataContext contexto = new DAODataContext();

            centros_gasto centroGastoTable = contexto.centros_gastos.Single(centroGastoRow => centroGastoRow.id_centro_gasto == centroGasto.GetId());

            centroGastoTable.nombre_centro_gasto = centroGasto.GetNombre();

            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Actualiza los datos del centro de gastos
        /// </summary>
        /// <param name="id">El id del centro de gasto</param>
        /// <param name="nombre">El nombre a cambiar del centro de gasto</param>
        public int Update(int id, string nombre)
        {
            DAODataContext contexto = new DAODataContext();

            centros_gasto centroGastoTable = contexto.centros_gastos.Single(centroGastoRow => centroGastoRow.id_centro_gasto == id);

            centroGastoTable.nombre_centro_gasto = nombre;

            contexto.SubmitChanges(); 

            return 0;
        }

        /// <summary>
        /// Actualizar los datos de centro de gastos
        /// </summary>
        /// <param name="nombreActual">El nombre que tiene actualmente el centro de gasto</param>
        /// <param name="nombreNuevo">El nuevo nombre del centro de gasto</param>
        public int Update(string nombreActual, string nombreNuevo)
        {
            DAODataContext contexto = new DAODataContext();

            centros_gasto centroGastoTable = contexto.centros_gastos.Single(centroGastoRow => centroGastoRow.nombre_centro_gasto == nombreActual);

            centroGastoTable.nombre_centro_gasto = nombreNuevo;

            contexto.SubmitChanges();
            return 0;
        }
    }
}
