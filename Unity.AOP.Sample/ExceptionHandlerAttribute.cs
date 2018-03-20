using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Unity.AOP.Sample;

namespace Unity.AOP.Sample
{
    class ExceptionHandlerAttribute : HandlerAttribute
    {
        public string ErrorCode { get; set; }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new ExceptionHandler() { ErrorCode = ErrorCode };
        }
    }
}
