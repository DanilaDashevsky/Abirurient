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
            DataTable table = new DataTable();
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
            dataGridView1.DataSource = table;
            dataGridView1.Columns[1].Width = 308;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedItem != null)
            {
                path = toolStripComboBox1.SelectedItem.ToString()+".txt";
                DataTable table = new DataTable();
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
                dataGridView1.DataSource = table;
                dataGridView1.Columns[1].Width = 308;
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
