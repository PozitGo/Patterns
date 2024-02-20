namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var drawing = new GraphicObject
            //{
            //    Name = "My Drawing"
            //};

            //drawing.Children.Add(new Square
            //{
            //    Color = "Red"
            //});

            //drawing.Children.Add(new Circle
            //{
            //    Color = "Yellow"
            //});

            //var group = new GraphicObject();

            //group.Children.Add(new Circle
            //{
            //    Color = "Blue"
            //});

            //group.Children.Add(new Square
            //{
            //    Color = "Blue"
            //});

            //drawing.Children.Add(group);

            //Console.WriteLine(drawing);

            //var neuronOne = new Neuron();
            //var neuronTwo = new Neuron();

            //var LayerOne = new NeuronLayer(3);
            //var LayerTwo = new NeuronLayer(4);

            //neuronOne.ConnectTo(neuronTwo);
            //neuronOne.ConnectTo(LayerOne);
            //LayerTwo.ConnectTo(neuronOne);
            //LayerOne.ConnectTo(LayerTwo);



            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();

            Console.WriteLine("Green products (old):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
                Console.WriteLine($" - {p.Name} is green");

            // ^^ BEFORE

            // vv AFTER
            var bf = new BetterFilter();
            Console.WriteLine("Green products (new):");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
                Console.WriteLine($" - {p.Name} is green");

            Console.WriteLine("Large products");
            foreach (var p in bf.Filter(products, new SizeSpecification(Size.Large)))
                Console.WriteLine($" - {p.Name} is large");

            var largeGreenSpec = new ColorSpecification(Color.Green)
                                 & new SizeSpecification(Size.Large);
            //var largeGreenSpec = Color.Green.And(Size.Large);

            Console.WriteLine("Large blue items");
            foreach (var p in bf.Filter(products,
              new AndSpecification<Product>(new ColorSpecification(Color.Blue),
                new SizeSpecification(Size.Large)))
            )
            {
                Console.WriteLine($" - {p.Name} is big and blue");
            }
        }
    }
}
