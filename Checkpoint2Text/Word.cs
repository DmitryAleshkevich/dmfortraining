using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint2Text
{
    public class Word : ISentenceItem
    {
        public List<Symbol> Symbols { get; set; }
        public int Length 
        {
            get
            {
                return Symbols.Count;
            }
        }
        public bool BeginsConsonant 
        { 
            get
            {
                return Symbols[0].IsConsonant;
            }
        }

        public void ConsoleDraw()
        {
            foreach (Symbol s in Symbols)
            {
                s.ConsoleDraw();
            }
        }
    }
}
