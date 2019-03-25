using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        private bool _hasEmptyString;

        private ITrie _child;

        private char _label;


        public TrieWithOneChild(string s, bool isEmpty)
        {
            if (s=="" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _hasEmptyString = isEmpty;
            _label = s[0];
            _child = new TrieWithNoChildren().Add(s.Substring(1));
        }

        public ITrie Add(string s)
        {
            if(s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else if(_label == s[0]) 
            {
                _child = _child.Add(s.Substring(1));
                return this;
            }
            else
            {
                if(s[0] < 'a' || s[0] > 'z')
                {
                    throw new ArgumentException();
                }
                return new TrieWithManyChildren(s, _hasEmptyString, _label, _child);
            }
        }

        public bool Contains(string s)
        {
            if(s=="")
            {
                return _hasEmptyString;
            }
            else if(s[0] == _label)
            {
                return _child.Contains(s.Substring(1));
            }
            return false;
        }
    }
}
