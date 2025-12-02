using System;
using System.Collections.Generic;
using System.Text;

namespace Day01;

internal class DoublyLinkedListNode<T>
{
    public T Value { get; set; }
    public DoublyLinkedListNode<T> Next { get; set; }
    public DoublyLinkedListNode<T> Prev { get; set; }

    public DoublyLinkedListNode(T value) => Value = value;
}

internal class DoublyLinkedList<T>
{
    public DoublyLinkedListNode<T> Head { get; private set; }
    public DoublyLinkedListNode<T> Tail { get; private set; }

    public void AddLast(T value)
    {
        var newNode = new DoublyLinkedListNode<T>(value);
        if (Head == null)
        {
            Head = Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
        }
    }

    // Forward traversal
    public void PrintForward()
    {
        var current = Head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    // Backward traversal
    public void PrintBackward()
    {
        var current = Tail;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Prev;
        }
        Console.WriteLine();
    }
}
