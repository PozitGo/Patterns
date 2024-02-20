//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Bridge
//{
//   //Shape: Square, Circle, Triangle
//   //Renderer: Raster, Vector

//    public interface IRenderer
//    {
//        void RenderCircle(float Radius);
//    }

//    public class VectorRenderer : IRenderer
//    {
//        public void RenderCircle(float Radius)
//        {
//            Console.WriteLine($"Drawing circle of radius {Radius}");
//        }
//    }

//    public class RasterRenderer : IRenderer
//    {
//        public void RenderCircle(float Radius)
//        {
//            Console.WriteLine($"Drawing pixels of radius {Radius}");
//        }
//    }

//    //Мост
//    public abstract class Shape
//    {
//        protected IRenderer renderer;

//        public Shape(IRenderer renderer)
//        {
//            this.renderer = renderer;
//        }

//        public abstract void Draw();
//        public abstract void Resize(float Factor);
//    }

//    public class Circle : Shape
//    {
//        private float Radius;
//        public Circle(IRenderer renderer, float radius) : base(renderer)
//        {
//            this.Radius = radius;
//        }

//        public override void Draw() => base.renderer.RenderCircle(this.Radius);

//        public override void Resize(float Factor) => this.Radius *= Factor;
//    }
//}
