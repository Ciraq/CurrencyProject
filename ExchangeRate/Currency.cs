using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ExchangeRate
{
    public static class Currency
    {
        public static string FetchData(string date, DataGridView dataGrid)
        {
            string url = "https://www.cbar.az/currencies/" + date + ".xml";
            XElement root = XElement.Load(url);
            IEnumerable<XElement> valute =
                from el in root.Elements("ValType")
                where (string)el.Attribute("Type") == "Xarici valyutalar"
                select el;

            var query = from key in valute.Descendants("Valute")
                        select new
                        {
                            Kod = key.Attribute("Code").Value,
                            Nominal = key.Element("Nominal").Value,
                            Valyuta = key.Element("Name").Value,
                            Kurs = key.Element("Value").Value
                        };
            dataGrid.DataSource = query.ToList();
            return string.Empty;
        }
    }
}
