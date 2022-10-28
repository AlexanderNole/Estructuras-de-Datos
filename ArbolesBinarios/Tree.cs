namespace ArbolesBinarios
{
    class Node
    {
        public int Data;
        public Node? Left;
        public Node? Right;
    }
    class Tree
    {
        private Node root = new Node();
        public Tree()
        {
            root = null;
        }


        private void Insert(Node root, int data)
        {
            Node nodeNew = new() {
                Data = data,
                Left = null,
                Right = null
            };
            if (this.root == null) {
                this.root = nodeNew;
            } else {
                if (data < root.Data) {
                    if (root.Left == null)
                        root.Left = nodeNew;
                    else Insert(root.Left, data);
                } else if (data > root.Data) {
                    if (root.Right == null)
                        root.Right = nodeNew;
                    else Insert(root.Right, data);
                } else {
                    Console.WriteLine($"The number {data} exists already");
                }
            }
        }
        public void Insert(int data) => Insert(this.root, data);
        private void PreOrder(Node root)
        {
            if (root != null) {
                Console.WriteLine(root.Data);
                if (root.Left != null)
                    PreOrder(root.Left);
                if (root.Right != null)
                    PreOrder(root.Right);
            }

        }
        public void PreOrder()
        {
            Console.WriteLine("----- Pre Order -----");
            if (this.root != null)
                PreOrder(this.root);
        }
        private void InOrderUpward(Node root)
        {
            if (root != null) {
                if (root.Left != null)
                    InOrderUpward(root.Left);
                Console.WriteLine(root.Data);
                if (root.Right != null)
                    InOrderUpward(root.Right);
            }
        }
        private void InOrderDownward(Node root)
        {
            if (root != null) {
                if (root.Right != null)
                    InOrderDownward(root.Right);
                Console.WriteLine(root.Data);
                if (root.Left != null)
                    InOrderDownward(root.Left);
            }
        }
        public void InOrder(bool upward)
        {
            if (this.root != null) {
                if (upward) {
                    Console.WriteLine("----- In Order Upward -----");
                    InOrderUpward(this.root);
                } else {
                    Console.WriteLine("----- In Order Downward -----");
                    InOrderDownward(this.root);
                }
            }
        }
        private void PostOrder(Node root)
        {
            if (root != null) {
                if (root.Left != null)
                    PostOrder(root.Left);
                if (root.Right != null)
                    PostOrder(root.Right);
                Console.WriteLine(root.Data);
            }
        }
        public void PostOrder()
        {
            Console.WriteLine("----- Post Order -----");
            if (this.root != null)
                PostOrder(this.root);
        }
        private bool Search(Node? root, int data)
        {
            if (root != null) {
                if (data < root.Data) {
                    if (root.Left != null)
                        return Search(root.Left, data);
                } else if (data > root.Data) {
                    if (root.Right != null)
                        return Search(root.Right, data);
                } else return true;
            }
            return false;
        }
        public void Search(int data)
        {
            if (Search(this.root, data))
                Console.WriteLine($"Number {data} found");
            else Console.WriteLine($"Number {data} not found");
        }
        private Node Delete(Node root, int data)
        {
            if (root != null) {
                if (data == root.Data) {
                    if (root.Left != null && root.Right != null)
                        root = DeleteTwoChild(root);
                    else if (root.Left != null || root.Right != null)
                        root = DeleteOneChild(root);
                    else root = null;
                } else {
                    if (data < root.Data)
                        root.Left = Delete(root.Left, data);
                    else root.Right = Delete(root.Right, data);
                }
            }
            return root;
        }

        public void Delete(int data)
        {
            if (Search(this.root, data)) {
                this.root = Delete(this.root, data);
                Console.WriteLine($"Number {data} eliminated");
            } else Console.WriteLine($"Number {data} not found");
        }
        private static Node DeleteOneChild(Node root)
        {
            if (root.Left == null)
                return root.Right;

            return root.Left;
        }
        private Node DeleteTwoChild(Node root)
        {
            int small;
            Node? Small = NumberSmall(root.Right);

            small = Small.Data;
            root = Delete(root, Small.Data);
            root.Data = small;

            return root;
        }
        private Node NumberBig(Node root)
        {
            if (root.Right == null)
                return root;

            return NumberBig(root.Right);
        }
        public void NumberBig()
        {
            int numberBig = NumberBig(this.root).Data;
            Console.WriteLine($"The number bigger is {numberBig}");
        }
        private Node NumberSmall(Node root)
        {
            if (root.Left == null)
                return root;
            return NumberSmall(root.Left);
        }
        public void NumberSmall()
        {
            int numberSmall = NumberSmall(this.root).Data;
            Console.WriteLine($"The number smaller is {numberSmall}");
        }
        private int PathLength(Node root, int data)
        {
            if (!Search(root, data))
                return 0;

            if (root == null)
                return 0;
            if (data < root.Data)
                return 1 + PathLength(root.Left, data);
            else
                return 1 + PathLength(root.Right, data);

        }
        public void PathLength(int data)
        {
            int pathLength = PathLength(this.root, data);

            if (pathLength <= 0)
                Console.WriteLine($"Number {data} not found");
            else Console.WriteLine($"The path length of {data} is {pathLength}");
        }
        private void PrintPathLength(Node root, int data)
        {
            if (!Search(root, data)) {
                Console.WriteLine($"Number {data} not found");
                return;
            }

            Console.WriteLine(root.Data);
            if (data < root.Data) {
                if (root.Left != null)
                    PrintPathLength(root.Left, data);
            } else {
                if (root.Right != null)
                    PrintPathLength(root.Right, data);
            }
        }
        public void PrintPathLength(int data) => PrintPathLength(this.root, data);
        public void Subtraction()
        {
            int subtraction = NumberBig(this.root).Data - NumberSmall(this.root).Data;
            Console.WriteLine($"The difference between number bigger and number smaller is: {subtraction}");
        }
        private void PrintLeaf(Node? root)
        {
            if (root != null) {
                if (root.Left == null && root.Right == null)
                    Console.WriteLine(root.Data);

                PrintLeaf(root.Left);
                PrintLeaf(root.Right);
            }
        }
        public void PrintLeaf()
        {
            Console.WriteLine($"The leaves of the tree are: ");
            PrintLeaf(this.root);
        }
    }
}
