using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTrees
{
    public class BNode<T> : IComparable<T> where T : IComparable<T>
    {
        public T Value;
        public BNode<T> Left;
        public BNode<T> Right;

        public BNode(T value)
        {
            Value = value;
        }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }
    }

    public class BTree<T> : IEnumerable<T> where T : IComparable<T>
    {

        private BNode<T> _head;
        private int _count;


        #region Add

        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new BNode<T>(value);
            }
            else
            {
                AddTo(_head, value);
            }
            _count++;
        }


        private void AddTo(BNode<T> node,T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BNode<T>(value);
                }
                else {
                    AddTo(node.Left,value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BNode<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        #endregion


        #region Contains

        public bool Contains(T value)
        {
            BNode<T> parent;
            return FindWithParent(value,out parent) != null;
        }


        public BNode<T> FindWithParent(T value,out BNode<T> parent)
        {
            var current = _head;
            parent = null;

            while(current != null)
            {
                var result = current.CompareTo(value);

                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        #endregion


        #region Remove

        public bool Remove(T value)
        {
            BNode<T> parent;
            var current = FindWithParent(value, out parent);

            if (current == null)
            {
                return false;
            }            

            // The node we are removing has only left child & no right child
            if (current.Right == null)
            {
                //node we are removing is the root node
                if (parent == null)
                {
                    _head = current.Left;
                }
                else
                {
                    var result = parent.CompareTo(current.Value);   // This is just to track the parent so that we can update the appropriate link (like left or right etc)

                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else if(result < 0)
                    {
                        parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)    // If there is no left subtree for the right child then
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    _head = current.Right;
                }
                else
                {
                    var result = parent.CompareTo(current.Value);

                    if (result > 0)
                    {
                        parent.Left = current.Right;
                    }
                    else
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                BNode<T> leftMost = current.Right.Left;
                BNode<T> leftMostParent = current.Right;


                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                leftMostParent.Left = leftMost.Right;
                leftMost.Left = current.Left;
                leftMost.Right = current.Right;

                if (parent == null)
                {
                    _head = leftMost;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent.Left = leftMost;
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftMost;
                    }
                }
            }
            _count--;
            return true;
        }

    #endregion

    public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
        }
    }
}