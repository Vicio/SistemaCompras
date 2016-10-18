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
    public class CompradorDAO
    {
        /// <summary>
        /// Encuentra al comprador por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>un objeto comprador</returns>
        public Comprador FindById(int id)
        {
            DAODataContext contexto = new DAODataContext();

            using (contexto)
            {
                var resultado =
                (
                    from comprador in contexto.compradores
                    where comprador.id_comprador == id
                    select new Comprador(comprador.id_comprador, comprador.nombre_comprador,comprador.apellido_paterno_comprador,comprador.apellido_materno_comprador)

                );
                return resultado.FirstOrDefault();

            }
        }
 
        /// <summary>
        /// Regresa un arreglo con todos los compradores
        /// </summary>
        /// <returns>Lista Genérica Comprador</returns>
        public List<Comprador> FindAll()
        {
            DAODataContext contexto = new DAODataContext();
            using (contexto)
            {
                var resultado =
                (
                    from comprador in contexto.compradores
                    select new Comprador(comprador.id_comprador, comprador.nombre_comprador, comprador.apellido_paterno_comprador, comprador.apellido_materno_comprador)
                );

                return resultado.ToList();
            }
        }

        /// <summary>
        /// Encuentra el primer proveedor que cumpla parcialmente con el nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Comprador FindByNombre(string nombre)
        {
            DAODataContext contexto = new DAODataContext();

            using (contexto)
            {
                var resultado =
                (
                    from comprador in contexto.compradores
                    where comprador.nombre_comprador.Contains(nombre)
                    select new Comprador(comprador.id_comprador, comprador.nombre_comprador, comprador.apellido_paterno_comprador, comprador.apellido_materno_comprador)
                );

                return resultado.FirstOrDefault();
            }
        }

        /// <summary>
        /// Encuentra una lista de proveedores que cumplen parcialmente con el nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<Comprador> FindAllWithNombre(string nombre)
        {
            DAODataContext contexto = new DAODataContext();

            using (contexto)
            {
                var resultado =
                (
                    from comprador in contexto.compradores
                    where comprador.nombre_comprador.Contains(nombre)
                    select new Comprador(comprador.id_comprador, comprador.nombre_comprador, comprador.apellido_paterno_comprador, comprador.apellido_materno_comprador)
                );

                return resultado.ToList();
            }
        }

        /// <summary>
        /// Inserta un objeto comprador
        /// </summary>
        /// <param name="comprador"></param>
        public int Insert(Comprador comprador)
        {

            compradores compradorTable = new compradores
            {
                nombre_comprador = comprador.GetNombre(),
                apellido_paterno_comprador = comprador.GetApellidoPaterno(),
                apellido_materno_comprador = comprador.GetApellidoMaterno()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.compradores.InsertOnSubmit(compradorTable);
            contexto.SubmitChanges();
            return 0;
        }

        /// <summary>
        /// Inserta un comprador al proporcionar los parámetros adecuados, el id es autogenerado
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido_paterno"></param>
        /// <param name="apellido_materno"></param>
        /// <returns>string, string, string</returns>
        public int Insert(string nombre, string apellido_paterno, string apellido_materno)
        {

            compradores compradorTable = new compradores
            {
                nombre_comprador = nombre,
                apellido_paterno_comprador = apellido_paterno,
                apellido_materno_comprador = apellido_materno
            };


            DAODataContext contexto = new DAODataContext();
            contexto.compradores.InsertOnSubmit(compradorTable);
            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Borra un objeto comprador
        /// </summary>
        /// <param name="pro">El objeto comprador a ser borrado</param>
        public int Delete(Comprador comprador)
        {
            compradores compradorTable = new compradores
            {
                id_comprador = comprador.GetId(),
                nombre_comprador = comprador.GetNombre(),
                apellido_paterno_comprador = comprador.GetApellidoPaterno(),
                apellido_materno_comprador = comprador.GetApellidoMaterno()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.compradores.Attach(compradorTable);
            contexto.compradores.DeleteOnSubmit(compradorTable);
            contexto.SubmitChanges();
            return 0;
        }

        /// <summary>
        /// Borra un comprador por medio del id
        /// </summary>
        /// <param name="id">El id del comprador que se desea borrar</param>
        public int Delete(int id)
        {
            Comprador comprador = new Comprador();

            comprador = FindById(id);

            compradores compradorTable = new compradores
            {
                id_comprador = comprador.GetId(),
                nombre_comprador = comprador.GetNombre(),
                apellido_paterno_comprador = comprador.GetApellidoPaterno(),
                apellido_materno_comprador = comprador.GetApellidoMaterno()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.compradores.Attach(compradorTable);
            contexto.compradores.DeleteOnSubmit(compradorTable);
            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Actualiza los datos del comprador
        /// </summary>
        /// <param name="comprador">El nuevo objeto comprador que reemplazara al anterior</param>
        public int Update(Comprador comprador)
        {
            DAODataContext contexto = new DAODataContext();

            compradores compradorTable = contexto.compradores.Single(compradorRow => compradorRow.id_comprador == comprador.GetId());

            compradorTable.nombre_comprador = comprador.GetNombre();
            compradorTable.apellido_paterno_comprador = comprador.GetApellidoPaterno();
            compradorTable.apellido_materno_comprador = comprador.GetApellidoMaterno();


            contexto.SubmitChanges();

            return 0;

        }

        /// <summary>
        /// Se actualizan los datos del comprador
        /// </summary>
        /// <param name="id">El id del comprador que se quiere cambiar</param>
        /// <param name="nombre">el nombre a cambiar</param>
        /// <param name="apellido_paterno">el apellido paterno a cambiar</param>
        /// <param name="apellido_materno">el apelllido materno a cambiar</param>
        /// <returns></returns>
        public int Update(int id, string nombre, string apellido_paterno, string apellido_materno)
        {
            DAODataContext contexto = new DAODataContext();

            compradores compradorTable = contexto.compradores.Single(compradorRow => compradorRow.id_comprador == id);

            compradorTable.nombre_comprador = nombre;
            compradorTable.apellido_paterno_comprador = apellido_paterno;
            compradorTable.apellido_materno_comprador = apellido_materno;

            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Actualiza el nombre del comprador
        /// </summary>
        /// <param name="nombreActual">El nombre que actualmente tiene el comprador</param>
        /// <param name="nuevoNombre">El nombre por el que se quiere cambiar</param>
        public int Update(string nombreActual, string nuevoNombre)
        {
            DAODataContext contexto = new DAODataContext();

            compradores compradorTable = contexto.compradores.Single(compradorRow => compradorRow.nombre_comprador == nombreActual);

            compradorTable.nombre_comprador = nuevoNombre;

            contexto.SubmitChanges();

            return 0;
        }

    }
}
