using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Work
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }

        public IEnumerable<Node<T>> PreOrder
        {
            get
            {
                IEnumerable<Node<T>> TraversePreOrder(Node<T> current)
                {
                    if (current == null)
                    {
                        yield break;
                    }

                    yield return current;

                    if (current.Left != null)
                    {
                        foreach (var left in TraversePreOrder(current.Left))
                        {
                            yield return left;
                        }
                    }

                    if (current.Right != null)
                    {
                        foreach (var right in TraversePreOrder(current.Right))
                        {
                            yield return right;
                        }
                    }
                }

                foreach (var node in TraversePreOrder(this)) 
                {
                    yield return node;
                }
            }
        }


    }
}
