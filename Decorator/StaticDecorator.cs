namespace Decorator.Static
{
    public abstract class Shape
    {
        public virtual string AsString => string.Empty;

    }

    public sealed class Circle : Shape
    {
        public float Radius;

        public Circle()
        {
            
        }

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

    public class ColorShape<T> : Shape where T : Shape, new()
    {
        private T shape;
        private readonly string color;

        public ColorShape()
        {
            
        }

        public ColorShape(string color, T shape)
        {
            this.shape = shape;
            this.color = color;
        }

        public override string AsString => $"{shape.AsString} has the color {color}";
    }

    public class TransparentShape<T> : Shape where T : Shape, new()
    {
        private readonly T shape;
        private readonly float transparency;

        public TransparentShape()
        {
            
        }
        public TransparentShape(float transparency, T shape)
        {
            this.shape = shape;
            this.transparency = transparency;
        }

        public override string AsString => $"{shape.AsString} has the {transparency * 100.0f}% transparency";
    }

}
