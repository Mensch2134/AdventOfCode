using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal class Node
    {
        public Node? parent;
        public string name;

        public Node(Node? parent, string name)
        {
            this.parent = parent;
            this.name = name;
        }
    }

    internal class DirectoryNode : Node
    {
        private List<Node> children;
        private int combinedSize = 0;

        public DirectoryNode(Node? parent, string name) : base(parent, name)
        {
            children = new List<Node>();
        }

        public List<Node> generateSubTreeList()
        {
            List<Node> subTreeList = new List<Node>();
            foreach(var child in children)
            {
                if (child is DirectoryNode)
                {
                    DirectoryNode c = child as DirectoryNode;
                    subTreeList.AddRange(c.generateSubTreeList());
                    subTreeList.Add(child);
                }
            }
            return subTreeList;
        }

        public int getDirSize()
        {
            return combinedSize;
        }

        public void addChild(Node node)
        {
            children.Add(node);
            if (node is FileNode)
            {
                FileNode f = node as FileNode;
                increaseSize(f.size);
            }
        }

        public Node getChild(string name)
        {
            return children.Find(x => x.name.Equals(name));
        }

        public void increaseSize(int size)
        {
            combinedSize += size;
            if (parent != null)
            {
                DirectoryNode p = parent as DirectoryNode;
                p.increaseSize(size);
            }
        }
    }

    internal class FileNode : Node
    {
        public int size;

        public FileNode(Node? parent, string name, int size) : base(parent, name)
        {
            this.size = size;
        }
    }

    internal class Tree
    {
        private Node root;
        private Node currentNode;

        public Tree()
        {
            root = new DirectoryNode(null, "/");
            currentNode = root;
        }

        public List<Node> getDirs()
        {
            DirectoryNode r = root as DirectoryNode;
            List<Node> l = new List<Node>();
            l.AddRange(r.generateSubTreeList());
            l.Add(root);
            return l;
        }

        public int getRootSize()
        {
            DirectoryNode r = root as DirectoryNode;
            return r.getDirSize();
        }

        public void addNode(string name, int fileSize)  //if fileSIze -1 its a directory
        {
            if (currentNode is FileNode)
            {
                Console.WriteLine("Cannot add new dile or directory to a file. Hast to be a directory.");
            }
            else if (currentNode is DirectoryNode && currentNode as DirectoryNode != null)
            {
                DirectoryNode curDir = currentNode as DirectoryNode;
                if (fileSize < 0)
                {
                    curDir.addChild(new DirectoryNode(currentNode, name));
                } else
                {
                    curDir.addChild(new FileNode(currentNode, name, fileSize));
                }
            }

        }

        public Node moveDown(string name)
        {
            if (currentNode is FileNode || currentNode == null)
            {
                Console.WriteLine("Specified Directory is a File or NULL.");
                return currentNode;
            }
            else if (currentNode as DirectoryNode != null)
            {
                DirectoryNode curDir = currentNode as DirectoryNode;
                Node child = curDir.getChild(name);

                if (child != null)
                {
                    currentNode = child;
                    return currentNode;
                }
            }
            return null;
        }

        public Node moveUp()
        {
            if (currentNode.parent != null)
            {
                currentNode = currentNode.parent;
                return currentNode;
            }
            return null;
        }
    }
}
