using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.Xml.Serialization;

namespace deserializer
{
    [Serializable]
    [XmlRoot("CarDetails")]
    public class Car
    {
        [XmlElement("CarManufacturer")]
        public string Manufacturer { get; set; }
        [XmlElement("CarModel")]
        public string Model { get; set; }
        [XmlElement("CarYearOfProduction")]
        public ushort Year { get; set; }
        [XmlElement("CarFuelType")]
        public string Fuel { get; set; }
        [XmlElement("CarEngineSize")]
        public ushort EngineSize { get; set; }
        [XmlElement("CarPower")]
        public byte Power { get; set; }
        [XmlElement("CarTopSpeed")]
        public byte TopSpeed { get; set; }
        [XmlElement("CarColor")]
        public string Color { get; set; }
    }
    
    
}
