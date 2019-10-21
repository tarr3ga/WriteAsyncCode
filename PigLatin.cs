using System;
using System.Text;
using System.Threading.Tasks;

namespace WriteAsyncCode
{
    class PigLatin
    {
        private string sentence = "I am going to flay far away to the moon";
        public void run()
        {
            var task = Task<string>.Factory.StartNew(() =>
            {
                StringBuilder sb = new StringBuilder();
                var words = sentence.Split();

                foreach (string word in words)
                {
                    if (word.Length > 1) {
                        var fisrtLetter = word.Substring(0, 1);
                        var otherLetters = word.Substring(1, word.Length - 1);

                        string[] wordParts = { fisrtLetter, otherLetters };

                        sb.Append(wordParts[1]);
                        sb.Append(wordParts[0]);
                        sb.Append("ay ");
                    } else
                    {
                        sb.Append(word);
                        sb.Append("ay");
                    }
                }

                return sb.ToString().ToLower();
            });

            Console.WriteLine(task.Result);
        }
    }
}
