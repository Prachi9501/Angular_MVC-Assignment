using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_MVC_Datatables.Data.Repository
{
    public class CorrectAnswerRepository : ICorrectAnswerRepository
    {
        private MyDatabaseEntities context;

        public CorrectAnswerRepository(MyDatabaseEntities context)
        {
            this.context = context;
        }

        public IQueryable<CorrectAnswer> GetQuestionAnswers()
        {
            return context.CorrectAnswers;
        }
       
    }
}