using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller;
using GameAboutBattlesOfArmies.BL.Strategy;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace GameAboutBattlesOfArmies.Web
{
    public partial class Form3 : MaterialForm
    {
        Form1 form1;
        
        public Form3(Form1 form)
        {
            InitializeComponent();
            form1 = form;
            //var context = form1.serviceProvider.GetRequiredService<ContextTurn>();
            //if (context.GetStrategy is TurnStrategyRows) ActiveControl = button2;
            //else if (context.GetStrategy is TurnStrategyHorizontally) ActiveControl = button1;
            //else ActiveControl = button3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var strategyList = form1.serviceProvider.GetRequiredService<IEnumerable<ITurnStrategy>>();
            foreach (var strategy in strategyList)
            {
                if (strategy is TurnStrategyHorizontally) form1.context.ChangeStrategy(strategy);
            }
           // ITurnStrategy strategy = new TurnStrategyHorizontally(form1.facade.GetFight);
           
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var strategyList = form1.serviceProvider.GetRequiredService<IEnumerable<ITurnStrategy>>();
            foreach (var strategy in strategyList)
            {
                if (strategy is TurnStrategyRows) form1.context.ChangeStrategy(strategy);
            }
            //ITurnStrategy strategy = new TurnStrategyRows(form1.facade.GetFight);
            //form1.context.ChangeStrategy(strategy);
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var strategyList = form1.serviceProvider.GetRequiredService<IEnumerable<ITurnStrategy>>();
            foreach (var strategy in strategyList)
            {
                if (strategy is TurnStrategyVertically) form1.context.ChangeStrategy(strategy);
            }
            //ITurnStrategy strategy = new TurnStrategyVertically(form1.facade.GetFight);
            //form1.context.ChangeStrategy(strategy);
            Hide();
        }
    }
}
