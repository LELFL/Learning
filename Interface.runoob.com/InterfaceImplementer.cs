using System;

namespace Interface.runoob.com
{
    public class InterfaceImplementer:IMyInterface
    {
        //实现接口
        public void MethodToImplement()
        {
            Console.WriteLine("MethodToImplement() called.");
            Console.ReadKey();
        }
    }
}