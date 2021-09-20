using System;
using MicrokernelHandsOn.Contract;

namespace MicrokernelHandsOn.Plugin
{
    public class CoolPlugin : IPlugin
    {
        public void SaySomething()
        {
            Console.WriteLine("Hello Cool Microkernel");
        }
    }
}
