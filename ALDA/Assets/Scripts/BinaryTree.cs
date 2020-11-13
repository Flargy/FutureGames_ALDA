
public class BinaryTree
{
    private TreeNode root = null;
    
    public BinaryTree(int data)
    {
        this.root = new TreeNode(data);
    }

    public void AddNewNode(int data)
    {
        if (root == null)
        {
            return;
        }

        if (data < root.data)
        {
            if (root.left != null)
            {
                AddNewNode(data, root.left);
            }
            else
            {
                Addleaf(data, root.left);
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
                Addleaf(data, root.right);
            }
        }
        
    }

    public void AddNewNode(int data, TreeNode currentNode)
    {
        if (data < currentNode.data)
        {
            if (currentNode.left != null)
            {
                AddNewNode(data, currentNode.left);
            }
            else
            {
                Addleaf(data, currentNode);
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
                Addleaf(data, currentNode);
            }
        }
    }

    public void Addleaf(int data, TreeNode parent)
    {
        if (parent.data < data)
        {
            parent.left = new TreeNode(data);
        }
        else
        {
            parent.right = new TreeNode(data);
        }
    }
}

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