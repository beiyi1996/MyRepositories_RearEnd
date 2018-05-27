using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicketPrice.Models;

namespace TicketPrice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Createcombobox();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CreateSouthstart();
            CreateEndcombobox();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Createnorthstart();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateEndcombobox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ticlist = new Model1();
            int ticc = 0;
            if (radioButton1.Checked == true)
            {
                ticc = ticlist.TicTable.FirstOrDefault((x) => x.Startstation == comboBox1.SelectedItem.ToString() && x.Endstation == comboBox2.SelectedItem.ToString()).Price;
            }
            else if(radioButton2.Checked == true)
            {
                ticc = ticlist.TicTable.FirstOrDefault((x) => x.Endstation == comboBox1.SelectedItem.ToString() && x.Startstation == comboBox2.SelectedItem.ToString()).Price;
            }
            label4.Text = $"{CreatePrice(ticc)}元";
        }

        private decimal CreatePrice(decimal ticc)
        {
            decimal pay = 0;
            if (checkBox1.Checked == true && checkBox2.Checked == true) //選到來回票
            {
                pay = Math.Floor(ticc * 2 * 0.81m); 
            }
            else if (checkBox2.Checked == true) //選到優惠票的時候
            {
                pay = Math.Floor(ticc * 0.9m);
            }
            else if (checkBox1.Checked == true) //兩個都有選到的時候
            {
                pay = Math.Floor(ticc * 2 * 0.9m);
            }
            else
            {
                pay = ticc;
            }
            return pay;
        }

        private void CreateSouthstart()
        {
            Createcombobox();
            var ticprice = new Model1();
            var ticlist = ticprice.TicTable.ToList();
            comboBox1.DataSource = ticlist.Distinct(new StartStationIEquityComparer()).Select((x) => x.Startstation).ToList();
        }

        private void Createnorthstart()
        {
            Createcombobox();
            var ticprice = new Model1();
            var ticlist = ticprice.TicTable.ToList();
            comboBox1.DataSource = ticlist.Distinct(new EndStationIEquityComparer()).Select((x) => x.Endstation).ToList();
        }

        private void CreateEndcombobox()
        {
            Createcombobox();
            var ticprice = new Model1();
            var ticlist = ticprice.TicTable.ToList();
            string start = getstartstation();
            if (radioButton1.Checked)
            {
                comboBox2.DataSource = ticlist.Where((x) => x.Startstation == start).Select((x) => x.Endstation).ToList();
            }
            else if(radioButton2.Checked)
            {
                comboBox2.DataSource = ticlist.Where((x) => x.Endstation == start).Select((x) => x.Startstation).ToList();
            }
        }

        private string getstartstation()
        {
            return comboBox1.SelectedItem.ToString();
        }

        private List<TicTable> Createcombobox()
        {
            var ticprice = new Model1();
            var list = ticprice.TicTable.ToList();
            return list;
        }
    }
}
