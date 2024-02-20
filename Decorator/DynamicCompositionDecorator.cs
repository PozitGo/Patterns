namespace Decorator
{
    public abstract class Shape
    {
        public virtual string AsString => string.Empty;

    }

    public sealed class Circle : Shape
    {
        public float Radius;

        public Circle(float Radius)
        {
            this.Radius = Radius;
        }

        public void Resize(float Factor)
        {
            this.Radius *= Factor;
        }

        public override string AsString => $"A circle of radius {this.Radius}";

    }

    //Decorator
    public class ColorShape : Shape
    {
        private readonly Shape shape;
        private readonly string color;

        public ColorShape(Shape shape, string color)
        {
            this.shape = shape;
            this.color = color;
        }

        public override string AsString => $"{shape.AsString} has the color {color}";
    }

    //Decorator
    public class TransparentShape : Shape
    {
        private readonly Shape shape;
        private readonly float transparency;

        public TransparentShape(Shape shape, float transparency)
        {
            this.shape = shape;
            this.transparency = transparency;
        }

        public override string AsString => $"{shape.AsString} has the {transparency * 100.0f}% transparency";
    }
}

