using System;
using System.Threading;
using System.Threading.Tasks;

namespace WriteAsyncCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1 t = new Task1();
            //Task2 t = new Task2();
            //Task3 t = new Task3();
            //Task4 t = new Task4();
            //Task5 t = new Task5();

            //t.run();

            //PLINQ1 p = new PLINQ1();
            //PLINQ2 p = new PLINQ2();

            //p.run();

            PigLatin p = new PigLatin();
            p.run();
        }
    }
}
