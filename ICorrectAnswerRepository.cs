using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_MVC_Datatables.Data.Repository
{
   public interface ICorrectAnswerRepository
    {
        IQueryable<CorrectAnswer> GetQuestionAnswers();
    }
}
