using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverSampleNET
{
    public class Distributer : IObserver<Product>
    {
        private IDisposable detacher;
        private string distName;

        public Distributer(string p_Name)
        {
            this.distName = p_Name;
        }

        public string Name
        { get { return this.distName; } }

        public void Attach(IObservable<Product> p_Manufacturer)
        {
            detacher = p_Manufacturer.Subscribe(this);
        }

        public void Detach()
        {
            detacher.Dispose();
        }

        public void OnCompleted()
        { //not implemented
        }

        public void OnError(Exception error)
        {//not implemented
        }
        public void OnNext(Product p_Product)
        {
            switch (p_Product.actionType)
            {

                case ActionType.NewProduct://if we decide manufacturer to keep a collection of product
                    Console.WriteLine("Dear {0} - New Product Added! {1} with price {2:C}", this.distName, p_Product.Name, p_Product.Price);
                    break;
                case ActionType.PriceChanged:
                    Console.WriteLine("Dear {0} - Price Changed! {1} with new price {2:C}", this.distName, p_Product.Name, p_Product.Price);
                    break;
                case ActionType.None:
                default:
                    break;
            }
        }
    }
}
