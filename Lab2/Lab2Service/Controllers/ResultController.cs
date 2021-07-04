using System.Collections.Concurrent;
using System.Web.Http;

namespace Lab2Service.Controllers
{
    public class ResultController : ApiController
    {
        private static int _intResult;
        private static ConcurrentStack<int> IntStack = new ConcurrentStack<int>();

        public IHttpActionResult Get()
        {
            return Json(new {result = _intResult});
        }

        public void Post([FromBody] string result)
        {
            _intResult = int.Parse(result);
        }

        public void Put([FromBody] string result)
        {
            IntStack.Push(int.Parse(result));
            _intResult += int.Parse(result);
        }

        public void Delete()
        {
            if (IntStack.Count != 0)
            {
                IntStack.TryPop(out int popped);
                _intResult -= popped;
                IntStack.TryPeek(out int peeked);
                _intResult += peeked;
            }
        }
    }
}
