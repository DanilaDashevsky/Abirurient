using System;
using System.Collections.Generic;
using System.Collections;
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
using MySql.Data.MySqlClient;

namespace ИС_Абитериент
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public MySqlCommand mycom;
        public static string connect = "Server=localhost;port=3306;user=root;password=root;database=danilka";
        public static MySqlConnection mycon = new MySqlConnection(connect);
        public static MySqlDataAdapter mdb;
        public DataSet cd;
        public static DataTable table = new DataTable();
        public static string path = "Очное отделение";
        private void Form1_Load(object sender, EventArgs e)
        {

            toolStripComboBox2.Items.Add("Специальность");
            toolStripComboBox2.Items.Add("Фамилия");
            toolStripComboBox2.Items.Add("Имя");
            toolStripComboBox1.Items.Add("Очное отделение");
            toolStripComboBox1.Items.Add("Заочное отделение");
            mycon.Open();
            mdb = new MySqlDataAdapter("SELECT * FROM och", connect);
            mdb.Fill(table);
            dataGridView1.DataSource = table;
         }
           /* DataGridViewImageColumn im = new DataGridViewImageColumn();
            im.HeaderText = "Photo";
            im.Image = Image.FromFile("аттестат.png");
            dataGridView1.Columns.Add(im);*/
        
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedItem != null)
            {
                table.Rows.Clear();
                table.Columns.Clear();
                switch (toolStripComboBox1.SelectedItem.ToString())
                {
                    case "Очное отделение":
                        {
                            path = "Очное отделение";
                             mdb = new MySqlDataAdapter("SELECT * FROM och", connect);
                            mdb.Fill(table);
                            dataGridView1.DataSource = table;
                        }; break;
                    default:
                        {
                            path = "Зочное отделение";
                            mdb = new MySqlDataAdapter("SELECT * FROM zaoch", connect);
                            mdb.Fill(table);
                            dataGridView1.DataSource = table;
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
        public static Form4 f4 = new Form4();
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string h = Convert.ToString(dataGridView1[0, dataGridView1.CurrentRow.Index].Value);
            if (path == "Очное отделение")
            { 
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                mycom = new MySqlCommand("DELETE FROM `och` where `och`.№=" + h+"", mycon); ;
                mycom.ExecuteNonQuery();
                
            }
            else
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                mycom = new MySqlCommand("DELETE FROM `zaoch` where `och`.№=" + h + "", mycon); ;
                mycom.ExecuteNonQuery();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (path == "Очное отделение")
            {
                mycom = new MySqlCommand("DELETE from `och`", mycon);
                mycom.ExecuteNonQuery();
                for (int i=0;i<dataGridView1.RowCount;i++)
                {
                    mycom = new MySqlCommand("INSERT INTO `och` (`№`, `Специальность`, `Фамилия`, `Имя`, `Отчество`, `Дата рождения`, `Номер телефона`, `Адрес`, `Законченное уч.учреждение`, `Дата окончания`, `Ср.балл`, `Ин.язык`, `Документы`) VALUES ('"+dataGridView1[0,i].Value.ToString()+ "', '" + dataGridView1[1, i].Value.ToString() + "', '" + dataGridView1[2, i].Value.ToString() + "', '" + dataGridView1[3, i].Value.ToString() + "','" + dataGridView1[4, i].Value.ToString() + "','" + dataGridView1[5, i].Value.ToString() + "','" + dataGridView1[6, i].Value.ToString() + "','" + dataGridView1[7, i].Value.ToString() + "','" + dataGridView1[8, i].Value.ToString() + "','" + dataGridView1[9, i].Value.ToString() + "','" + dataGridView1[10, i].Value.ToString() + "','" + dataGridView1[11, i].Value.ToString() + "','" + dataGridView1[12, i].Value.ToString() + "')", mycon);
                    mycom.ExecuteNonQuery();
                }
            }
            else
            {
                mycom = new MySqlCommand("DELETE from `zaoch`", mycon);
                mycom.ExecuteNonQuery();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    mycom= new MySqlCommand("INSERT INTO `zaoch` (`№`, `Специальность`, `Фамилия`, `Имя`, `Отчество`, `Дата рождения`, `Адрес`, `Номер телефона`, `Эл.почта`, `Законченное уч.учреждение`, `Дата окончания`, `Ин.язык`, `Документы`) VALUES (NULL, '" + dataGridView1[1, i].Value.ToString() + "', '" + dataGridView1[2, i].Value.ToString() + "', '" + dataGridView1[3, i].Value.ToString() + "','" + dataGridView1[4, i].Value.ToString() + "','" + dataGridView1[5, i].Value.ToString() + "','" + dataGridView1[6, i].Value.ToString() + "','" + dataGridView1[7, i].Value.ToString() + "','" + dataGridView1[8, i].Value.ToString() + "','" + dataGridView1[9, i].Value.ToString() + "','" + dataGridView1[10, i].Value.ToString() + "','" + dataGridView1[11, i].Value.ToString() + "','" + dataGridView1[12, i].Value.ToString() + "')", mycon);
                    mycom.ExecuteNonQuery();
                }
            }
            
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (toolStripComboBox2.SelectedItem.ToString() !="")
            {
                if (path == "Заочное отделение.txt")
                {
                    //Zaoch g1 = new 
                    //Abiturient g = new Abiturient(null, null, null, null, null, null, null, null, null, null, null, null);
                    switch (toolStripComboBox2.SelectedItem.ToString())
                    {
                        case "Ин.язык": { Zaoch.Language1(); } break;
                        case "Фамилия": { Zaoch.Familia1(); } break;
                        case "Специальность": { Zaoch.Spec1(); } break;
                    }
                }
                else
                {
                    switch (toolStripComboBox2.SelectedItem.ToString())
                    {
                       case "Имя": { Abiturient.name(); } break;
                       case "Фамилия": { Abiturient.familia(); } break;
                        case "Специальность": { Abiturient.spec(); } break;
                    }
                }

            }
        }
        public static TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
        public static string specia;
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            f3.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотете выйти? Внесённые изменения могут не сохраниться!", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public static  void Zapol()
        {
            f1.dataGridView1.DataSource = table;
        }
    }
    public struct Poisk
    {

    }

    public class Abiturient
    {
        public string Familia { get; set;}
        public string number;
        public string Name;
        public string Otchestvo;
        public string Spec;
        public string Adres;
        public string Language;
        public string Birthday;
        public string School;
        public string SrBall;
        public string DataOcon;
        public string Doky;
        public bool Sdal;

        public Abiturient(string Spec,string number, string Familia, string Name, string Otchestvo, string Birthday, string Adres, string School, string DataOcon, string Language, string SrBall, string Doky)
        {
            this.Birthday = Birthday;
            this.Doky = Doky;
            this.Adres = Adres;
            this.School = School;
            this.DataOcon = DataOcon;
            this.Language = Language;
            this.Spec = Spec;
            this.SrBall = SrBall;
            this.number = number;
            this.Familia = Familia;
            this.Name = Name;
            this.Otchestvo = Otchestvo;
        }
        static public void name()
        {
            
            string p = Interaction.InputBox("Введите имя абитуриента");
            p = Form1.ti.ToTitleCase(p);
            Form1.table.Rows.Clear();
            Form1.mdb = new MySqlDataAdapter($"SELECT * FROM `och` WHERE `Имя` LIKE '{p}%'", Form1.connect);
            Form1.mdb.Fill(Form1.table);
            Form1.Zapol();

        }
        static public void familia()
        {
            string p = Interaction.InputBox("Введите фамилию абитуриента");
            p = Form1.ti.ToTitleCase(p);
            Form1.table.Rows.Clear();
            Form1.mdb = new MySqlDataAdapter($"SELECT * FROM `och` WHERE `Фамилия` LIKE '{p}%'", Form1.connect);
            MessageBox.Show($"SELECT * FROM `och` WHERE `Фамилия` LIKE '{p}%'");
            Form1.mdb.Fill(Form1.table);
            Form1.Zapol();
        }
        static public void spec()
        {
            Form1.f4.ShowDialog();
            if (Form1.specia != null)
            {
                Form1.table.Rows.Clear();
                Form1.mdb = new MySqlDataAdapter($"SELECT * FROM `och` WHERE `Специальность`='{Form1.specia}'", Form1.connect);
                Form1.mdb.Fill(Form1.table);
                Form1.Zapol();
            }
        }
    }
}
