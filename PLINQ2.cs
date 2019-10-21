using System;
using System.Linq;
namespace WriteAsyncCode
{
    class PLINQ2
    {
        public void run()
        {
            string sentence = "the quick brown fox jumped over the lazy dog";

            /*
             * AsParallel() is all that is needed to make this perform asynchronous code.
             * WithExecutionMode(ParallelExecutionMode.ForceParallelism) forces this code to be ran asynchronously.
             * 
             * PLINQ does not preserve the order of the dataset by default.
             * 
             * Adding AsOrdered() after AsParallel() makes PLINQ return the data in order.
             */
            var words = sentence.Split()
                .AsParallel()
                .AsOrdered()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .Select(word => new string(word.Reverse().ToArray()));

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
