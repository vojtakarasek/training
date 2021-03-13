using System;
using System.Collections.Generic;

namespace Vojta
{
    public class Matcher
    {
        public bool Simple(string expression)
        {
            var nested = 0;
            foreach (var ch in expression)
            {
                if (ch == '(')
                    nested++;
                if (ch == ')')
                    nested--;
                if (nested == -1)
                    return false;
            }

            return nested == 0;
        }

        class Item
        {
            public char C;
            public int Nest;
        }

        const string Opening = "([{<";
        const string Closing = ")]}>";

        bool IsOpening(char c)
        {
            return Opening.Contains(c);
        }

        bool IsClosing(char c, out char opening)
        {
            var pos = Closing.IndexOf(c);
            if (pos == -1)
            {
                opening = c;
                return false;
            }
            opening = Opening[pos];
            return true;
        }

        public bool Complex(string expression)
        {
            var stack = new Stack<Item>();
            stack.Push(new Item { C = '_', Nest = 0 });
            foreach (var ch in expression)
            {
                if (IsOpening(ch))
                {
                    if (stack.Peek().C == ch)
                        stack.Peek().Nest++;
                    else
                        stack.Push(new Item { C = ch, Nest = 1 });
                }
                else if (IsClosing(ch, out char opening))
                {
                    if (stack.Peek().C != opening)
                        return false;
                    if (stack.Peek().Nest == 1)
                        stack.Pop();
                    else
                        stack.Peek().Nest--;
                }
            }
            return stack.Peek().C == '_';
        }
    }
}