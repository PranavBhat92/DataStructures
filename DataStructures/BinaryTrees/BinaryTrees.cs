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
            else if (current.Right.Left == null)    // If there is no left subtree for the right child then the right child (& its subtree) will replace the deleted node
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
            else // If right child of the deleted node has a left subtree, then we traverse that tree till we get the minimum node
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

        #region Pre-Order Traversal

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action,_head);
        }


        public void PreOrderTraversal(Action<T> action, BNode<T> node)
        {
            if (node!=null)
            {
                action(node.Value);
                PreOrderTraversal(action,node.Left);
                PreOrderTraversal(action,node.Right);
            }
        }

        #endregion

        #region Post-Order Traversal

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, _head);
        }


        public void PostOrderTraversal(Action<T> action, BNode<T> node)
        {
            if (node != null)
            {                
                PostOrderTraversal(action, node.Left);
                PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }

        #endregion

        #region In-Order Traversal

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, _head);
        }


        public void InOrderTraversal(Action<T> action, BNode<T> node)
        {
            if (node != null)
            {                
                InOrderTraversal(action, node.Left);
                action(node.Value);
                InOrderTraversal(action, node.Right);
            }
        }

        #endregion

        #region In-Order Traversal non recursive


        public IEnumerator<T> InOrderTraversal()
        {
            if (_head != null)
            {
                Stack<BNode<T>> stack = new Stack<BNode<T>>();
                BNode<T> current = _head;
                bool goLeft = true;

                stack.Push(current);

                while(stack.Count > 0)
                {
                    if(goLeft)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current.Value;

                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeft = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeft = false;
                    }

                }
            }
        }

        #endregion

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public int Count()
        {
            return _count;
        }
    }

    public class MainClass
    {
        public static void Main(string[] args)
        {
            BTree<string> tree = new BTree<string>();
            string input = string.Empty;

            while (!input.Equals("quit",StringComparison.CurrentCultureIgnoreCase))
            {
                Console.Write("> ");
                input = Console.ReadLine();
                string[] words = input.Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    tree.Add(word);
                }
                Console.WriteLine("Word Count = " + tree.Count());

                foreach (var word in tree)
                {
                    Console.Write(word + " ");
                }
                Console.WriteLine();
                tree.Clear();
            }


        }
    }
}