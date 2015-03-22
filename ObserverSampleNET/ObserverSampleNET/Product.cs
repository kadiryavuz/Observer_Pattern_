using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverSampleNET
{
    /// <summary>
    /// data which is the observers will request for
    /// and provider is responsible for sending notifications about.
    /// </summary>
    public class Product
    {
        private int id;
        private string name;
        private double price;
        public ActionType actionType { get; set; }

        public Product(int p_id, string p_name, double p_price)
        {
            this.id = p_id;
            this.name = p_name;
            this.price = p_price;
            this.actionType = ActionType.None;
        }

        public int ID
        {
            get { return this.id; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public double Price
        {
            get { return this.price; }
            set { this.price = value; } //price change will be done
        }

    }


}
