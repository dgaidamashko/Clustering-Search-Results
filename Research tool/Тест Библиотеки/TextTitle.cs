using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClusteringSearchResults
{
    class TextTitle:Tags
    {
        public string Title;

        public TextTitle(string Title)
        {
            this.Title = Title;
        }

        public override string GetTag
        {
            get
            {
                return Title;
            }
            set
            {
                Title = value;
            }
        }
    }
}
