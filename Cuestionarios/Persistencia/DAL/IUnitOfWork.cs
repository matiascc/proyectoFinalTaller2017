using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.DAL
{
    interface IUnitOfWork : IDisposable
    {
        void Complete();
        IUserRepository UserRepository { get; }
        ISetRepository SetRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IOptionRepository OptionRepository { get; }
    }
}
