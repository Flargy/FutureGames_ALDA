
public class IntLinkedList
{
    private IntLinkedListNode first = null;

    public IntLinkedList(IntLinkedListNode first)
    {
        this.first = first;
    }

    public void AddLast(IntLinkedListNode node)
    {
        IntLinkedListNode last = first;
        while (last.next != null)
        {
            last = last.next;
        }

        last.next = node;
    }

    public override string ToString()
    {
        string returnString = "";
        IntLinkedListNode current = first;

        while (current.next != null)
        {
            returnString += " " + current.data.ToString();
            current = current.next;
        }
        returnString += " " + current.data.ToString();

        return returnString;
    }
}

public class IntLinkedListNode
{
    public int data = 0;
    public IntLinkedListNode next = null;

    public IntLinkedListNode(int data, IntLinkedListNode next)
    {
        this.data = data;
        this.next = next;
    }
}