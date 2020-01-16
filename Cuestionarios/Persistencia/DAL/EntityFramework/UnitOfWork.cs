using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly QuestionnaireDbContext iDbContext;

        public UnitOfWork(QuestionnaireDbContext pContext)
        {
            if (pContext == null)
            {
                throw new ArgumentNullException(nameof(pContext));
            }

            this.iDbContext = pContext;
            this.UserRepository = new UserRepository(this.iDbContext);
            this.SetRepository = new SetRepository(this.iDbContext);
            this.QuestionRepository = new QuestionRepository(this.iDbContext);
            this.OptionRepository = new OptionRepository(this.iDbContext);
        }

        /// <summary>
        /// Repositorio de usuarios
        /// </summary>
        public IUserRepository UserRepository { get; private set; }

        /// <summary>
        /// Repositorio de sets de preguntas
        /// </summary>
        public ISetRepository SetRepository { get; private set; }

        /// <summary>
        /// Repositorio de preguntas
        /// </summary>
        public IQuestionRepository QuestionRepository { get; private set; }

        /// <summary>
        /// Repositorio de respuestas
        /// </summary>
        public IOptionRepository OptionRepository { get; private set; }


        /// <summary>
        /// Persiste los cambios
        /// </summary>
        public void Complete()
        {
            this.iDbContext.SaveChanges();
        }

        /// <summary>
        /// Elimina los recursos tomados
        /// </summary>
        public void Dispose()
        {
            this.iDbContext.Dispose();
        }
        
    }
}
