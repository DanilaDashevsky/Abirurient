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
using Microsoft.VisualBasic;
using System.Globalization;

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
            toolStripComboBox2.Items.Add("Специальность");
            toolStripComboBox2.Items.Add("Номер телефона");
            toolStripComboBox2.Items.Add("Фамилия");
            toolStripComboBox2.Items.Add("Имя");
            toolStripComboBox2.Items.Add("Отчество");
            toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
           /* DataGridViewImageColumn im = new DataGridViewImageColumn();
            im.HeaderText = "Photo";
            im.Image = Image.FromFile("аттестат.png");
            dataGridView1.Columns.Add(im);*/
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
            f2.ShowDialog();
        }
        public static Form1 f1 = new Form1();
        public static Form2 f2 = new Form2();
        public static Form3 f3 = new Form3();
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
                table.Rows.Add(k1,d.Spec,d.number,d.Familia,d.Name,d.Otchestvo);
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

        private void button1_Click(object sender, EventArgs e)
        {
            ab.Clear();
            using (StreamWriter st = new StreamWriter(path,false))
            {
                for (int i=0;i<dataGridView1.RowCount;i++)
                {
                    st.WriteLine(dataGridView1[1,i].Value.ToString()+'|'+ dataGridView1[2, i].Value.ToString() + '|' + dataGridView1[3, i].Value.ToString() + '|' + dataGridView1[4, i].Value.ToString() + '|' + dataGridView1[4, i].Value.ToString());
                    ab.Add(new Abiturient(dataGridView1[1, i].Value.ToString(), dataGridView1[2, i].Value.ToString(), dataGridView1[3, i].Value.ToString(), dataGridView1[4, i].Value.ToString(), dataGridView1[5, i].Value.ToString()));
                }
            }
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (toolStripComboBox2.SelectedItem.ToString() !="")
            {
                Poisk r;
                Abiturient g=new Abiturient(null, null, null, null, null);
                switch (toolStripComboBox2.SelectedItem.ToString())
                {
                    case "Имя": { g.name(); } break;
                    case "Фамилия": { g.familia(); } break;
                    case "Специальность": { r.Spec(); } break;
                }
            }
        }
        public static TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            f3.Show();
        }
    }
    public struct Poisk
    {
        public void Spec()
        {
            string p = Interaction.InputBox("Введите специальность:");
            p = Form1.ti.ToTitleCase(p);
            IEnumerable<Abiturient> st = from h in Form1.ab
                                         where h.Spec.Contains(p)
                                         orderby h.Name
                                         select h;
            Form1.table.Rows.Clear();
            int l = 0;
            foreach (Abiturient h in st)
            {
                l += 1;
                Form1.table.Rows.Add(l, h.Spec, h.number, h.Familia, h.Name, h.Otchestvo);
            }
            Form2.k = l;
        }
    }
    public interface IPoisk
    {
        /*
        void Number();
        void Otchestvo();*/
       void name();
       void familia();
    }
    public class Abiturient : IPoisk
    {
        public string Familia { get; set;}
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
        public void name()
        {
            string p = Interaction.InputBox("Введите имя абитуриента");
            p = Form1.ti.ToTitleCase(p);
            IEnumerable<Abiturient> st = from h in Form1.ab
                                         where h.Name.Contains(p)
                                         orderby h.Name
                                         select h;
            Form1.table.Rows.Clear();
            int l=0;
            foreach(Abiturient h in st)
            {
                l += 1;
                Form1.table.Rows.Add(l,h.Spec,h.number,h.Familia,h.Name,h.Otchestvo);
            }
            Form2.k = l;
        }
        public void familia()
        {
            string p = Interaction.InputBox("Введите фамилию абитуриента");
            p = Form1.ti.ToTitleCase(p);
            IEnumerable<Abiturient> st = from h in Form1.ab
                                         where h.Familia.Contains(p)
                                         orderby h.Familia
                                         select h;
            
            Form1.table.Rows.Clear();
            int l = 0;
            foreach (Abiturient h in st)
            {
                l += 1;
                Form1.table.Rows.Add(l, h.Spec, h.number, h.Familia, h.Name, h.Otchestvo);
            }
            Form2.k = l;
        }
    }
}
