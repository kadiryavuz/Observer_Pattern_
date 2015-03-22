using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverSampleNET
{
    /// <summary>
    /// define the data provider
    /// </summary>
    public class Manufacturer : IObservable<Product>
    {
        List<IObserver<Product>> registeredDistributers;
        public Product product { get; set; }

        public Manufacturer()
        {
            registeredDistributers = new List<IObserver<Product>>();
            product = GetProduct();
        }

        protected Product GetProduct()
        {
            return new Product(101, "Product1", 75.80);
        }

        public IDisposable Subscribe(IObserver<Product> p_RegisteredDistributer)
        {
            if (!registeredDistributers.Contains(p_RegisteredDistributer))
                registeredDistributers.Add(p_RegisteredDistributer);

            return new Detach(registeredDistributers, p_RegisteredDistributer);
        }

        protected void Notify(Product p_Product)
        {
            foreach (var subscriber in registeredDistributers)
            {
                subscriber.OnNext(p_Product);
            }
        }

        public void ChangePrice(double price)
        {
            if (this.product != null && !Double.Equals(this.product.Price, price))
            {
                this.product.actionType = ActionType.PriceChanged;
                this.product.Price = price;
                this.Notify(this.product);
            }

        }
    }

    public class Detach : IDisposable
    {
        List<IObserver<Product>> _registeredDistrubuters;
        IObserver<Product> _registeredDistributer;

        public Detach(List<IObserver<Product>> p_RegisteredDistributers, IObserver<Product> p_RegisteredDistributer)
        {
            this._registeredDistrubuters = p_RegisteredDistributers;
            this._registeredDistributer = p_RegisteredDistributer;
        }

        public void Dispose()
        {
            if (this._registeredDistributer != null)
                this._registeredDistrubuters.Remove(this._registeredDistributer);
        }
    }

    public enum ActionType
    {
        None,
        NewProduct,//if we decide manufacturer to keep a collection of product
        PriceChanged
    }


}
