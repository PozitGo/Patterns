using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    using System;
    using System.Collections.Generic;

    public class Sentence
    {
        private string[] words;
        private Dictionary<int, WordToken> tokens = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            words = plainText.Split(' ');
        }

        public WordToken this[int index]
        {
            get
            {
                if (!tokens.ContainsKey(index))
                {
                    tokens[index] = new WordToken();
                }

                return tokens[index];
            }
        }

        public override string ToString()
        {
            var result = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (tokens.ContainsKey(i) && tokens[i].Capitalize)
                {
                    word = word.ToUpper();
                }

                result.Add(word);
            }

            return string.Join(" ", result);
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }

}
