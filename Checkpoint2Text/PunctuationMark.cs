using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint2Text
{
    public class PunctuationMark : Symbol
    {
        public override char Representation { get; set; }

        public override bool IsConsonant
        {
            get { return false; }
        }

        public override void ConsoleDraw()
        {
            Console.Write(Representation);
        }
    }
}
