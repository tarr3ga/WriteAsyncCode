using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WriteAsyncCode
{
    class Task4
    {
        private static List<Task<string>> tasks = new List<Task<string>>();

        private static string ReverseString(string s)
        {
            //Delays the builder 
            Thread.Sleep(1000);
            StringBuilder sb = new StringBuilder();
            for(int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }

            return sb.ToString();
        }

        public static void ProcessSentence(string sentence)
        {
            foreach(string word in sentence.Split())
            {
                tasks.Add(Task<string>.Factory.StartNew(
                    () => ReverseString(word) + " ",
                    TaskCreationOptions.AttachedToParent /* TaskCreationOptions.None makes parent task end before child tasks */ | 
                    TaskCreationOptions.LongRunning));
            }
        }

        public void run()
        {
            string sentence = "the quick brown fox jumped over the lazy dog";

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Task.Factory.StartNew(() => ProcessSentence(sentence)).Wait();
            sw.Stop();

            Console.WriteLine("Total Runtime: {0}ms", sw.ElapsedMilliseconds);

            #region Verify that all takst have complted
            for (int i = 0; i < tasks.Count; i++)
                Console.WriteLine("Task {0} complete: {1}", i, tasks[i].IsCompleted);
            #endregion

            Console.Write("Result: ");
            foreach(Task<string> t in tasks)
            {
                Console.Write(t.Result);
            }
        }
    }
}
