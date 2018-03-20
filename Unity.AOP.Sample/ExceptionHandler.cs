using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Unity.AOP.Sample
{
    public class ExceptionHandler : ICallHandler
    {
        int ICallHandler.Order { get; set; }

        public string ErrorCode { get; set; }


        IMethodReturn ICallHandler.Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            var methodInfo = input.MethodBase;
            var methodName = methodInfo.Name;
            Logger.Log(string.Format("--------------方法{0}执行开始--------------", methodName));
            var result = getNext()(input, getNext);
            if (result.Exception != null)
            {
                Logger.Log(string.Format("Error Code is {0}", ErrorCode));
                result.Exception = null;
                Logger.Log(string.Format("--------------方法{0}执行结束--------------", methodName));
                throw new Exception(ErrorCode);
            }
            Logger.Log(string.Format("--------------方法{0}执行结束--------------", methodName));
            return result;
        }
    }
}
