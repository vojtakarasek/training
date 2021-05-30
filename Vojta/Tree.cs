using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vojta
{
    public class Tree
    {
        public int Value { get; set; }
        public Tree Left { get; }
        public Tree Right { get; }

        public Tree(int value, Tree left = null, Tree right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public string Iterate(string accumulator, Func<string, int, string> aggr)
        {
            if (Left != null)
                 accumulator = Left.Iterate(accumulator, aggr);
            accumulator = aggr(accumulator, Value);
            if (Right != null)
                accumulator = Right.Iterate(accumulator, aggr);
            return accumulator;
        }
    }


}
