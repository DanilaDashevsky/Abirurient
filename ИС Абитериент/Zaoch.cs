using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ИС_Абитериент
{
    public class Zaoch
    {
        public string Familia;
        public string number;
        public string Name;
        public string Otchestvo;
        public string Spec;
        public string Adres;
        public string Language;
        public string Birthday;
        public string School;
        public string DataOcon;
        public string Doky;
        public string Email;
        public Zaoch(string Spec, string number, string Familia, string Name, string Otchestvo,string Birthday, string Adres, string Email, string School, string DataOcon, string Language, string Doky)
        {
            this.Birthday = Birthday;
            this.Doky = Doky;
            this.Adres = Adres;
            this.School = School;
            this.DataOcon = DataOcon;
            this.Language = Language;
            this.Spec = Spec;
            this.number = number;
            this.Familia = Familia;
            this.Name = Name;
            this.Otchestvo = Otchestvo;
        }
       static public void Familia1()
        {
            string p = Interaction.InputBox("Введите фамилию абитуриента");
            p = Form1.ti.ToTitleCase(p);


        }
        static public void Spec1()
        {
            string p = Interaction.InputBox("Введите специальность абитуриента");
            p = Form1.ti.ToTitleCase(p);


        }
        static public void Language1()
        {
            string p = Interaction.InputBox("Введите изучаемый язык абитуриента");
            p = Form1.ti.ToTitleCase(p);

        }
    }
}
