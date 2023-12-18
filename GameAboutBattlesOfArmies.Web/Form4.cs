using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace GameAboutBattlesOfArmies.Web
{
    public partial class Form4 : MaterialForm
    {
        Main form2;
        public Form4(Main form2,string _text)
        {
            InitializeComponent();
            this.form2 = form2;
            Text = _text;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey900, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            listView1.Clear();
            char[] buffer = new char[104857600];
            string text = "";
            FileStream fstream = new FileStream("log.txt", FileMode.Open, FileAccess.Read);
            using (var sr = new StreamReader(fstream))
            {
                int bytesRead = 0;
                while (sr.EndOfStream != true)
                {
                    text = sr.ReadLine();
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = text;
                    listView1.Items.Add(lvi);
                }
            }
            File.WriteAllText("log.txt", string.Empty);
        }
        public void ChangeText(string text)
        {
            Text= text;
        }
        string GetMessageResultRound()
        {
            string text = $"Результаты раунда {5 - form2.form1.facade.GetFight._countMoves}: ";
            if (form2.form1.context.listArmie1.Count == 0 && form2.form1.context.listArmie2.Count == 0) text += "ничья\t\n";
            else if (form2.form1.context.listArmie1.Count == 0) text += "победила армия 2\t\n";
            else if (form2.form1.context.listArmie2.Count == 0) text += "победила армия 1\t\n";
            Text = text;
           //MessageBox.Show(text, "Итоги раунда", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           return text;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Hide(); //form2.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            materialButton1.DialogResult= DialogResult.OK;
        }
    }
}
