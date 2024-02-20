namespace Iterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1
            // /\
            //2  3

            //in-order: 213 центрированный
            //preorder: 123 прямой
            //postorder: 231 обратный

            //var root = new Node<int>(1,
            //  new Node<int>(2), new Node<int>(3));

            ////// C++ style
            ////var it = new InOrderIterator<int>(root);

            ////while (it.MoveNext())
            ////{
            ////    Console.WriteLine(it.Current.Value);
            ////    Console.WriteLine(',');
            ////}

            ////Console.WriteLine();

            //var tree = new BinaryTree<int>(root);

            //Console.WriteLine(string.Join(", ", tree.NaturalInOrder.Select(x => x.Value)));

            ////foreach (var node in tree)
            ////{
            ////    Console.WriteLine(node.Value);
            ////}

            var creature = new Creature();
            creature.Strenght = 10;
            creature.Intelligence = 11;
            creature.Agility = 12;

            Console.WriteLine($"Max - {creature.MaxStat}, Average - {creature.AverageStat}, Sum - {creature.SumOfStats}");

            var root = new Iterator.Work.Node<int>(1, new Iterator.Work.Node<int>(2), new Iterator.Work.Node<int>(3));
            Console.WriteLine(string.Join(", ", root.PreOrder.Select(x => x.Value)));
        }
    }
}
