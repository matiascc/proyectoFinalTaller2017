using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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
            this.iDbContext = pContext; 
        }

        /// <summary>
        /// Adds an entity
        /// </summary>
        public void Add(TEntity pEntity)
        {
            this.iDbContext.Set<TEntity>().Add(pEntity);
        }

        /// <summary>
        /// Gets the entity by its id
        /// </summary>
        public TEntity GetByID(int pId)
        {
            return this.iDbContext.Set<TEntity>().Find(pId);
        }

        /// <summary>
        /// Gets all entities
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            return this.iDbContext.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Elimina una entidad
        /// </summary>
        public void Remove(TEntity pEntity)
        {
            this.iDbContext.Set<TEntity>().Remove(pEntity);
        }

    }
}
