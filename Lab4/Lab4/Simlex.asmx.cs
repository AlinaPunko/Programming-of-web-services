using System.Web.Script.Services;
using System.Web.Services;

namespace Lab4
{
    /// <summary>
    /// Сводное описание для Simlex
    /// </summary>
    [WebService(Namespace = "http://paa", Description = "This is simplex web-service")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    [ScriptService]
    public class Simlex : WebService
    {

        [WebMethod(MessageName = "sum_1", Description = "Sum of 2 int")]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod(MessageName = "sum_2", Description = "Concatination of string and double")]
        public string Concat(string s, double d)
        {
            return s + " " + d.ToString();
        }

        [WebMethod(MessageName = "sum_3", Description = "Sum of fileds of two [A] objects. Return [A] object")]
        public A Sum(A a1, A a2)
        {
            return new A(a1.s + a2.s, a1.k + a2.k, a1.f + a2.f);
        }

        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod(MessageName = "sum_4", Description = "Sum of 2 int. Response JSON")]
        public int Adds(int x, int y)
        {
            return x + y;
        }
    }
}
