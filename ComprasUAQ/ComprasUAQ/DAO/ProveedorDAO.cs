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
    public class ProveedorDAO
    {
        /// <summary>
        /// Regresa un arreglo con todos los proveedores
        /// </summary>
        /// <returns>Lista Genérica de proveedores</returns>
        public List<Proveedor> FindAll()
        {
            DAODataContext contexto = new DAODataContext();
            using (contexto)
            {
                var resultado =
                (
                    from proveedor in contexto.proveedores
                    select new Proveedor(proveedor.id_proveedor, proveedor.nombre_proveedor, proveedor.persona_moral_proveedor)
                );

                return resultado.ToList();
            }
        }

        /// <summary>
        /// Encuentra el proveedor por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Un objeto proveedor</returns>
        public Proveedor FindById(int id)
        {
            DAODataContext contexto = new DAODataContext();
            using (contexto)
            {
                var resultado =
                (
                    from proveedor in contexto.proveedores
                    where proveedor.id_proveedor == id
                    select new Proveedor(proveedor.id_proveedor, proveedor.nombre_proveedor, proveedor.persona_moral_proveedor)

                );
                return resultado.FirstOrDefault();
            }
        }

        /// <summary>
        /// Encuentra el primer proveedor que cumpla parcialmente con el nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Proveedor FindByNombre(string nombre)
        {
            DAODataContext contexto = new DAODataContext();

            using (contexto)
            {
                var resultado =
                (
                    from proveedor in contexto.proveedores
                    where proveedor.nombre_proveedor.Contains(nombre)
                    select new Proveedor(proveedor.id_proveedor, proveedor.nombre_proveedor, proveedor.persona_moral_proveedor)
                );

                return resultado.FirstOrDefault();
            }
        }

        /// <summary>
        /// Encuentra una lista de proveedores que cumplen parcialmente con el nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<Proveedor> FindAllWithNombre(string nombre)
        {
            DAODataContext contexto = new DAODataContext();

            using (contexto)
            {
                var resultado =
                (
                    from proveedor in contexto.proveedores
                    where proveedor.nombre_proveedor.Contains(nombre)
                    select new Proveedor(proveedor.id_proveedor, proveedor.nombre_proveedor, proveedor.persona_moral_proveedor)
                );

                return resultado.ToList();
            }
        }

        /// <summary>
        /// Inserta un objeto proveedor
        /// </summary>
        /// <param name="proveedor"></param>
        public int Insert(Proveedor proveedor)
        {

            proveedores proveedorTable = new proveedores
            {
                nombre_proveedor = proveedor.GetNombre(),
                persona_moral_proveedor = proveedor.EsPersonaMoral()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.proveedores.InsertOnSubmit(proveedorTable);
            contexto.SubmitChanges();
            return 0;
        }

        /// <summary>
        /// Inserta un proveedor al proporcionar los parámetros adecuados, el id es autogenerado
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="personaMoral"></param>
        public int Insert(string nombre, bool personaMoral)
        {

            proveedores proveedorTable = new proveedores
            {
                nombre_proveedor = nombre,
                persona_moral_proveedor = personaMoral
            };


            DAODataContext contexto = new DAODataContext();
            contexto.proveedores.InsertOnSubmit(proveedorTable);
            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Borra un objeto proveedor
        /// </summary>
        /// <param name="proveedor">El objeto proveedor a ser borrado</param>
        public int Delete(Proveedor proveedor)
        {
            proveedores proveedorTable = new proveedores
            {
                id_proveedor = proveedor.GetId(),
                nombre_proveedor = proveedor.GetNombre(),
                persona_moral_proveedor = proveedor.EsPersonaMoral()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.proveedores.Attach(proveedorTable);
            contexto.proveedores.DeleteOnSubmit(proveedorTable);
            contexto.SubmitChanges();
            return 0;
        }

        /// <summary>
        /// Borra un proveedor por medio del id
        /// </summary>
        /// <param name="id">El id del proveedor que se desea borrar</param>
        public int Delete(int id)
        {
            Proveedor proveedor = new Proveedor();

            proveedor = FindById(id);

            proveedores proveedorTable = new proveedores
            {
                id_proveedor = proveedor.GetId(),
                nombre_proveedor = proveedor.GetNombre(),
                persona_moral_proveedor = proveedor.EsPersonaMoral()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.proveedores.Attach(proveedorTable);
            contexto.proveedores.DeleteOnSubmit(proveedorTable);
            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Actualiza los datos del proveedor
        /// </summary>
        /// <param name="proveedor">El nuevo objeto proveedor que reemplazara al anterior</param>
        public int Update(Proveedor proveedor)
        {
            DAODataContext contexto = new DAODataContext();

            proveedores proveedorTable = contexto.proveedores.Single(proveedorRow => proveedorRow.id_proveedor == proveedor.GetId());

            proveedorTable.nombre_proveedor = proveedor.GetNombre();

            proveedorTable.persona_moral_proveedor = proveedor.EsPersonaMoral();

            contexto.SubmitChanges();

            return 0;

        }

        /// <summary>
        /// Actualiza los datos del proveedor
        /// </summary>
        /// <param name="id">El id del proveedor que se quiere cambiar</param>
        /// <param name="nombre">El nombre a cambiar</param>
        /// <param name="personaMoral">persona moral o fisica</param>
        public int Update(int id, string nombre, bool personaMoral)
        {
            DAODataContext contexto = new DAODataContext();

            proveedores proveedorTable = contexto.proveedores.Single(proveedorRow => proveedorRow.id_proveedor == id);

            proveedorTable.nombre_proveedor = nombre;

            proveedorTable.persona_moral_proveedor = personaMoral;

            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Actualiza el nombre del proveedor
        /// </summary>
        /// <param name="nombreActual">El nombre que actualmente tiene el proveedor</param>
        /// <param name="nombreNuevo">El nombre por el que se quiere cambiar</param>
        public int UpdateNombre(string nombreActual, string nombreNuevo)
        {
            DAODataContext contexto = new DAODataContext();

            proveedores proveedorTable = contexto.proveedores.Single(proveedorRow => proveedorRow.nombre_proveedor == nombreActual);

            proveedorTable.nombre_proveedor = nombreNuevo;

            contexto.SubmitChanges();

            return 0;
        }


    }
}
