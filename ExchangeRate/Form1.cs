using System;
using System.Windows.Forms;

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

            Currency.FetchData(mydatetimestr, dataGridView1);
        }

        private void btnDateSelected_Click(object sender, EventArgs e)
        {
            string selecteddate = dateTimePicker1.Value.Date.ToString("dd/MM/yyyy").Replace("/", ".");
            string url = "https://www.cbar.az/currencies/" + selecteddate + ".xml";

            Currency.FetchData(selecteddate, dataGridView1);
        } 
    }
}