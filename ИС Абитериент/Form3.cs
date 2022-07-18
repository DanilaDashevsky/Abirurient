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
using System.Globalization;

namespace ИС_Абитериент
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            Default1.BackColor = Properties.Settings.Default.ColorElements;
            exit.BackColor = Properties.Settings.Default.ColorElements;
            ColorForm1.BackColor = Properties.Settings.Default.ColorElements;
            ColorText1.BackColor = Properties.Settings.Default.ColorElements;
            ColorElements1.BackColor = Properties.Settings.Default.ColorElements;
            pictureBox8.BackColor = Properties.Settings.Default.ColorElements;
            pictureBox9.BackColor = Properties.Settings.Default.ColorTetxt;
            pictureBox10.BackColor = Properties.Settings.Default.ColorForm;
            this.ForeColor = Properties.Settings.Default.ColorTetxt;
            this.Font = Properties.Settings.Default.Font;
            this.BackColor = Properties.Settings.Default.ColorForm;
                pictureBox1.Image = Image.FromFile(Properties.Settings.Default.Image1);
            openFileDialog1.Filter = "Text files(*.txt)";
        }


        delegate void Default();

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g;
            string sText;
            int iX;
            float iY;

            SizeF sizeText;
            TabControl ctlTab;

            ctlTab = (TabControl)sender;

            g = e.Graphics;

            sText = ctlTab.TabPages[e.Index].Text;
            sizeText = g.MeasureString(sText, ctlTab.Font);
            iX = e.Bounds.Left + 6;
            iY = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2;
            g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY);
        }

        private void Font_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            Form1.f3.Font = fontDialog1.Font;
            Properties.Settings.Default.Font = fontDialog1.Font;
            Properties.Settings.Default.Save();
        }

        private void Default_Click(object sender, EventArgs e)// установка значений по умолчанию
        {
            Properties.Settings.Default.Font = Form3.DefaultFont;
            Properties.Settings.Default.ColorElements = Form3.DefaultBackColor;
            Properties.Settings.Default.ColorTetxt = Form3.DefaultForeColor;
            Properties.Settings.Default.ColorForm = Form3.DefaultBackColor;
            Properties.Settings.Default.Save();
            pictureBox8.BackColor = Properties.Settings.Default.ColorElements;
            Form1.f3.Font = Form3.DefaultFont;
            Form1.f3.BackColor = Properties.Settings.Default.ColorForm;
            Form1.f3.ForeColor = Properties.Settings.Default.ColorTetxt;
            Font1.BackColor = Properties.Settings.Default.ColorElements;
            Default1.BackColor = Properties.Settings.Default.ColorElements;
            exit.BackColor = Properties.Settings.Default.ColorElements;
            ColorElements1.BackColor = Properties.Settings.Default.ColorElements;
            ColorText1.BackColor = Properties.Settings.Default.ColorElements;
            ColorForm1.BackColor = Properties.Settings.Default.ColorForm;
        }

        private void ColorText1_Click(object sender, EventArgs e)
        {
            colorDialog3.ShowDialog();
            Form1.f3.ForeColor = colorDialog3.Color;
            pictureBox9.BackColor = colorDialog3.Color;
            Properties.Settings.Default.ColorTetxt = colorDialog3.Color;
            Properties.Settings.Default.Save();
        }

        private void ColorElements1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Default1.BackColor = colorDialog1.Color;
            exit.BackColor = colorDialog1.Color;
            ColorForm1.BackColor = colorDialog1.Color;
            ColorText1.BackColor = colorDialog1.Color;
            ColorElements1.BackColor = colorDialog1.Color;
            Font1.BackColor = colorDialog1.Color;
            Properties.Settings.Default.ColorElements = colorDialog1.Color;
            Properties.Settings.Default.Save();
        }

        private void ColorForm1_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            Form1.f3.BackColor = colorDialog2.Color;
            Properties.Settings.Default.ColorForm = colorDialog2.Color;
            pictureBox10.BackColor = colorDialog2.Color;
            Properties.Settings.Default.Save();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            
           if ( MessageBox.Show("Вы действительно хотите выйти из сеню насроек?","Выход",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("ru-RU");
            Properties.Settings.Default.Language = "ru-RU";
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Properties.Settings.Default.Language = "en-US";
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != null)
            {
                if (comboBox1.SelectedItem.ToString() == "Англиский(English)")
                {
                    pictureBox1.Image = Image.FromFile("флаг британии.jpg");
                    Properties.Settings.Default.Image1 = "флаг британии.jpg";
                    Properties.Settings.Default.Save();

                }
                else
                {
                    pictureBox1.Image = Image.FromFile("флаг россии.jpg");
                    Properties.Settings.Default.Image1 = "флаг россии.jpg";
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                comboBox1.Items.Add(openFileDialog1.FileName);

            }
        }
    }
}
