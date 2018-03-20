using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Unity.AOP.Sample
{
    class Program : MarshalByRefObject
    {
        static void Main(string[] args)
        {
            //var container = new UnityContainer();
            //container.RegisterType<IBussiness, Bussiness>(
            //    new Interceptor<InterfaceInterceptor>()
            //);

            // Unity AOP演示代码
            var container = new UnityContainer().AddNewExtension<Interception>().RegisterType<IBussiness, Bussiness>();
            container.Configure<Interception>().SetInterceptorFor<IBussiness>(new InterfaceInterceptor());
            var bussiness = container.Resolve<IBussiness>();
            Console.WriteLine(bussiness.Add(12, 23));
            try
            {
                bussiness.Test();
            }
            catch (Exception ex)
            {

            }

            //AppSetting自动Map演示
            var setting = AppSetting.GetInstance();

            var testStr = "Hello World\0";
            var bytes = Encoding.ASCII.GetBytes(testStr);
            var newStr = Encoding.ASCII.GetString(bytes);
            Console.WriteLine("ASCII:" + newStr.Length);
            var newStr2 = Encoding.Default.GetString(bytes);
            Console.WriteLine("Default:" + newStr2.Length);
            Console.WriteLine(setting.Key001);
            Console.WriteLine(setting.Key002);
            Console.ReadKey();
        }


    }

    public interface IBussiness
    {

        int Add(int a, int b);
        void Test();
    }

    public class Bussiness : MarshalByRefObject, IBussiness
    {
        [LogHandler]
        public int Add(int a, int b)
        {
            return a + b;
        }

        [ExceptionHandler(ErrorCode = "E2303")]
        public void Test()
        {
            int a = 1;
            int b = 0;
            var c = a / b;
        }
    }
}
