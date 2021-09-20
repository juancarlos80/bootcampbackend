using System;

namespace MicrokernelHandsOn.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Init prog");
            var factory = new PluginFactory();
            var plugins = factory.GetPlugins();

            foreach (var plugin in plugins)
            {
                plugin.SaySomething();
            }

            Console.WriteLine("End prog");
            Console.ReadKey();
        }
    }
}
