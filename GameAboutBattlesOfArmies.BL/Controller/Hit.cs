using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.SADecorator;

namespace GameAboutBattlesOfArmies.BL.Controller
{
    public class Hit
    {
        public IUnit Unit1 { get; set; }
        public IUnit Unit2 { get; set; }
        public Hit (IUnit unit1, IUnit unit2)
        {
            Unit1 = unit1;
            Unit2 = unit2;            
        }
        public void UnitTryKill()//TODO//name 
        {
            Unit1.TryingKill(Unit2);          
        }
        public IUnit UnitSATryAction()
        {
            UnitDecoratorBase unit1SA = (UnitDecoratorBase)Unit1;
            var unit =  unit1SA.DoAction(Unit2);   
            return unit;
        }
        //public (bool, IUnit) TryTakeOffBuf(IUnit unit)
        //{
        //    if (unit is BufDecorator unitBuf)
        //    {
        //        if (unitBuf.IsWearBuf)//??
        //        {
        //            var rnd = new Random();
        //            var num = rnd.Next(0, 100);
        //            if (num < 10 || num > 0)
        //            {
        //                unitBuf.IsWearBuf = false;
        //                //unit = unitBuf.GetOriginalHeavy();
        //                //unitBuf.IsWearBuf = false;//take off buf
        //                //if (unitBuf.MyBuf == (int)EnumBufes.Hourse) unit.Attack -= unitBuf.MyBuf;
        //                //else unit.Defence -= unitBuf.MyBuf;
        //                //loggerService.TryTakeOffBuflog(unit);
        //                return (true, unitBuf.GetOriginalHeavy());
        //            }
        //        }
        //    }
        //    return (false, unit);
        //}
        //public void BattleWithoutUnitsSA(ISpecialAbility unitSA, bool isEven, List<IUnit> myArmie)//
        //{
        //    if (unitSA.SpecialAbilityType == (int)EnumSAType.Archer)
        //    {
        //        ArcherTryShoot(unitSA, myArmie, CreateAllArmies(isEven, listArmie1, listArmie2).ToList());
        //    }
        //    else if (unitSA.SpecialAbilityType == (int)EnumSAType.Healer)
        //    {
        //        HealerTryHeal(unitSA, myArmie);
        //    }
        //    else if (unitSA.SpecialAbilityType == (int)EnumSAType.Witcher)
        //    {
        //        WitcherTryClone(unitSA, myArmie);
        //    }
        //}

    }
}
