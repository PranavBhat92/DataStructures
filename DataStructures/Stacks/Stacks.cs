using System;

namespace Stacks
{
    internal class Stack { 
        internal int[] items = new int[0];
        internal int top = 0;
    }

    class Stacks
    {
        static void Main(string[] args)
        {
            var stack = new Stack();

            //push
            push(stack, 5);
            push(stack, 10);
            push(stack, 15);

            //peek
            int item = peek(stack);
            Console.WriteLine("Peek : " + item);
            Enumerate(stack);

            //pop
            item = pop(stack);
            Console.WriteLine("Pop : " + item);
            Enumerate(stack);
            item = pop(stack);
            Console.WriteLine("Pop : " + item);
            Enumerate(stack);

            //peek
            item = peek(stack);
            Console.WriteLine("Peek : " + item);
            Enumerate(stack);

            Console.ReadLine();
        }

        // push
        public static void push(Stack stack, int item)
        {
            if (stack.items.Length == stack.top)
            {
                stack.items = (stack.top == 0) ? new int[4] : new int[stack.top*2];
            }
            stack.items[stack.top++] = item;
        }

        // peek
        public static int peek(Stack stack)
        {
            return stack.items[stack.top-1];
        }

        // pop
        public static int pop(Stack stack)
        {
            return stack.items[--stack.top];
        }

        public static void Enumerate(Stack stack)
        {
            Console.WriteLine("**********************************************************************");
            for (int i = stack.top-1; i >= 0; i--)
            {
                Console.WriteLine(stack.items[i]);
            }
            Console.WriteLine("**********************************************************************");
        }
    }
}
