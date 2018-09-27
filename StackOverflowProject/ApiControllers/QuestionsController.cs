using StackOverflowProject.ServiceLayer;
using System.Web.Http;

namespace StackOverflowProject.ApiControllers
{
    public class QuestionsController : ApiController
    {
        IAnswersService asr;

        public QuestionsController(IAnswersService asr)
        {
            this.asr = asr;
        }

        public void Post(int AnswerID, int UserID, int value)
        {
            this.asr.UpdateAnswerVotesCount(AnswerID, UserID, value);
        }
    }
}