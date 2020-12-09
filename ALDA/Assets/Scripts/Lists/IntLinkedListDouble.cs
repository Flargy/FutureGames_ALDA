public class IntLinkedListDouble
{
    private IntLinkedListNodeDouble first = null;

    public IntLinkedListDouble(IntLinkedListNodeDouble first)
    {
        this.first = first;
    }

    public void AddNode(int data)
    {
        IntLinkedListNodeDouble last = first;
        while (last.next != null)
        {
            last = last.next;
        }

        last.next = new IntLinkedListNodeDouble(data, null, last);
    }

    public void AddAtPosition(int index, int data)
    {
        if (index == 0)
        {
            IntLinkedListNodeDouble temp = first;
            first = new IntLinkedListNodeDouble(data, temp, null);
            temp.previous = first;
            return;
        }
        
        IntLinkedListNodeDouble current = first;

        for (int i = 0; i < index - 1; i++)
        {
            current = current.next;
            if (current == null)
            {
                return;
            }
        }

        IntLinkedListNodeDouble nextsNext = current.next;
        current.next = new IntLinkedListNodeDouble(data, nextsNext, current);
        nextsNext.previous = current.next;
        
    }

    public override string ToString()
    {
        string returnString = "";
        IntLinkedListNodeDouble current = first;

        while (current.next != null)
        {
            returnString += " " + current.data.ToString();
            current = current.next;
        }
        returnString += " " + current.data.ToString();

        return returnString;
    }
}

public class IntLinkedListNodeDouble
{
    public int data = 0;
    public IntLinkedListNodeDouble next = null;
    public IntLinkedListNodeDouble previous = null;

    public IntLinkedListNodeDouble(int data, IntLinkedListNodeDouble next, IntLinkedListNodeDouble previous)
    {
        this.data = data;
        this.next = next;
        this.previous = previous;

    }
    public IntLinkedListNodeDouble(int data)
    {
        this.data = data;

    }
    
}