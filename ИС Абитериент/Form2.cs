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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Form1.path == "Очное отделение.txt")
            {
                comboBox1.Items.Add("Информационные технологии и программирование");
                comboBox1.Items.Add("Преподаванеи в начальных классах");
            }
            else
            {
                comboBox1.Items.Add("Столяр");
                comboBox1.Items.Add("Сварщик");
            }
        }
        public static int k;
        private void button1_Click(object sender, EventArgs e)
        {
            k += 1;
            Form1.table.Rows.Add(k.ToString(), Convert.ToString(comboBox1.SelectedItem), textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            using (StreamWriter st = new StreamWriter(Form1.path, true))
            {
                st.WriteLine(Convert.ToString(comboBox1.SelectedItem)+'|'+textBox1.Text + '|' + textBox2.Text + '|' + textBox3.Text + '|' + textBox4.Text);
            }
            Form1.f2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.f2.Hide();
        }
    }
}
