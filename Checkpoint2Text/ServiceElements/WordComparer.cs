using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint2Text
{
    public class WordComparer : IEqualityComparer<Word>
    {
        #region IEqualityComparer Realization

        public bool Equals(Word x, Word y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            if (x.Length == y.Length)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (x.Symbols[i].Representation != y.Symbols[i].Representation) return false;
                }
                return true;
            }
            else return false;
        }

        public int GetHashCode(Word obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;
            int hashcode = 0;
            for (int i = 0; i < obj.Length; i++)
            {
                hashcode += obj.Symbols[i].Representation.GetHashCode();
            }
            return hashcode;
        }

        #endregion
    }
}
