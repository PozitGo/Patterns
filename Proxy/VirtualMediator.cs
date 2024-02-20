namespace Proxy
{
    public interface IBitmap
    {
        void Draw();
    }

    public class Bitmap : IBitmap
    {
        private readonly string FileName;
        public Bitmap(string FileName)
        {
            this.FileName = FileName;
            Console.WriteLine($"Loading image from {FileName}\n");
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing image {this.FileName}");
        }
    }

    public class LazyBitmap : IBitmap
    {
        private readonly string FileName;
        private Lazy<Bitmap> bitmap;

        public LazyBitmap(string FileName)
        {
            this.FileName = FileName;
        }
        public void Draw()
        {
            if (this.bitmap is null)
            {
                this.bitmap = new Lazy<Bitmap>(new Bitmap(FileName));
            }

            bitmap.Value.Draw();
        }
    }
}
