using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace Lab1Service
{
    public class Handler : IHttpHandler, IRequiresSessionState
    {
        public static int result;
        public static Stack<int> stack = new Stack<int>();
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            switch (context.Request.HttpMethod)
            {
                case "GET":
                    {
                        context.Response.Write(JsonConvert.SerializeObject(new
                        {
                            result
                        }));
                    };
                    break;
                case "POST":
                    {
                        result = Convert.ToInt32(context.Request.Form["result"]);
                    };
                    break;
                case "PUT":
                    {
                        var stack = (Stack<int>)context.Session["stack"];
                        if (stack == null)
                        {
                            stack = new Stack<int>();
                        }
                        stack.Push(Convert.ToInt32(context.Request.Form["result"]));
                        result += stack.Peek();
                        context.Session.Add("stack", stack);
                    };
                    break;
                case "DELETE":
                    {
                        var stack = (Stack<int>)context.Session["stack"];
                        if (stack != null)
                        {
                            result -= stack.Pop();
                            result += stack.Peek();
                            context.Session.Add("stack", stack);
                        }
                        else
                        {
                            context.Session.Add("stack", new Stack<int>() { });
                        }
                    };
                    break;
            }
        }
    }
}