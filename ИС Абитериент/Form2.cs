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
                checkedListBox1.Items.Clear();
                comboBox1.Items.Clear();
                numericUpDown1.Value = 4;
                numericUpDown2.Value = 6;
                numericUpDown1.Location = new Point(270, 52);
                numericUpDown2.Location = new Point(270, 155);
                comboBox1.Items.Add("Информационные технологии и программирование");
                comboBox1.Items.Add("Преподаванеи в начальных классах");
                comboBox1.Items.Add("Дошкольное образование");
                comboBox1.Items.Add("Правоохранительная деятельность");
                comboBox1.Items.Add("Физическая культура");
                checkedListBox1.Items.Add("Аттестат(диплом)");
                checkedListBox1.Items.Add("Ксерокопия паспорта");
                checkedListBox1.Items.Add("Согласия на ОПД");
                checkedListBox1.Items.Add("Ксерокопия СНИЛС");
                checkedListBox1.Items.Add("Ксерокопия мед.полиса");
                checkedListBox1.Items.Add("Ксерокопия ИНН");
                checkedListBox1.Items.Add("Заявление");
                checkedListBox1.Items.Add("Мед.справка");
                checkedListBox1.Items.Add("Прививочный сертификат");
                checkedListBox1.Items.Add("Фотографии");
            }
            else
            {
                checkedListBox1.Items.Clear();
                numericUpDown1.Value = 3;
                numericUpDown2.Value = 3;
                comboBox1.Items.Clear();
                checkedListBox1.Items.Add("Аттестат(диплом)");
                checkedListBox1.Items.Add("Ксерокопия паспорта");
                checkedListBox1.Items.Add("Согласия на ОПД");
                checkedListBox1.Items.Add("Ксерокопия СНИЛС");
                checkedListBox1.Items.Add("Ксерокопия ИНН");
                checkedListBox1.Items.Add("Заявление");
                checkedListBox1.Items.Add("Фотографии");
                checkedListBox1.Items.Add("Ксерокопия свидетельства о браке(при смене фамилии)");
                comboBox1.Items.Add("Дошкольное образвание(дистант)");
                comboBox1.Items.Add("Дошкольное образование(база 9)");
                comboBox1.Items.Add("Дошкольное образование(база 11)");
                comboBox1.Items.Add("Правоохранительная деятельность");
                comboBox1.Items.Add("Преподавание в нчальных классах(дистант)");
                comboBox1.Items.Add("Физическая культура");
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
