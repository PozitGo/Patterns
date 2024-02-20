using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car being driven");
        }
    }
    public class Driver
    {
        public int Age { get; set; }
        public Driver(int Age)
        {
            this.Age = Age;
        }
    }
    public class CarProxy : ICar
    {
        private readonly Car car;
        private readonly Driver driver;

        public CarProxy(Driver driver)
        {
            this.driver = driver;
            this.car = new Car();
        }

        public void Drive()
        {
            if(driver.Age >= 18)
            {
                car.Drive();
            }
            else
            {
                Console.WriteLine("Driver too young");
            }
        }
    }
}
