using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint2Text
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            Text text = parser.ParseText(@"c:\Users\Димон\Documents\st.txt");
            if (text != null)
            {
                text.ShowSentensesWithOrdering(x => x.WordsCount);
            }           
        }
    }
}
