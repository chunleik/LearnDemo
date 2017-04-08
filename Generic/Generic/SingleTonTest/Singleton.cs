using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class Singleton
    {
        static Singleton()
        {
            allSingletons = new Dictionary<Type, object>();
        }

        static readonly IDictionary<Type, object> allSingletons;

        public static IDictionary<Type,object> AllSingletons
        {
            get { return allSingletons; }
        }
    }

    public class Singleton<T> : Singleton
    {
        static T instance;

        public static T Instance
        {
            get { return instance; }
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }

    public class Apple
    {
        public string Name { get; set; }
    }

    public class Biscuit
    {

    }

    public class SingletonTest
    {
        public static void Test1()
        {
            Singleton<Apple>.Instance = new Apple() { Name = "1" };
            Singleton<Biscuit>.Instance = new Biscuit();
            Console.WriteLine(Singleton<Apple>.AllSingletons.Count);
        }
    }
}
