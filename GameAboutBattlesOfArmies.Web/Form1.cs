using AutoMapper;
using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller;
using GameAboutBattlesOfArmies.BL.Controller.Command;
using GameAboutBattlesOfArmies.BL.Controlller;
using GameAboutBattlesOfArmies.BL.Models.Repository;
using GameAboutBattlesOfArmies.Settings;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;

//using Microsoft.Extensions.DependencyInjection;

namespace GameAboutBattlesOfArmies.Web
{
    public partial class Form1 : MaterialForm
    {       
        ArmieController armie1;//my armie
        ArmieController armie2;
        static Configuration _configuration;
        public IServiceProvider serviceProvider;
        public IFightFacade facade;
        public Invoker invoker;
        public ICommand turnCommand;
        public ICommand strategyCommand;
        public ContextTurn context;
        IMapper mapper;

        public Form1()
        {
            InitializeComponent();
           
            _configuration = new Configuration();
            serviceProvider = _configuration.Setup();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey800, Primary.Grey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            mapper = serviceProvider.GetRequiredService<IMapper>();
            var fight = serviceProvider.GetRequiredService<Fight>();
            armie1 = fight.myArmie;
            armie2 = fight.adversaryArmie;
            fight.myArmie.ArmiePrice = Convert.ToInt32(materialTextBox1.Text);
            fight.myArmie.armie.ArmiePrice = Convert.ToInt32(materialTextBox1.Text);
            fight.adversaryArmie.ArmiePrice = Convert.ToInt32(materialTextBox2.Text);
            fight.adversaryArmie.armie.ArmiePrice = Convert.ToInt32(materialTextBox2.Text);
            //using (var scope  = serviceProvider.CreateScope())
            //{
            //    armie1 = scope.ServiceProvider.GetService<ArmieController>();
            //    armie1.ArmiePrice = Convert.ToInt32(materialTextBox1.Text);
            //    armie1.armie.ArmiePrice = Convert.ToInt32(materialTextBox1.Text);
            //}
            //using (var scope = serviceProvider.CreateScope())
            //{
            //    armie2 = scope.ServiceProvider.GetService<ArmieController>();
            //    armie2.ArmiePrice = Convert.ToInt32(materialTextBox2.Text);
            //    armie2.armie.ArmiePrice = Convert.ToInt32(materialTextBox2.Text);
            //}

            // armie1 = new ArmieController();
            // armie2 = new ArmieController();
            //invoker = new Invoker();
            materialButton2.Enabled = false;
            
        }
         private void materialTextBox1_Leave(object sender, EventArgs e)
         {           
            try
            {
                if (!int.TryParse(materialTextBox1.Text, out int value))
                    throw new TextBoxException("Некорректный ввод!");
                else if (value > 1000 || value < 100)
                    throw new TextBoxException($"Введите стоимость армии от 100 до 1000: ");
                armie1.ArmiePrice = Convert.ToInt32(materialTextBox1.Text);
                armie1.armie.ArmiePrice = Convert.ToInt32(materialTextBox1.Text);
               
            }
            catch (TextBoxException ex)
            {
                MessageBox.Show(ex.Message + ex.ValueTextBox, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         } 
        private void materialTextBox2_Leave(object sender, EventArgs e)
        {
            try
            {
                if ( !int.TryParse(materialTextBox2.Text, out int value2))
                    throw new TextBoxException("Некорректный ввод!");
                else if (value2 > 1000 || value2 < 100)
                    throw new TextBoxException($"Введите стоимость армии от 100 до 1000: ");
                armie2.ArmiePrice = Convert.ToInt32(materialTextBox2.Text);
                armie2.armie.ArmiePrice = Convert.ToInt32(materialTextBox2.Text);
                //armie2.armie.TeamName = "Армия 2";
            }
            catch (TextBoxException ex)
            {
                MessageBox.Show(ex.Message + ex.ValueTextBox, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(materialTextBox1.Text, out int value) || !int.TryParse(materialTextBox2.Text, out int value2))
                    throw new TextBoxException("Некорректный ввод!");
                else if (value > 1000 || value < 100 || value2 > 1000 || value2 < 100)
                    throw new TextBoxException($"Введите cтоимость армии от 100 до 1000: ");

                facade = serviceProvider.GetRequiredService<IFightFacade>();
                
                //armie1 = facade.GetArmie1;
                //armie2 = facade.GetArmie2;
                // listView1.Columns.Add("Armie", 80, HorizontalAlignment.Center);
                listView1.Columns.Add("UnitName", 100, HorizontalAlignment.Center);
                listView1.Columns.Add("HP", 100, HorizontalAlignment.Center);
               //listView2.Columns.Add("Armie", 80, HorizontalAlignment.Center);
                listView2.Columns.Add("UnitName", 100, HorizontalAlignment.Center);
                listView2.Columns.Add("HP", 100, HorizontalAlignment.Center);
                foreach (IUnit unit in armie1.armie.AllUnits)
                {
                    unit.MyArmie.TeamName = "Армия 1";
                    var unitModel = mapper.Map<IUnit, UnitModel>(unit);
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Clear();
                    
                    item.SubItems[0].Text = unitModel.FullName;
                    //item.SubItems.Add(unit.UnitName);
                    item.SubItems.Add(unitModel.HitPoints.ToString());
                    listView1.Items.Add(item);
                    // ListViewItem lvi = new ListViewItem();

                    //lvi.Text = unit.UnitName + "\t|\t", + "HP: " + unit.HitPoints.ToString();
                    //  listView1.Items.Add(unit.UnitName, unit.HitPoints.ToString());
                    // listView1.Items.Add(//lvi);
                    //i++;
                }
                foreach (IUnit unit in armie2.armie.AllUnits)
                {
                    //ListViewItem lvii = new ListViewItem();
                    //lvii.Text = unit.UnitName + "\t|\t" + "HP: " + unit.HitPoints.ToString();
                    //listView2.Items.Add(lvii);
                    unit.MyArmie.TeamName = "Армия 2";
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Clear();

                    item.SubItems[0].Text = unit.UnitName;
                  //  item.SubItems.Add(unit.UnitName);
                    item.SubItems.Add(unit.HitPoints.ToString());
                    listView2.Items.Add(item);
                }
                materialButton1.Enabled = false;
                materialButton2.Enabled = true;
                materialTextBox1.Enabled= false;
                materialTextBox2.Enabled = false;
            }
            catch (TextBoxException ex)
            {
                MessageBox.Show(ex.Message + ex.ValueTextBox, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }   
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Hide();           
            string text; 
            while (facade.GetFight._countMoves > 0)
            {
                //turn = new TurnStrategyRows(singleton.Armie1.AllUnits, singleton.Armie2.AllUnits, _countMoves % 2 == 0);//по умолчанию
               
                using (var scope = serviceProvider.CreateScope())
                {
                    context = scope.ServiceProvider.GetRequiredService<ContextTurn>();
                    var listCommand = scope.ServiceProvider.GetRequiredService<IEnumerable<ICommand>>();
                    turnCommand = listCommand.First();
                    strategyCommand = listCommand.Last();
                    invoker = scope.ServiceProvider.GetRequiredService<Invoker>();
                    invoker.SetCommand(0, turnCommand);
                    invoker.SetCommand(1, strategyCommand);
                    while (context.listArmie1.Count > 0 && context.listArmie2.Count > 0)
                    {
                        Main f2 = new Main(this);
                        f2.ShowDialog();
                    }
                }
                
                facade.GetFight.SummingUpResults(Fight.COUNT_MOVES - facade.GetFight._countMoves);
                facade.GetFight.UpdateArmies();
                facade.GetFight._countMoves--;
                ///skipped               
            }
                var textEnd = "Game Over";
                var result = facade.GetFight.GetResultFight(); textEnd += "\n" + result;
                MessageBox.Show(textEnd.ToUpper(), "Итоги игры", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Application.Exit();
        }
    }
}