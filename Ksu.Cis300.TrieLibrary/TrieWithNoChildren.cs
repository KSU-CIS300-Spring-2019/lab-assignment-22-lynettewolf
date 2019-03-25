using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        private bool _hasEmptyString;

        public ITrie Add(string s)
        {
            if(s=="")
            {
                _hasEmptyString = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(s, _hasEmptyString);
            }
        }

        public bool Contains(string s)
        {
            if(s=="")
            {
                return _hasEmptyString;
            }
            return false;
        }
    }
}
