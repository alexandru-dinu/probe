using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Test
    {
        private static Test INSTANCE = null;

        private Test()
        {
            Console.Out.Write("Singleton works!!");
            Console.In.Read();
        }

        public static Test getInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new Test();
            }

            return INSTANCE;
        }
    }
}
