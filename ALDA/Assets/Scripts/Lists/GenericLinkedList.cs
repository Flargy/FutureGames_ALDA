using System;

public class GenericLinkedList<T>
{
    private GenericLinkedListNodeDouble<T> first = null;

    public GenericLinkedList(T data)
    {
        first = new GenericLinkedListNodeDouble<T>(data);
    }
    public GenericLinkedList(GenericLinkedListNodeDouble<T> node)
    {
        first = node;
    }

    public void AddNode(T data)
    {
        GenericLinkedListNodeDouble<T> last = first;
        while (last.next != null)
        {
            last = last.next;
        }
        last.next = new GenericLinkedListNodeDouble<T>(data, null, last);
    }

    public void AddAtPosition(int index, T data)
    {
        if (index == 0)
        {
            GenericLinkedListNodeDouble<T> temp = first;
            first = new GenericLinkedListNodeDouble<T>(data, temp, null);
            temp.previous = first;
            return;
        }

        GenericLinkedListNodeDouble<T> current = first;

        for (int i = 0; i < index - 1; i++)
        {
            current = current.next;
            if (current == null)
            {
                return;
            }
        }

        GenericLinkedListNodeDouble<T> nextsNext = current.next;
        current.next = new GenericLinkedListNodeDouble<T>(data, nextsNext, current);
        nextsNext.previous = current.next;
    }
    
    public override string ToString()
    {
        string returnString = "";
        GenericLinkedListNodeDouble<T> current = first;

        while (current.next != null)
        {
            returnString += " " + current.data.ToString();
            current = current.next;
        }
        returnString += " " + current.data.ToString();

        return returnString;
    }
    
}


public class GenericLinkedListNodeDouble<T>
{
    public T data = default;
    public GenericLinkedListNodeDouble<T> next = null;
    public GenericLinkedListNodeDouble<T> previous = null;

    public GenericLinkedListNodeDouble(T data, GenericLinkedListNodeDouble<T> next, GenericLinkedListNodeDouble<T> previous)
    {
        this.data = data;
        this.next = next;
        this.previous = previous;

    }
    public GenericLinkedListNodeDouble(T data)
    {
        this.data = data;

    }
    
}