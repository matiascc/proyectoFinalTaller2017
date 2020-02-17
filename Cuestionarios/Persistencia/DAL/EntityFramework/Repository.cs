using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Npgsql;

namespace Questionnaire.DAL.EntityFramework
{
    /// <summary>
    /// Base implementation of a repository
    /// </summary>
    /// <typeparam name="TEntity">Domain entity of the repository</typeparam>
    /// <typeparam name="TDbContext">Context of the DB</typeparam>
    abstract class Repository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        protected readonly TDbContext iDbContext;

        public Repository(TDbContext pContext)
        {
            try
            {
                this.iDbContext = pContext;
            }
            catch(Exception ex)
            {
                throw new NpgsqlException(ex.ToString());
            }
        }

        /// <summary>
        /// Adds an entity
        /// </summary>
        public void Add(TEntity pEntity)
        {
            try
            {
                this.iDbContext.Set<TEntity>().Add(pEntity);
            }
            catch (Exception ex)
            {
                throw new NpgsqlException(ex.ToString());
            }
            
        }

        /// <summary>
        /// Gets the entity by its id
        /// </summary>
        public TEntity GetByID(int pId)
        {
            try
            {
                return this.iDbContext.Set<TEntity>().Find(pId);
            }
            catch (Exception ex)
            {
                throw new NpgsqlException(ex.ToString());
            }
            
        }

        /// <summary>
        /// Gets all entities
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return this.iDbContext.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                throw new NpgsqlException(ex.ToString());
            }
            
        }

        /// <summary>
        /// Elimina una entidad
        /// </summary>
        public void Remove(TEntity pEntity)
        {
            try
            {
                this.iDbContext.Set<TEntity>().Remove(pEntity);
            }
            catch (Exception ex)
            {
                throw new NpgsqlException(ex.ToString());
            }
            
        }

    }
}
