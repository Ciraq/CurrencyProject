using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ExchangeRate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            string mydatetimestr = dateTime.ToString("dd-MM-yyyy").Replace("-", ".");

            string url = "https://www.cbar.az/currencies/" + mydatetimestr + ".xml";
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

            dataGridView1.DataSource = query.ToList();
        }

        private void btnDateSelected_Click(object sender, EventArgs e)
        {
            string dateselected = dateTimePicker1.Value.Date.ToString("dd/MM/yyyy").Replace("/", ".");
            string url = "https://www.cbar.az/currencies/" + dateselected + ".xml";
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

            dataGridView1.DataSource = query.ToList();
        }
    }
}
