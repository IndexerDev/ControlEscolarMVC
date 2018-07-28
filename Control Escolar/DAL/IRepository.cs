using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Función que regresa un objeto del dominio        
        /// </summary>
        /// <param name="id">Identificador entero</param>
        /// <returns>Objeto de dominio</returns>
        TEntity Get(int id);

        /// <summary>
        /// Funcion que regresa una lista de objetos del dominio        
        /// </summary>
        /// <returns>Objetos de dominio</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Función que regresa una lista de objetos del dominio según expresión dada
        /// </summary>
        /// <param name="predicate">Expresión para navegación</param>
        /// <returns>Lista de objetos del dominio</returns>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Función sin retorno que persiste una entidad en la base de datos
        /// </summary>
        /// <param name="entity">Ingresa objeto a crear</param>
        void Add(TEntity entity);        

        /// <summary>
        /// Función que elimina un objeto de la base de datos
        /// </summary>
        /// <param name="entity">Ingresa objeto a eliminar</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Persiste el contexto con las operaciones realizadas
        /// </summary>
        void Save();        

    }
}
