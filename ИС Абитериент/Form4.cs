using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ИС_Абитериент
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            if (Form1.path =="Очное отделение")
            {
                listBox1.Items.Add("49.02.01 Физическая культура (Учитель физической культуры)");
                listBox1.Items.Add("44.02.01 Дошкольное образование (воспитатель детей дошкольного возраста) (11 классов)");
                listBox1.Items.Add("40.02.02 Правоохранительная деятельность (Юрист)");
                listBox1.Items.Add("09.02.07 Информационные системы и программирование (Программист)");
                listBox1.Items.Add("44.02.02 Преподавание в начальных классах (Учитель начальных классов)");
            }
            else
            {
                listBox1.Items.Add("44.02.01 Дошкольное образование (воспитатель детей дошкольного возраста) (11 классов)");
                listBox1.Items.Add("40.02.02 Правоохранительная деятельность (Юрист)");
                listBox1.Items.Add("49.02.01 Физическая культура (Учитель физической культуры)");
                listBox1.Items.Add("44.02.01 Дошкольное образование (воспитатель детей дошкольного возраста),обучение с применение дистанционных технологий ");
                listBox1.Items.Add("44.02.01 Дошкольное образование (воспитатель детей дошкольного возраста) на базе основного общего образования (9 классов)");
                listBox1.Items.Add("44.02.02 Преподавание в начальных классах (учитель начальных классов),обучение с применением дистационных технологий)");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() !=null)
            {
                Form1.specia = listBox1.SelectedItem.ToString();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
