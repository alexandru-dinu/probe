using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private String strCategorie, strSubcategorie;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.categoriiTableAdapter1.Fill(this.dbDataSet.Categorii);
            DataTable dt = this.dbDataSet.Categorii;        
            DataRow dr;
            dr = dt.Rows[0]; // se selectează primul rând din tabelă
            String str = dr[0].ToString();
            treeView1.Nodes.Clear(); // ștergem întreaga colecție de noduri
            treeView1.Nodes.Add(str); // se adaugă ca nod părinte categoria de pe primul rând
            treeView1.Nodes[0].Nodes.Add(dr[1].ToString()); // se adaugă ca nod copil subcategoria de pe primul rând  
            int j = 0;
            for (int i = 1; i < dt.Rows.Count; i++) // se parcurg toate rândurile tabelei începând cu al doilea rând
            {
                dr = dt.Rows[i];
                if (str == dr[0].ToString()) // dacă o categorie se repetă atunci se adaugă subcategoria ca nod copil
                {
                    treeView1.Nodes[j].Nodes.Add(dr[1].ToString());
                }
                else // dacă avem de-a face cu o nouă categorie o adăugăm ca nod părinte și subcategoria ca nod copil
                {
                    j++;
                    treeView1.Nodes.Add(dr[0].ToString());
                    treeView1.Nodes[j].Nodes.Add(dr[1].ToString());
                    str = dr[0].ToString();
                }
            }
            treeView1.ExpandAll(); // expandăm toate nodurile arborelui
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Parent.Text!="")
            {
                strCategorie=treeView1.SelectedNode.Parent.Text;
                strSubcategorie = treeView1.SelectedNode.Text;
                textBox1.Text = strCategorie;
                textBox2.Text = strSubcategorie;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Introduceți categoria și subcategoria");
            }
            else
            {
                categoriiTableAdapter1.InsertCategorie(textBox1.Text, textBox2.Text);
                Form1_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            categoriiTableAdapter1.UpdateCategorie(textBox1.Text, textBox2.Text, strCategorie, strSubcategorie);
            Form1_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se șterge subcategoria " + strSubcategorie + " din categoria " + strCategorie);
            categoriiTableAdapter1.DeleteCategorie(strCategorie, strSubcategorie);
            Form1_Load(sender, e);
        }
    }
}
