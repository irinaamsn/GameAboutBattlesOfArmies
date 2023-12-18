using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller;
using GameAboutBattlesOfArmies.BL.Strategy;
using Microsoft.Extensions.DependencyInjection;

namespace GameAboutBattlesOfArmies.Web
{
    public partial class Main : Form
    {
        public Form1 form1;
       
        bool sideBarExpand;
        public Main(Form1 form)
        {
            InitializeComponent();
            //var materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            form1 = form;
            ShowArmies();
            button2.Enabled = false; 
            button3.Enabled = false;
            sideBar2.Width = sideBar2.MinimumSize.Width;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (form1.context.listArmie1.Count> 0 && form1.context.listArmie2.Count > 0)
            {
                form1.invoker.Run(0);
                ShowArmies();
                Form4 form4 = new Form4(this,"Ход сражения"); 
                DialogResult result=form4.ShowDialog();
              
                if (form1.context.listArmie1.Count == 0 || form1.context.listArmie2.Count == 0)
                {
                    
                    var text=GetMessageResultRound(); 
                    form4.Text = text;
                    
                    MessageBox.Show(text, "Итоги раунда", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (result == DialogResult.OK) Hide();
                    //Form4 form42 = new Form4(this, text);
                    //DialogResult result2 = form42.ShowDialog();
                    //form42.Text = text;
                    //if (result2==DialogResult.OK) Hide();
                }                
            }
            else
            {
                var text = GetMessageResultRound();
                Form4 form4 = new Form4(this,text);
                DialogResult result = form4.ShowDialog();
                if (result == DialogResult.OK) Hide();
            }
            // MessageBox.Show("Вы не выбрали стратегию!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {         
            form1.invoker.Cancel();
            if (form1.invoker._undoStack.Count == 0) button2.Enabled = false;
            button3.Enabled = true;
            ShowArmies(); 
        }
        private void button3_Click(object sender, EventArgs e)
        {
            form1.invoker.Repeat();
            if (form1.invoker._redoStack.Count==0)  button3.Enabled = false;
            button2.Enabled = true;
            ShowArmies(); 

        }
        private void button4_Click(object sender, EventArgs e)
        {
           
            Form3 form3 = new Form3(form1);
            
            if (form1.context.GetStrategy is TurnStrategyRows) form3.ActiveControl = form3.button2;
            else if (form1.context.GetStrategy is TurnStrategyHorizontally) form3.ActiveControl = form3.button1;
            else form3.ActiveControl = form3.button3;
            form1.invoker.Run(1);
            form3.ShowDialog();
            ShowArmies();
            if (!button2.Enabled) button2.Enabled = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ReachTheEnd();
        }
        string GetMessageResultRound()
        {
            string text = $"В раунде {5 - form1.facade.GetFight._countMoves} ";
            if (form1.context.listArmie1.Count == 0 && form1.context.listArmie2.Count == 0) text += "ничья\t\n";
            else if (form1.context.listArmie1.Count == 0) text += "победила армия 2\t\n";
            else if (form1.context.listArmie2.Count == 0) text += "победила армия 1\t\n";
            //MessageBox.Show(text, "Итоги раунда", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return text;
        }
     
        void ReachTheEnd()
        {
            var IsStop = false;  
            var countArmie1 = form1.context.listArmie1.Count; var countArmie2 = form1.context.listArmie2.Count; var timer = 0;

            while (form1.context.listArmie1.Count > 0 && form1.context.listArmie2.Count > 0 && !IsStop && timer <= 15)
            {
                form1.invoker.Run(0);

                if (countArmie1 != form1.context.listArmie1.Count || countArmie2 != form1.context.listArmie2.Count)
                {
                    countArmie1 = form1.context.listArmie1.Count; countArmie2 = form1.context.listArmie2.Count;
                }
                else timer++;
                if (timer > 15) IsStop = true;
            }
            ShowArmies(); 
            if (IsStop)
            {
                MessageBox.Show("С текущей стратегией нельзя дойти до победного!","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                form1.invoker.Run(1);
                Form3 form3 = new Form3(form1);
                form3.ShowDialog();
                ShowArmies(); 
                Form4 form4 = new Form4(this, "Ход сражений");
                form4.Show();               
            }
            else
            {
                var text= GetMessageResultRound();
                Form4 form4 = new Form4(this,text);
                DialogResult result = form4.ShowDialog();
                if (result == DialogResult.OK) Hide();
            }
        }
        void ShowArmies()
        {
            materialLabel3.Text = $"Раунд: {5 - form1.facade.GetFight._countMoves}";
            materialLabel1.Text = form1.context.listArmie1.Count().ToString();
            materialLabel2.Text = form1.context.listArmie2.Count().ToString();
            label1.Text = form1.context.GetStrategy.ToString();
            listView1.Clear(); listView2.Clear();
            listView1.Columns.Add("UnitName", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("HP", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("UnitName", 100, HorizontalAlignment.Center);
            listView2.Columns.Add("HP", 100, HorizontalAlignment.Center);
            foreach (IUnit unit in form1.context.listArmie1)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();

                item.SubItems[0].Text = unit.UnitName;
                item.SubItems.Add(unit.HitPoints.ToString());
                listView1.Items.Add(item);
            }
            foreach (IUnit unit in form1.context.listArmie2)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();

                item.SubItems[0].Text = unit.UnitName;
                item.SubItems.Add(unit.HitPoints.ToString());
                listView2.Items.Add(item);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sideBarExpand)
            {
                sideBar2.Width -= 15;
                if (sideBar2.Width == sideBar2.MinimumSize.Width)
                {
                    sideBarExpand = false;
                    timer1.Stop();
                }
            }
            else
            {
                sideBar2.Width += 15;
                if (sideBar2.Width == sideBar2.MaximumSize.Width)
                {
                    sideBarExpand = true;
                    timer1.Stop();
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(label1, "Текущая стратегия");

        }

        private void sideBar2_MouseHover(object sender, EventArgs e)
        {
            //while (sideBar2.Width != sideBar2.MaximumSize.Width)
            //{
            //    sideBar2.Width += 15;
            //}
        }

        private void sideBar2_MouseLeave(object sender, EventArgs e)
        {
            //while (sideBar2.Width != sideBar2.MinimumSize.Width)
            //{
            //    sideBar2.Width -= 15;
            //}
        }
    }
}
