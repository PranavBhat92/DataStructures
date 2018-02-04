using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedLists
{

    internal class SNode
    {
        internal int data;
        internal SNode next;

        public SNode(int data)
        {
            this.data = data;
            next = null;
        }
    }

    internal class DNode
    {
        internal int data;
        internal DNode prev;
        internal DNode next;

        public DNode(int data)
        {
            this.data = data;
            prev = null;
            next = null;
        }
    }
    
    internal class SList
    {
        internal SNode head;
    }

    internal class DList
    {
        internal DNode head;
    }

    class LinkedLists
    {
        static void Main(string[] args)
        {

            //var linkedList = new LinkedList<int>();

            SList singleList = new SList();
            DList doubleList = new DList();

            //Queue q = new Queue();
            //Stack s = new Stack();

            InsertFrontSingly(singleList,5);
            InsertFrontSingly(singleList, 10);
            InsertFrontSingly(singleList, 15);
            InsertFrontSingly(singleList, 20);
            InsertFrontSingly(singleList, 25);

            //PrintAllSingly(singleList);
            //DeleteNodeSingly(singleList, 20);
            //PrintAllSingly(singleList);

            PrintAllSingly(singleList);
            ReverseSingly(singleList);
            PrintAllSingly(singleList);

            InsertFrontDoubly(doubleList, 5);
            InsertFrontDoubly(doubleList, 10);
            InsertFrontDoubly(doubleList, 15);
            InsertFrontDoubly(doubleList, 20);
            InsertFrontDoubly(doubleList, 25);

            //PrintAllDoubly(doubleList);
            //DeleteNodeDoubly(doubleList, 20);
            //PrintAllDoubly(doubleList);

            Console.ReadLine();
        }

        internal static void InsertFrontSingly(SList list,int data)
        {
            SNode newNode = new SNode(data);
            newNode.next = list.head;
            list.head = newNode;
        }

        internal static void InsertFrontDoubly(DList list, int data)
        {
            DNode newNode = new DNode(data);
            if (list.head != null)
            {
                list.head.prev = newNode;
            }            
            newNode.next = list.head;
            newNode.prev = null;
            list.head = newNode;
        }

        internal static void InsertBackSingly(SList list, int data)
        {
            SNode newNode = new SNode(data);
            newNode.next = null;
            SNode node = list.head;

            while (node.next != null)
            {
                node = node.next;
            }

            node.next = newNode;
        }

        internal static void InsertBackDoubly(DList list, int data)
        {
            DNode newNode = new DNode(data);
            DNode node = list.head;

            while (node.next != null)
            {
                node = node.next;
            }

            node.next = newNode;
            newNode.prev = node;
            newNode.next = null;
        }

        internal static void InsertNextToSingly(SList list,SNode prev,int data)
        {
            SNode prevNode = list.head;
            SNode node = new SNode(data);
            while(prevNode.data != prev.data)
            {
                prevNode = prevNode.next;
            }
            node.next = prev.next;
            prevNode.next = node;
        }

        internal static void InsertNextToDoubly(DList list, DNode prev, int data)
        {
            DNode prevNode = list.head;
            DNode node = new DNode(data);
            while (prevNode.data != prev.data)
            {
                prevNode = prevNode.next;
            }

            node.prev = prevNode;
            node.next = prevNode.next;
            prevNode.next = node;
            prevNode.next.prev = node;
        }

        internal static void DeleteNodeSingly(SList list,int data)
        {
            SNode node = list.head;

            while (node.next.data != data)
            {
                node = node.next;
            }
            node.next = node.next.next;
        }

        internal static void DeleteNodeDoubly(DList list, int data)
        {
            DNode node = list.head;

            while (node.data != data )
            {
                node = node.next;
            }
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        internal static void ReverseSingly(SList list)
        {
            SNode prev = null;
            SNode current = list.head;
            SNode next = null;

            while (current != null)
            {
                next = current.next;    // Get the next node
                current.next = prev;    // Reverse the pointer of the current node
                prev = current;         // Make the current node as previous for next iteration
                current = next;         // Move the current pointer to next pointer
            }
            list.head = prev;
        }

        internal static void PrintAllSingly(SList list)
        {
            SNode node = list.head;
            Console.WriteLine("Singly Linked List:");
            while (node.next != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }
            Console.Write(node.data);
            Console.WriteLine();
        }

        internal static void PrintAllDoubly(DList list)
        {
            DNode node = list.head;
            Console.WriteLine("Doubly Linked List:");
            while (node.next != null)
            {
                Console.Write(node.data + " ");
                node = node.next;
            }
            Console.Write(node.data);
            Console.WriteLine();
        }

    }
}
