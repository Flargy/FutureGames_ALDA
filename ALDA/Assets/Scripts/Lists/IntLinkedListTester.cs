using System;
using UnityEngine;

public class IntLinkedListTester : MonoBehaviour
{
    [SerializeField] private int[] listValues = new int[5];

    private IntLinkedList list = null;
    private IntLinkedListDouble doubleList = null;
    private GenericLinkedList<IComparable> genericList = null;
    
    private void Start()
    {
        /*list = new IntLinkedList(new IntLinkedListNode(listValues[0], null));

        for (int i = 1; i < listValues.Length; i++)
        {
            list.AddLast(new IntLinkedListNode(listValues[i], null));
        }*/
        
        doubleList = new IntLinkedListDouble(new IntLinkedListNodeDouble(listValues[0]));

        for (int i = 1; i < listValues.Length; i++)
        {
            doubleList.AddNode(listValues[i]);
        }
        
        doubleList.AddAtPosition(2, 500);
        
        Debug.Log(doubleList);
        
        genericList = new GenericLinkedList<IComparable>(0);
        genericList.AddNode("gameObject");
        genericList.AddNode(3.6f);
        
        Debug.Log(genericList);
        
    }
}
