using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controlller;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Models;
using GameAboutBattlesOfArmies.BL.Models.Singleton;

namespace GameAboutBattlesOfArmies.BL.Controller
{
    public class Fight
    {
        public string id = Guid.NewGuid().ToString();
        public readonly BattleFieldSingleton singletonField;
        public ArmieController myArmie;
        public ArmieController adversaryArmie;
        public const int COUNT_MOVES = 4;
        public List<IUnit> listArmie1 = new();//{ get => singletonField.Armie1.AllUnits; set=> singletonField.Armie1.AllUnits = value; }
        public List<IUnit> listArmie2 = new();//{ get => singletonField.Armie2.AllUnits; set=> singletonField.Armie2.AllUnits = value; }
        public int[] ResultsMoves = new int[COUNT_MOVES];
        public int _countMoves = COUNT_MOVES;
        public Fight(ArmieController armie1, ArmieController armie2)
        {          
            myArmie = armie1;
            adversaryArmie = armie2;
            singletonField = BattleFieldSingleton.getInstance(armie1.armie, armie2.armie);
           // myArmie.armie = singletonField.Armie1;
           // adversaryArmie.armie = singletonField.Armie2;
            listArmie1 = listArmie1.Concat(singletonField.Armie1.AllUnits).ToList();
            listArmie2 = listArmie2.Concat(singletonField.Armie2.AllUnits).ToList();
        }
        public void UpdateArmies()
        {
            listArmie1.Clear();
            listArmie2.Clear();
            ReturnHPUnits(singletonField.Armie1.AllUnits);
            ReturnHPUnits(singletonField.Armie2.AllUnits);
            listArmie1 = listArmie1.Concat(singletonField.Armie1.AllUnits).ToList();//
            listArmie2 = listArmie2.Concat(singletonField.Armie2.AllUnits).ToList();// 
        }

        public void ReturnHPUnits(List<IUnit> armie)
        {
            for (int i = 0; i < armie.Count; i++)
            {
                if (armie[i].UnitDescriptionId == (int)EnumUnitID.WalkTheCity) armie[i].HitPoints = (int)EnumHP.WalkTheCity;
                if (armie[i].UnitDescriptionId == (int)EnumUnitID.Light) armie[i].HitPoints = (int)EnumHP.Light;
                if (armie[i].UnitDescriptionId == (int)EnumUnitID.Heavy) armie[i].HitPoints = (int)EnumHP.Heavy;
                if (armie[i].UnitDescriptionId == (int)EnumUnitID.Knight) armie[i].HitPoints = (int)EnumHP.Knight;
            }
        }
        public void SummingUpResults(int numberRound)
        {
            if (listArmie1.Count > listArmie2.Count) ResultsMoves[numberRound] = (int)EnumValueResultRound.Победила_армия_1;//win armie1 in round numberRound
            else if (listArmie1.Count < listArmie2.Count) ResultsMoves[numberRound] = (int)EnumValueResultRound.Победила_армия_2;//win armie2 in round numberRound
            else ResultsMoves[numberRound] = (int)EnumValueResultRound.Ничья;//draw in round numberRound
        }
        public string GetResultFight()
        {
            string text = "";
            int countDraw = ResultsMoves.Count(x => x == (int)EnumValueResultRound.Ничья);
            int countWinArmie1 = ResultsMoves.Count(x => x == (int)EnumValueResultRound.Победила_армия_1);
            int countWinArmie2 = ResultsMoves.Count(x => x == (int)EnumValueResultRound.Победила_армия_2);
            var arrCounts = new List<int>() { countDraw, countWinArmie1, countWinArmie2 };
            //var sortArrCounts = arrCounts.OrderByDescending(x => x).ToList();
            if (countWinArmie1>countWinArmie2)
            {
                text = "Победила армия 1\n\n\n";
                Console.WriteLine(text);

            }
            else if (countWinArmie2>countWinArmie1)
            {
                text = "Победила армия 2\n\n\n";
                Console.WriteLine(text);
            }
            else if (countWinArmie1== countWinArmie2)
            {
                text = "Ничья\n\n\n";
                Console.WriteLine(text);
            }
            text += "Результаты раундов: \n\n"; int i = 1;
            foreach (var item in ResultsMoves)
            {
                text +=$"Раунд {i}: "+ ((EnumValueResultRound)item).ToString().Replace('_', ' ')+"\n\n";
                i++;
            }
            
            return text;
        }
        public void GetHistoryResultsMoves()
        {
            Console.WriteLine("Moves:\n");
            foreach (var item in ResultsMoves)
            {
                string text = ((EnumValueResultRound)item).ToString().Replace('_', ' ');
                Console.WriteLine(text+"\n");
            }
                //Console.WriteLine($"{(EnumValueResultRound)item}\n");
        }
    }
}
