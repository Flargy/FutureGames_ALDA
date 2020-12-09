using System.Collections.Generic;
using UnityEngine;

namespace BinaryTree
{
    public class BinaryTree
    {
        public TreeNode root = null;

        public BinaryTree(int data)
        {
            root = new TreeNode(data);
        }

        public void AddNewNode(int data) // The method users will call when wanting to add a node
        {
            if (root == null)
            {
                return;
            }    

            // The following code decides if the node should be on the left or the right side of the tree
            // If the root lacks a child it will place itself directly
            // If a child node exists it will make a recursive call using the child node
            if (data < root.data)
            {
                if (root.left != null)
                {
                    AddNewNode(data, root.left);
                }
                else
                {
                    AddLeaf(data, root);
                }
            }
            else
            {
                if (root.right != null)
                {
                    AddNewNode(data, root.right);
                }
                else
                {
                    AddLeaf(data, root);
                }
            }

        }

        // The recursive call ends up here and will repeat itself until a node without a child is found
        private void AddNewNode(int data, TreeNode currentNode)
        {
            if (data < currentNode.data)
            {
                if (currentNode.left != null)
                {
                    AddNewNode(data, currentNode.left);
                }
                else
                {
                    AddLeaf(data, currentNode);
                }
            }
            else
            {
                if (currentNode.right != null)
                {
                    AddNewNode(data, currentNode.right);
                }
                else
                {
                    AddLeaf(data, currentNode);
                }
            }
        }

        // When a node without a child is found it will place the new node as it's child node
        private void AddLeaf(int data, TreeNode parent)
        {
           Debug.Log("data: " + data + " parent data: " + parent.data);
            if (data < parent.data)
            {
                parent.left = new TreeNode(data);
            }
            else
            {
                parent.right = new TreeNode(data);
            }
        }

        // Breath first as done during lesson
        public void BreadthFirstTravel(TreeNode node)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>(); // Creates a Queue for adding and popping nodes

            queue.Enqueue(node); // Adds the user selected node as a starting point

            // Continues to add both children of the node and in turn their children until reaching the bottom
            // of the tree
            while (queue.Count > 0)
            {
                node = queue.Dequeue();


                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }

        // Searches the left side of every node before searching the right one
        // Does this through recursive calling
        public void DepthFirstTravel(TreeNode node)
        {
            if (node == null)
                return;
            
            DepthFirstTravel(node.left);
            DepthFirstTravel(node.right);
        }

        
    }

// The TreeNode class used for nodes stored in the tree.
    public class TreeNode
    {
        public int data = 0;
        public TreeNode left = null;
        public TreeNode right = null;

        public TreeNode(int data)
        {
            this.data = data;
        }
    }
}