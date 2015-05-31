using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint2Text
{
    public abstract class Symbol : ISentenceItem
    {
        public abstract char Representation { get; set; }
        public int StringNumber { get; set; }
        public abstract bool IsConsonant { get; }
        public abstract void ConsoleDraw();        
    }
}
