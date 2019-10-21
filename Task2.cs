using System;
using System.Threading;
using System.Threading.Tasks;

namespace WriteAsyncCode
{
    class Task2
    {
        /*
         * task.Wait();
         */
        public void run()
        {
            var task = Task.Factory.StartNew(() => {
                Thread.Sleep(2000);
                Console.WriteLine("Howdy World!");

                Console.WriteLine("Is background thread:  {0}", Thread.CurrentThread.IsBackground);
                Console.WriteLine("Is threadpool thread:  {0}", Thread.CurrentThread.IsThreadPoolThread);

                #region Throw Exception
                /*
                 * If you uncomment the throw statement and run this, the exception is actually
                 * caught in the task.Wait() method outside of this Task block.
                 */
                //throw new InvalidOperationException("Uh oh!");
                #endregion

            }, TaskCreationOptions.LongRunning);

            task.Wait();
        }
    }
}
