using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint2Text
{
    public class Sentense : IConsoleDrawable
    {
        public List<ISentenceItem> SentenseElements { get; set; }
        public SentenseTypes Type { get; set; }

        public int WordsCount
        {
            get
            {
                return SentenseElements.Count<ISentenceItem>(x => x is Word);
            }
        }

        public void DetermineType()
        {
            var lastElement = SentenseElements.FindLast(x => true) as Symbol;
            if (lastElement != null)
            {
                if (lastElement.Representation == '!') this.Type = SentenseTypes.Exclamatory;
                else if (lastElement.Representation == '?') this.Type = SentenseTypes.Interrogative;
                else this.Type = SentenseTypes.Usual;
            }
        }

        public void ConsoleDraw()
        {
            foreach (ISentenceItem item in SentenseElements)
            {
                item.ConsoleDraw();
            }
        }
    }
}
