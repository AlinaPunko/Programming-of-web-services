using Lab8.Models;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace Lab8.Controllers
{
    public class JRPCController : ApiController
    {

        [HttpPost]
        [Route("api/JRPC/Single")]
        public object Single(ReqJsonRPC body)
        {
            if (HttpContext.Current.Session["MethodsIgnore"] != null && (bool)HttpContext.Current.Session["MethodsIgnore"] == true)
                return getError(body.Id, body.Jsonrpc, "Methods are don't available");

            string method = body.Method;
            ISM param = body.Params;
            string key = param.Key;
            int value = int.Parse(param.Value == null || param.Value == "" ? "0" : param.Value); // default value = 0
            int? result = null;

            switch (method)
            {
                case "SetM":
                    {
                        result = SetM(key, value);
                        break;
                    }
                case "GetM":
                    {
                        result = GetM(key);
                        break;
                    }
                case "AddM":
                    {
                        result = AddM(key, value);
                        break;
                    }
                case "SubM":
                    {
                        result = SubM(key, value);
                        break;
                    }
                case "MulM":
                    {
                        result = MulM(key, value);
                        break;
                    }
                case "DivM":
                    {
                        result = DivM(key, value);
                        break;
                    }
                case "ErrorExit":
                    {
                        ErrorExit();
                        break;
                    }
                default:
                    {
                        return getError(body.Id, body.Jsonrpc, string.Format("Function {0} is not found", body.Method));
                    }
            }
            return new ResJsonRPC()
            {
                Id = body.Id,
                Jsonrpc = body.Jsonrpc,
                Method = body.Method,
                Result = result
            };
        }

        [HttpPost]
        [Route("api/JRPC/Multiple")]
        public object[] Multi(ReqJsonRPC[] body)
        {
            int length = body.Length;
            object[] result = new object[length];

            for (int i = 0; i < length; i++)
                result[i] = Single(body[i]);

            return result;
        }

        private ResJsonRPCError getError(string id, string jsonrpc, string message)
        {
            return new ResJsonRPCError()
            {
                Id = id,
                Jsonrpc = jsonrpc,
                Error = message
            };
        }

        private int? SetM(string k, int x)
        {
            HttpContext.Current.Session.Add(k, x);
            return GetM(k);
        }

        private int? GetM(string k)
        {
            object result = HttpContext.Current.Session[k];

            if (result == null)
                return null;
            else
                return int.Parse(result.ToString());
        }

        private int? AddM(string k, int x)
        {
            int? value = GetM(k);
            HttpContext.Current.Session[k] = value == null ? x : value + x;
            return GetM(k);
        }

        private int? SubM(string k, int x)
        {
            int? value = GetM(k);
            HttpContext.Current.Session[k] = value == null ? x : value - x;
            return GetM(k);
        }

        private int? MulM(string k, int x)
        {
            int? value = GetM(k);
            HttpContext.Current.Session[k] = value == null ? x : value * x;
            return GetM(k);
        }

        private int? DivM(string k, int x)
        {
            int? value = GetM(k);
            HttpContext.Current.Session[k] = value == null ? x : value / x;
            return GetM(k);
        }

        private void ErrorExit()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session["MethodsIgnore"] = true;
        }
    }
}
