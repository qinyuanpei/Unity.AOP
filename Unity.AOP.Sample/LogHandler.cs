using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Unity.AOP.Sample
{
    public class LogHandler : ICallHandler
    {
        int ICallHandler.Order { get; set; }
        
        IMethodReturn ICallHandler.Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var methodInfo = input.MethodBase;
            var methodName = methodInfo.Name;
            Logger.Log(string.Format("----------开始调用{0}----------", methodName));
            var parameters = methodInfo.GetParameters();
            var result = getNext()(input,getNext);
            Logger.Log(string.Format("调用{0}的结果为：{1}", methodName,result.ReturnValue));
            Logger.Log(string.Format("----------结束调用{0}----------", methodName));
            return result;

        }
    }
}
