using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint2Text
{
    public class LetterFigure : Symbol
    {
        public override char Representation { get; set; }

        public override bool IsConsonant
        {
            get 
            {
                char[] vowels = new char[] {'a','e','y','u','i','o','у','е','а','о','э','ы','я','и','ю'};
                return !vowels.Contains(Representation);
            }
        }

        public override void ConsoleDraw()
        {
            Console.Write(Representation);
        }
    }
}
