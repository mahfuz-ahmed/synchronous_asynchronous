using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Synchronous
{
    public class SynchronousClass
    {
        public void SynchronousMethod(int time)
        {
            Thread.Sleep(1000 * time);
            Console.WriteLine("Method1 End");
            MethodTwo(time);    //Sequentially Call
            MethodThree(time);
        }

        public void MethodTwo(int time)
        {
            Thread.Sleep(6000 * time);
            Console.WriteLine("Method2 End");
        }
        public void MethodThree(int time)
        {
            Thread.Sleep(3000 * time);
            Console.WriteLine("Method3 End");
        }
    }
}
