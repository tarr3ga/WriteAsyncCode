using System;
using System.Threading;
using System.Threading.Tasks;

namespace WriteAsyncCode
{
    class Task3
    {
        public void run()
        {
            /*
             * Canceling tasks...
             */
            string message = "Some data";

            //Under System.Threading namespace
            var cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            //Initialization Method #1
            //var task = Task.Factory.StartNew(DoTaskWork, message);

            //Initialization Method #2
            /*var task = Task.Factory.StartNew((state) =>
            {
                Console.WriteLine(message);

                token.ThrowIfCancellationRequested();

            }, "MessageTask");*/

            //Initialization Method #2
            var task = Task.Factory.StartNew(() => {
                //do work

                token.ThrowIfCancellationRequested();
            }, token);


            cts.Cancel(); // Cancel Now
            cts.CancelAfter(2000); // Cancel after 2 seconds
        }

        //Needed for Initialization Method #1
        public void DoTaskWork(object message)
        {
            Console.WriteLine(message);
        }
    }
}
