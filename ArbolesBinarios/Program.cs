namespace ArbolesBinarios
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Tree tree = new();
            tree.Insert(20);
            tree.Insert(10);
            tree.Insert(7);
            tree.Insert(30);
            tree.Insert(15);
            tree.Insert(32);
            tree.Insert(28);
            tree.Insert(31);
            tree.Insert(40);

            tree.InOrder(false);

        }
    }
}