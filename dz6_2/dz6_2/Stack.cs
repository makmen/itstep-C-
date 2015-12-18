using System;
using System.Collections.Generic;

namespace dz6_2
{
    class Stack
    {
        private const int SIZESTACK = 5;
        private int[] arr;
        private int currentSizeStack;

        public Stack()
        {
            arr = new int[SIZESTACK];
            currentSizeStack = 0;
        }

        public void Push(int value)
        {
            if (SIZESTACK > currentSizeStack)
            {
                arr[currentSizeStack++] = value;
            }
            else
            {
                Console.WriteLine("Stack overflow");
            }
        }

        public void Show()
        {
            for (int i = 0; i < currentSizeStack; ++i)
            {
                Console.WriteLine("{0} ", arr[i]);
            }
        }

        public void Pop()
        {
            if (currentSizeStack > 0)
            {
                --currentSizeStack;
            } 
            else
            {
                Console.WriteLine("Stack id Empty");
            }
        }

        public int Top()
        {
            if (currentSizeStack > 0)
            {
                return arr[currentSizeStack - 1];
            }
            Console.WriteLine("Stack id Empty");

            return 0;
        }
    }
}
