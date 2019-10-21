using System;
using System.Threading;
using System.Threading.Tasks;

namespace WriteAsyncCode
{
    class Task1
    {
        /*
         * A basic Task
         */
        public void run()
        {
            var task = Task<string>.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                return "Andy";
            });

            Console.Write("My name is ");
            Console.Write(task.Result);
        } 
    }
}
