using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Setari
{
    public partial class Form2 : Form
    {
        private XmlDocument d = null;
        private XmlNodeList general = null;

        public Form2()
        {
            InitializeComponent();
            d = new XmlDocument();
            d.Load("setari.xml");
            general = d.SelectNodes("setari/general");
            XmlNode s1 = general.Item(0).SelectSingleNode("s1");
            textBox1.Text = s1.InnerText;
            XmlNode s2 = general.Item(0).SelectSingleNode("s2");
            textBox2.Text = s2.InnerText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            d = new XmlDocument();
            d.Load("setari.xml");
            general = d.SelectNodes("setari/general");
            XmlNode s1 = general.Item(0).SelectSingleNode("s1");
            s1.InnerText=textBox1.Text;
            XmlNode s2 = general.Item(0).SelectSingleNode("s2");
            s2.InnerText = textBox2.Text;
            d.Save("setari.xml");
            Close();
        }
    }
}
