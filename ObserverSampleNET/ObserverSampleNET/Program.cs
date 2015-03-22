using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverSampleNET
{
    class Program
    {
        static void Main(string[] args)
        {
            Manufacturer manufacturerA = new Manufacturer(); // observable - provider

            Console.WriteLine("Review the product of manufacturerA");

            Console.WriteLine("Name {0}, Price {1:C}", manufacturerA.product.Name, manufacturerA.product.Price);

            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();

            Distributer companyA = new Distributer("Company A"); // observer ones
            Distributer companyB = new Distributer("Company B");
            Distributer companyC = new Distributer("Company C");

            companyA.Attach(manufacturerA);
            companyB.Attach(manufacturerA);
            companyC.Attach(manufacturerA);

            //manufacturerA changed price
            manufacturerA.ChangePrice(25.50);
            Console.WriteLine("********");

            companyB.Detach();
            Console.WriteLine(companyB.Name + " is detached..");
            Console.WriteLine("********");

            Console.WriteLine("Price changed again...");
            manufacturerA.ChangePrice(33.70);



            Console.WriteLine("********");
            Console.WriteLine("Latest State of Product");
            Console.WriteLine("Name {0}, Price {1:C}", manufacturerA.product.Name, manufacturerA.product.Price);

            Console.ReadKey();
        }
    }
}
