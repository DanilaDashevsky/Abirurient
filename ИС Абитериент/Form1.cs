using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ИС_Абитериент
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static List<Abiturient> ab = new List<Abiturient>();
        public static string path = "Очное отделение.txt";
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Items.Add("Очное отделение");
            toolStripComboBox1.Items.Add("Заочное отделение");
            table.Columns.Add("№", typeof(string));
            table.Columns.Add("Специальность", typeof(string));
            table.Columns.Add("Номер телефона", typeof(string));
            table.Columns.Add("Фамилия", typeof(string));
            table.Columns.Add("Имя", typeof(string));
            table.Columns.Add("Отчетсво", typeof(string));
            string Text = "g";int k = 0;
            using (StreamReader st = new StreamReader(path))
            {
                while (Text != null)
                {
                    Text = st.ReadLine();
                    if (Text != null)
                    {
                        string[] t = Text.Split('|');
                        ab.Add(new Abiturient(t[0], t[1], t[2], t[3], t[4]));
                        k += 1;
                        table.Rows.Add(k,t[0], t[1], t[2], t[3], t[4]);
                        Array.Clear(t, 0, t.Length);
                    }
                }
                st.Close();
            }
            Form2.k = k;
            dataGridView1.DataSource = table;
            dataGridView1.Columns[1].Width = 308;
        }
       public static DataTable table = new DataTable();
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedItem != null)
            {
                ab.Clear();
                table.Rows.Clear();
                switch (toolStripComboBox1.SelectedItem.ToString())
                {
                    case "Очное отделение":
                        {
                            path = toolStripComboBox1.SelectedItem.ToString() + ".txt";
                            string Text = "g"; int k = 0;
                            using (StreamReader st = new StreamReader(path))
                            {
                                while (Text != null)
                                {
                                    Text = st.ReadLine();
                                    if (Text != null)
                                    {
                                        string[] t = Text.Split('|');
                                        ab.Add(new Abiturient(t[0], t[1], t[2], t[3], t[4]));
                                        k += 1;
                                        table.Rows.Add(k, t[0], t[1], t[2], t[3], t[4]);
                                        Array.Clear(t, 0, t.Length);
                                    }
                                }
                                st.Close();
                            }
                            Form2.k = k;
                            dataGridView1.DataSource = table;
                            dataGridView1.Columns[1].Width = 308;
                        }; break;
                    default:
                        {
                            path = toolStripComboBox1.SelectedItem.ToString() + ".txt";
                            string Text = "g"; int k = 0;
                            using (StreamReader st = new StreamReader(path))
                            {
                                while (Text != null)
                                {
                                    Text = st.ReadLine();
                                    if (Text != null)
                                    {
                                        string[] t = Text.Split('|');
                                        ab.Add(new Abiturient(t[0], t[1], t[2], t[3], t[4]));
                                        k += 1;
                                        table.Rows.Add(k, t[0], t[1], t[2], t[3], t[4]);
                                        Array.Clear(t, 0, t.Length);
                                    }
                                }
                                st.Close();
                            }
                            Form2.k = k;
                            dataGridView1.DataSource = table;
                            dataGridView1.Columns[1].Width = 308;
                        };break;
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string h = Convert.ToString(dataGridView1[2,dataGridView1.CurrentRow.Index].Value);
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            table.Rows.Clear();
            IEnumerable<Abiturient> t = from d in ab
                                        where d.number != h
                                        select d;
            int k1=0;
            foreach (var d in t)
            {
                k1+=1;
                table.Rows.Add(k1,d.Spec,d.Familia,d.Name,d.Otchestvo);
            }
            Form2.k = k1;
            dataGridView1.DataSource = table;
            using (StreamWriter wer = new StreamWriter(path,false))
            {
                foreach (var d in t)
                {
                    wer.WriteLine(d.Spec+'|'+d.number + '|' +d.Familia + '|' +d.Name + '|' +d.Otchestvo);
                }
            }
            
        }



        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ddd");
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            using (StreamWriter st = new StreamWriter(path,false))
            {
                for (int i=0;i<table.Rows.Count;i++)
                st.WriteLine(table.Rows[i].ToString());
            }
        }
    }
    public class Abiturient
    {
        public string Familia;
        public string number;
        public string Name;
        public string Otchestvo;
        public string Spec;
        public Abiturient(string Spec,string number, string Familia, string Name, string Otchestvo)
        {
            this.Spec = Spec;
            this.number = number;
            this.Familia = Familia;
            this.Name = Name;
            this.Otchestvo = Otchestvo;
        }
            

    }
}
