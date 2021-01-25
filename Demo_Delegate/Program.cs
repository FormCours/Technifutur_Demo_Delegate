using Demo_Delegate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            ElementList el = new ElementList();

            Console.WriteLine("Generation et affichage des valeurs");
            el.Generate(10);
            foreach(int value in el.Content)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();

            Console.WriteLine("Les nombres paires");
            IEnumerable<int> v1 = el.GetEven();
            foreach (int value in v1)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();

            Console.WriteLine("Les nombres impaires");
            IEnumerable<int> v2 = el.GetOdd();
            foreach (int value in v2)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();



            Console.WriteLine("Les nombres multi de 3");
            LeDelegateDeNico d1 = delegate (int nb)
            {
                return nb % 3 == 0;
            };

            IEnumerable<int> vd1 = el.Filter(d1);
            foreach (int value in vd1)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();



            Console.WriteLine("Les nombres multi de 5");
            LeDelegateDeNico d2 = (v) => v % 5 == 0;


            IEnumerable<int> vd2 = el.Filter(d2);
            foreach (int value in vd2)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}
