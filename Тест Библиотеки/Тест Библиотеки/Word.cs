using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClusteringSearchResults
{
   public class Word:Tags
    {
        public string word;
        public int count;
        public bool IsSingle;
        public Word(string word)
        {
            this.word = word;
            count = 1;
            IsSingle = true;
        }

        public Word(string word, int c)
        {
            this.word = word;
            count = c;
        }

        public Word(string s, bool IsSingle)
        {
            this.IsSingle = IsSingle;
            this.word = s;
        }
        public override string GetTag
        {
            get
            {
                return word;
            }
            set
            {
                word = value;
            }
        }
    }
}
