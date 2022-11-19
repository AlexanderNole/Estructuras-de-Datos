using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas
{
    class Node
    {
        public int Data;
        public Node? Next;
    }
    class Queue
    {
        private Node? front = new Node();
        private Node? end = new Node();
        
        public Queue()
        {
            front = null;
            end = null;
        }

        public void Enqueue(int data)
        {
            Node newNode = new Node();
            newNode.Data = data;
            newNode.Next = null;

            if (front != null)
                end.Next = newNode;
            else front = newNode;

            end = newNode;
        }
        public int Dequeue()
        {
            int data = int.MinValue;

            if (front != null) {
                data = front.Data;
                if (front.Next == null)
                    end = null;
                front = front.Next;
            }
            return data;
        }
    }
}
