using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Generic.WeakEvent
{
    public class Consumer :   IWeakEventListener
    {
        private string name;  

        public Consumer(string name)
        {
            this.name = name;
        }

        public void NewCarIsHere(object sender,CarInfoEventArgs e)
        {
            Console.WriteLine("{0}: car {1} is new",name,e.Car);
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            NewCarIsHere(sender, e as CarInfoEventArgs);

            return true;
        }
    }

    public class WeakEventTest
    {
        public static void Start()
        {
            var dealer = new CarDealer();

            var michael = new Consumer("Michael");
            WeakCarInfoEventManager.AddListener(dealer, michael);

            dealer.NewCar("Mercedes");

            var sebastian = new Consumer("Sebastian");
            WeakCarInfoEventManager.AddListener(dealer, sebastian);

            dealer.NewCar("Ferrari");

            WeakCarInfoEventManager.RemoveListener(dealer, michael);

            dealer.NewCar("Red Bull Racing");
        }

        public static void Start1()
        {
            var dealer = new CarDealer();

            var michael = new Consumer("Michael");
            WeakEventManager<CarDealer, CarInfoEventArgs>.AddHandler(dealer, "NewCarInfo", michael.NewCarIsHere);

            dealer.NewCar("Mercedes");

            var sebastian = new Consumer("Sebastian");
            WeakEventManager<CarDealer, CarInfoEventArgs>.AddHandler(dealer, "NewCarInfo", sebastian.NewCarIsHere);

            dealer.NewCar("Ferrari");

            WeakEventManager<CarDealer, CarInfoEventArgs>.RemoveHandler(dealer, "NewCarInfo", michael.NewCarIsHere);

            dealer.NewCar("Red Bull Racing");
        }
    }
}
