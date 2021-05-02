using ASPNET_MVC_Datatables.Data;
using ASPNET_MVC_Datatables.Data.Repository;
using ASPNET_MVC_Datatables.Models.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPNET_MVC_Datatables.API
{
    public class CorrectAnswerController : ApiController
    {
        private ICorrectAnswerRepository correctAnswerRepository;

        public CorrectAnswerController()
        {
            this.correctAnswerRepository = new CorrectAnswerRepository(new MyDatabaseEntities());
        }

        [HttpGet]
        [Route("api/Answer")]
        public DataTableResponse GetQuestionAnswers()
        {
            var answer = correctAnswerRepository.GetQuestionAnswers();

            return new DataTableResponse
            {
                recordsTotal = answer.Count(),
                recordsFiltered = 10,
                data = answer.Take(10).ToArray()
            };
        }
    }
}
