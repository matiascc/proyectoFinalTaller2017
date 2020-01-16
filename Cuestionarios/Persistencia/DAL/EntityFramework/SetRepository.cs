﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questionnaire.Domain;

namespace Questionnaire.DAL.EntityFramework
{
    class SetRepository : Repository<Set, QuestionnaireDbContext>, ISetRepository
    {
        public SetRepository(QuestionnaireDbContext pContext) : base(pContext)
        {
            
        }
    }
}