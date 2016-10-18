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
    public class RemitenteDAO
    {
        /// <summary>
        /// Busqueda de un remitente por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Remitente FindById(int id)
        {
            DAODataContext contexto = new DAODataContext();
            using (contexto)
            {
                var resultado =
                (
                    from remitente in contexto.remitentes
                    where remitente.id_remitente == id
                    select new Remitente(remitente.id_remitente, remitente.nombre_remitente, 
                        remitente.apellido_paterno_remitente, remitente.apellido_materno_remitente)
                );
                return resultado.FirstOrDefault();
            }
        }

        /// <summary>
        /// Busqueda de todos los remitentes
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Remitente> FindAll()
        {
            DAODataContext contexto = new DAODataContext();
            using (contexto)
            {
                var resultado =
                (
                    from remitente in contexto.remitentes
                    select new Remitente(remitente.id_remitente, remitente.nombre_remitente, 
                        remitente.apellido_paterno_remitente, remitente.apellido_materno_remitente)
                );

                return resultado.ToList();
            }
        }
        /// <summary>
        /// Encuentra el primer remitente que cumpla parcialmente con el nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Remitente FindByNombre(string nombre)
        {
            DAODataContext contexto = new DAODataContext();

            using (contexto)
            {
                var resultado =
                (
                    from remitentes in contexto.remitentes
                    where remitentes.nombre_remitente.Contains(nombre)
                    select new Remitente(remitentes.id_remitente,remitentes.nombre_remitente,remitentes.apellido_paterno_remitente,remitentes.apellido_materno_remitente)
                );

                return resultado.FirstOrDefault();
            }
        }

        /// <summary>
        /// Encuentra una lista de remitentes que cumplen parcialmente con el nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public List<Remitente> FindAllWithNombre(string nombre)
        {
            DAODataContext contexto = new DAODataContext();

            using (contexto)
            {
                var resultado =
                (
                    from remitentes in contexto.remitentes
                    where remitentes.nombre_remitente.Contains(nombre)
                    select new Remitente(remitentes.id_remitente, remitentes.nombre_remitente, remitentes.apellido_paterno_remitente, remitentes.apellido_materno_remitente)
                );

                return resultado.ToList();
            }
        }

        /// <summary>
        /// Inserta un objeto remitente
        /// </summary>
        /// <param name="remitente"></param>
        public int Insert(Remitente remitente)
        {

            remitentes remitenteTable = new remitentes
            {
                nombre_remitente = remitente.GetNombre(),
                apellido_paterno_remitente = remitente.GetApellidoPaterno(),
                apellido_materno_remitente = remitente.GetApellidoMaterno()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.remitentes.InsertOnSubmit(remitenteTable);
            contexto.SubmitChanges();
            return 0;
        }

        /// <summary>
        /// Inserta un remitente al proporcionar los parámetros adecuados, el id es autogenerado
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido_paterno"></param>
        /// <param name="apellido_materno"></param>
        /// <returns>string, string, string</returns>
        public int Insert(string nombre, string apellido_paterno, string apellido_materno)
        {

            remitentes remitenteTable = new remitentes
            {
                nombre_remitente = nombre,
                apellido_paterno_remitente = apellido_paterno,
                apellido_materno_remitente = apellido_materno
            };


            DAODataContext contexto = new DAODataContext();
            contexto.remitentes.InsertOnSubmit(remitenteTable);
            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Borra un objeto remitente
        /// </summary>
        /// <param name="pro">El objeto remitente a ser borrado</param>
        public int Delete(Remitente remitente)
        {
            remitentes remitenteTable = new remitentes
            {
                id_remitente = remitente.GetId(),
                nombre_remitente = remitente.GetNombre(),
                apellido_paterno_remitente = remitente.GetApellidoPaterno(),
                apellido_materno_remitente = remitente.GetApellidoMaterno()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.remitentes.Attach(remitenteTable);
            contexto.remitentes.DeleteOnSubmit(remitenteTable);
            contexto.SubmitChanges();
            return 0;
        }

        /// <summary>
        /// Borra un remitente por medio del id
        /// </summary>
        /// <param name="id">El id del remitente que se desea borrar</param>
        public int Delete(int id)
        {
            Remitente remitente = new Remitente();

            remitente = FindById(id);

            remitentes remitenteTable = new remitentes
            {
                id_remitente = remitente.GetId(),
                nombre_remitente = remitente.GetNombre(),
                apellido_paterno_remitente = remitente.GetApellidoPaterno(),
                apellido_materno_remitente = remitente.GetApellidoMaterno()
            };


            DAODataContext contexto = new DAODataContext();
            contexto.remitentes.Attach(remitenteTable);
            contexto.remitentes.DeleteOnSubmit(remitenteTable);
            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Actualiza los datos del remitente
        /// </summary>
        /// <param name="comprador">El nuevo objeto remitente que reemplazara al anterior</param>
        public int Update(Remitente remitente)
        {
            DAODataContext contexto = new DAODataContext();

            remitentes remitenteTable = contexto.remitentes.Single(remitenteRow => remitenteRow.id_remitente == remitente.GetId());

            remitenteTable.nombre_remitente = remitente.GetNombre();
            remitenteTable.apellido_paterno_remitente = remitente.GetApellidoPaterno();
            remitenteTable.apellido_materno_remitente = remitente.GetApellidoMaterno();


            contexto.SubmitChanges();

            return 0;

        }

        /// <summary>
        /// Se actualizan los datos del remitente
        /// </summary>
        /// <param name="id">El id del remitente que se quiere cambiar</param>
        /// <param name="nombre">el nombre a cambiar</param>
        /// <param name="apellido_paterno">el apellido paterno a cambiar</param>
        /// <param name="apellido_materno">el apelllido materno a cambiar</param>
        /// <returns></returns>
        public int Update(int id, string nombre, string apellido_paterno, string apellido_materno)
        {
            DAODataContext contexto = new DAODataContext();

            remitentes remitenteTable = contexto.remitentes.Single(remitenteRow => remitenteRow.id_remitente == id);

            remitenteTable.nombre_remitente = nombre;
            remitenteTable.apellido_paterno_remitente = apellido_paterno;
            remitenteTable.apellido_materno_remitente = apellido_materno;

            contexto.SubmitChanges();

            return 0;
        }

        /// <summary>
        /// Actualiza el nombre del remitente
        /// </summary>
        /// <param name="nombreActual">El nombre que actualmente tiene el remitente</param>
        /// <param name="nuevoNombre">El nombre por el que se quiere cambiar</param>
        public int Update(string nombreActual, string nuevoNombre)
        {
            DAODataContext contexto = new DAODataContext();

           remitentes remitenteTable = contexto.remitentes.Single(remitenteRow => remitenteRow.nombre_remitente == nombreActual);

            remitenteTable.nombre_remitente = nuevoNombre;

            contexto.SubmitChanges();

            return 0;
        }

    }
}
