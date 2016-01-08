using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering_research_tool
{
    public class TextTitle : Tags
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
