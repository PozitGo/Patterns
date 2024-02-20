namespace Factory
{
    public class Point
    {
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static PointFactory Factory = new PointFactory();
        //Вложенная фабрика
        public class PointFactory
        {
            //Фабричные методы (Убрал статику)
            public Point NewCartesianPoint(double x, double y) => new Point(x, y);

            public Point NewPolarPoint(double rho, double theta) => new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
    }

}