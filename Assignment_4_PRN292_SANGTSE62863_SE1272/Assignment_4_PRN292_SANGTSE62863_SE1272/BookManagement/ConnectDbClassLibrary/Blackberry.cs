using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDbClassLibrary
{
    public class Blackberry
    {
        public string LambID { get; set; }
        public string LambName { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public float Price { get; set; }
        public string ReleasedYear { get; set; }

        public Blackberry()
        {

        }

        public Blackberry(string lambID, string lambName, string manufacturer, string model, float price, string releasedYear)
        {
            LambID = lambID;
            LambName = lambName;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            ReleasedYear = releasedYear;
        }
    }
}
