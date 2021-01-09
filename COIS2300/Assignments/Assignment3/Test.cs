using System;

namespace Precision
{
    class Test
    {
        public static void Main()
        {
            float a = 0.0000002f, b = -0.0000005f, c = 10f;

            float res1 = (b + c);
            res1 += a;
            Console.WriteLine("{0}", res1);
            
            float res2 = a + b;
            res2 += c;
            Console.WriteLine("{0}", res2);

            Console.ReadLine();
        }
    }
}
