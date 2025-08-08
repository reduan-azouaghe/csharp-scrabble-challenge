using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        private string _word;
        private Dictionary<char, int> _scores = new Dictionary<char, int>()
        {
            {'a', 1},
            {'e', 1},
            {'i', 1},
            {'o', 1},
            {'u', 1},
            {'l', 1},
            {'n', 1},
            {'r', 1},
            {'s', 1},
            {'t', 1},
            {'d', 2},
            {'g', 2},
            {'b', 3},
            {'c', 3},
            {'m', 3},
            {'p', 3},
            {'f', 4},
            {'h', 4},
            {'v', 4},
            {'w', 4},
            {'y', 4},
            {'k', 5},
            {'j', 8},
            {'x', 8},
            {'q', 10},
            {'z', 10},
        };

        public Scrabble(string word)
        {
            _word = word.ToLower();
        }

        public int score()
        {
            if (_word.Count(f => f == '[') != _word.Count(f => f == '[')) return 0;
            if (_word.Count(f => f == '{') != _word.Count(f => f == '}')) return 0;

            int result = 0;
            bool isDouble = false;
            bool isTripple = false;

            foreach (char c in _word)
            {
                if (Char.IsLetter(c))
                {
                    int points = _scores[c];

                    if (isDouble) points *= 2;
                    if (isTripple) points *= 3;

                    result += points;
                }
                else if (c == '[')
                {
                    isTripple = true;
                }
                else if (c == '{')
                {
                    isDouble = true;
                }
                else if (c == ']')
                {
                    isTripple = false;
                }
                else if (c == '}')
                {
                    isDouble = false;
                }
                else
                {
                    return 0;
                }
            }

            return result;
        }
    }
}
