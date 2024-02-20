using System.Collections;
using System.Collections.ObjectModel;
using static System.Console;

namespace DotNetDesignPatternDemos.Structural.Adapter.NoCaching
{
    public class Point : IEquatable<Point>
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }

        public bool Equals(Point other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Point)) return false;

            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
        protected bool Equals(Line other)
        {
            return Equals(Start, other.Start) && Equals(End, other.End);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Line)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Start != null ? Start.GetHashCode() : 0) * 397) ^ (End != null ? End.GetHashCode() : 0);
            }
        }
    }

    public abstract class VectorObject
      : Collection<Line>
    { }

    public class VectorRectangle : VectorObject
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x, y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x, y), new Point(x, y + height)));
            Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
        }
    }

    public class LineToPointAdapter : IEnumerable<Point>
    {
        private static int count = 0;
        private static Dictionary<int, List<Point>> cache = new Dictionary<int, List<Point>>();
        private int Hash;

        //Добавлено кеширование
        public LineToPointAdapter(Line line)
        {
            Hash = line.GetHashCode();
            if (cache.ContainsKey(Hash)) return;

            WriteLine($"{++count}: Generating points for line"
              + $" [{line.Start.X},{line.Start.Y}]-"
              + $"[{line.End.X},{line.End.Y}] (no caching)");

            int left = Math.Min(line.Start.X, line.End.X);
            int right = Math.Max(line.Start.X, line.End.X);
            int top = Math.Min(line.Start.Y, line.End.Y);
            int bottom = Math.Max(line.Start.Y, line.End.Y);

            var points = new List<Point>();
            if (right - left == 0)
            {
                for (int y = top; y <= bottom; ++y)
                {
                    points.Add(new Point(left, y));
                }
            }
            else if (line.End.Y - line.Start.Y == 0)
            {
                for (int x = left; x <= right; ++x)
                {
                    points.Add(new Point(x, top));
                }
            }

            cache.Add(Hash, points);
        }

        public IEnumerator<Point> GetEnumerator()
        {
            return cache[Hash].GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Demo
    {
        private static readonly List<VectorObject> vectorObjects
          = new List<VectorObject>
        {
      new VectorRectangle(1, 1, 10, 10),
      new VectorRectangle(3, 3, 6, 6)
        };

        // the interface we have
        public static void DrawPoint(Point p)
        {
            Write(".");
        }

        private static List<Point> points = new List<Point>();
        private static bool prepared = false;

        private static void Prepare()
        {
            if (prepared) return;
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);

                    foreach (var item in adapter)
                    {
                        points.Add(item);
                    }
                }
            }
            prepared = true;
        }

        private static void DrawPointsLazy()
        {
            Prepare();
            points.ForEach(DrawPoint);
        }

        public static void DrawPoints()
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);

                    foreach (var item in adapter)
                    {
                        DrawPoint(item);
                    }
                }
            }
        }
    }
}