using UnityEngine;

namespace BinaryTree
{
    public class BinaryTreeMono : MonoBehaviour
    {
        private BinaryTree tree = null;
        
        void Start()
        {
            tree = new BinaryTree(10);
            for (int i = 0; i < 20; i++)
            {
                tree.AddNewNode(Random.Range(0, 20));
            }
            tree.BreadthFirstTravel(tree.root);
        }


    }
}