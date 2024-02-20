using System.Xml.Serialization;

namespace Adapter
{
    public class CountryStats
    {
        [XmlIgnore]
        public Dictionary<string, string> Capitals { get; set; } = new Dictionary<string, string>();

        //Адаптируем для сереализации, суррогатное свойство
        public (string, string)[] CapitalsSerializable
        {
            get
            {
                return Capitals.Keys.Select(country => (country, Capitals[country])).ToArray();
            }

            set
            {
                Capitals = value.ToDictionary(x => x.Item1, x => x.Item2);
            }
        }
    }
}
