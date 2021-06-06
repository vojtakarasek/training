using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vojta
{

    public interface ITreeVisitor
    {

        void Visit(int nodeValue);
    }

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

        public void Iterate(ITreeVisitor visitor)
        {
            if (Left != null)
                 Left.Iterate(visitor);

            visitor.Visit(Value);

            if (Right != null)
                Right.Iterate(visitor);
        }
    }


}
