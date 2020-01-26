using System;

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
