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
    }
}
