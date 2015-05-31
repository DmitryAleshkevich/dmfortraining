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

        public void DeleteWords(int countSymbols)
        {
            var wordquery = SentenseElements.Where(y => y is Word && (y as Word).Length == countSymbols && (y as Word).BeginsConsonant).ToArray();
            for (int i = 0; i < wordquery.Length; i++)
            {
                this.SentenseElements.Remove(wordquery[i]);
            }
        }
 
        public void ReplaceWordsBySubstring(int countSymbols, string substring)
        {
            Parser parser = new Parser();
            List<Symbol> replacementList = parser.ParseSymbols(new StringBuilder(substring), 0);
            var wordquery = SentenseElements.Where(y => y is Word && (y as Word).Length == countSymbols).ToArray();
            for (int i = 0; i < wordquery.Length; i++)
            {
                var tempelement = (Word)wordquery[i];
                int replStrNumber = tempelement.Symbols.First().StringNumber;
                foreach (var symb in replacementList)
                {
                    symb.StringNumber = replStrNumber;
                }
                tempelement.Symbols.RemoveAll(x => true);
                tempelement.Symbols.AddRange(replacementList);
            }
            this.ConsoleDraw();
            Console.WriteLine();
        }
    }
}
