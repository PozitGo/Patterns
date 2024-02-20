using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Work
{
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public abstract class Shape
    {
        private IRenderer Renderer;
        public string? Name { get; set;}

        public Shape(IRenderer renderer)
        {
            this.Renderer = renderer;
        }

        public override string ToString() => $"Drawing {Name} as {Renderer.WhatToRenderAs}";
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer)
        {
            base.Name = "Triangle";
        }
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer)
        {
            base.Name = "Square";
        }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs => "lines";

    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs => "pixels";
    }

}
