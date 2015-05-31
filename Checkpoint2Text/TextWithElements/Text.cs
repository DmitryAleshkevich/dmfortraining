using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint2Text
{
    public class Text
    {
        public List<Sentense> SentensesColl { get; set; }

        public void ShowSentensesWithOrdering(Func<Sentense,int> keySelector)
        {
            var query = this.SentensesColl.OrderBy(keySelector);
            foreach (var s in query)
            {
                s.ConsoleDraw();
                Console.WriteLine();
            }
        }

        public void ShowWordsByLengthInInterrogativeSentenses(int countSymbols)
        {
            List<Word> lw = new List<Word>();                                
            var sentquery = this.SentensesColl.Where(x => x.Type == SentenseTypes.Interrogative);                       
            foreach (var item in sentquery)
            {
                var wordquery = item.SentenseElements.Where(y => y is Word && (y as Word).Length == countSymbols);
                foreach (var element in wordquery)
                {
                    lw.Add(element as Word);                    
                }                                
            }
            WordComparer wc = new WordComparer();
            var distquery = lw.Distinct(new WordComparer());
            foreach (var element in distquery)
            {
                element.ConsoleDraw();
                Console.WriteLine();
            }
        }

        public void DeleteWordsByLengthAndConsolant(int countSymbols)
        {
            foreach (var sentence in SentensesColl)
            {
                sentence.DeleteWords(countSymbols);
                sentence.ConsoleDraw();
                Console.WriteLine();
            }
        }
    }
}
