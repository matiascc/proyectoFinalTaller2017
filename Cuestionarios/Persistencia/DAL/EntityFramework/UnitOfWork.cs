using System;
using Npgsql;

namespace Questionnaire.DAL.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly QuestionnaireDbContext iDbContext;

        public UnitOfWork(QuestionnaireDbContext pContext)
        {
            this.iDbContext = pContext ?? throw new ArgumentNullException(nameof(pContext));

            this.UserRepository = new UserRepository(this.iDbContext);
            this.SetRepository = new SetRepository(this.iDbContext);
            this.QuestionRepository = new QuestionRepository(this.iDbContext);
            this.OptionRepository = new OptionRepository(this.iDbContext);
        }

        //Repositories of the DB
        public IUserRepository UserRepository { get; private set; }
        public ISetRepository SetRepository { get; private set; }
        public IQuestionRepository QuestionRepository { get; private set; }
        public IOptionRepository OptionRepository { get; private set; }


        /// <summary>
        /// Persist the changes
        /// </summary>
        public void Complete()
        {
            try
            {
                this.iDbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new NpgsqlException("Coudn't save changes to the database", ex);
            }
        }

        /// <summary>
        /// Delete the resources taken
        /// </summary>
        public void Dispose()
        {
            this.iDbContext.Dispose();
        }
        
    }
}
