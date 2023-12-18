using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller;
using GameAboutBattlesOfArmies.BL.Enums;


namespace GameAboutBattlesOfArmies.BL.Strategy
{
    public class TurnStrategyVertically:ITurnStrategy
    { 
        public List<IUnit> listArmie1 { get; set; }
        public List<IUnit> listArmie2 { get; set; }
        public bool chet { get; set; }
        public TurnStrategyVertically(Fight fight)
        {
            listArmie1 = fight.listArmie1;
            listArmie2 = fight.listArmie2;
            chet = fight._countMoves % 2 == 0;
        }

        public void TurnArmies()
        {   
            (bool, IUnit,int) unitRes; 
            if (chet)
            {
                for (int i=0, j=0; i < listArmie1.Count || j < listArmie2.Count; j++, i++)
                {
                    if (i < listArmie1.Count && listArmie1[i].HitPoints > 0)
                    {
                        if (i < listArmie2.Count && listArmie2[j].HitPoints > 0)
                        {
                            unitRes = listArmie2[j].TryingKill(listArmie1[i]);
                            if (unitRes.Item1) listArmie2[j] = unitRes.Item2;
                            //if (unitRes.Item2.HitPoints > 0)//
                            //{
                            //    unitRes = listArmie1[i].TryingKill(listArmie2[j]);
                            //    if (unitRes.Item1) listArmie1[i] = unitRes.Item2;
                            //}
                        }
                        else UnitSATryDoAction(listArmie1[i], listArmie1, listArmie2, true);
                    }

                    if (i < listArmie2.Count && listArmie2[j].HitPoints > 0)
                    {
                        if (i < listArmie1.Count && listArmie1[i].HitPoints > 0)
                        {
                            unitRes = listArmie1[i].TryingKill(listArmie2[j]);
                            if (unitRes.Item1) listArmie1[i] = unitRes.Item2;
                            //if (unitRes.Item2.HitPoints > 0)//
                            //{
                            //    unitRes = listArmie1[i].TryingKill(listArmie2[j]);
                            //    if (unitRes.Item1) listArmie1[i] = unitRes.Item2;
                            //}
                        }
                        else UnitSATryDoAction(listArmie2[j], listArmie2,listArmie1, false);
                    }                   
                }                           
            }
            else
            {
                for (int i = 0, j = 0; i < listArmie1.Count || j < listArmie2.Count; j++, i++)
                {

                    if (j < listArmie2.Count && listArmie2[j]?.HitPoints > 0)
                    {
                        if (i < listArmie1.Count && listArmie1[i]?.HitPoints > 0)
                        {
                            unitRes = listArmie1[i].TryingKill(listArmie2[j]);
                            if (unitRes.Item1) listArmie1[i] = unitRes.Item2;
                        }
                        else UnitSATryDoAction(listArmie2[j], listArmie2, listArmie1, false);
                    }
                    if (i < listArmie1.Count && listArmie1[i]?.HitPoints > 0)
                    {
                        if (j < listArmie2.Count && listArmie2[j]?.HitPoints > 0)
                        {
                            unitRes = listArmie2[j].TryingKill(listArmie1[i]);
                            if (unitRes.Item1) listArmie2[j] = unitRes.Item2;
                        }
                        else UnitSATryDoAction(listArmie1[i], listArmie1, listArmie2, true);
                    }
                }
            }
            
        }
      
        public void UnitSATryDoAction(IUnit unit, List<IUnit> myArmie, List<IUnit> enemyArmie, bool isEven)
        {
            var unitSA = unit.IsSpecialAbility();
            if (unitSA?.SpecialAbilityType == (int)EnumSAType.Archer)
            {
                ArcherTryShoot(unit, myArmie, enemyArmie);//??
            }
            else if (unitSA?.SpecialAbilityType == (int)EnumSAType.Healer)
            {
                HealerTryHeal(unit, myArmie);
            }
            else if (unitSA?.SpecialAbilityType == (int)EnumSAType.Witcher)
            {
                WitcherTryClone(unit, myArmie);
            }
            else if (unitSA?.SpecialAbilityType == (int)EnumSAType.Buf)
            {
                BufTryWear(unit, myArmie);
            }
        }

        public void BufTryWear(IUnit unit, List<IUnit> myArmie)//??
        {
            var findIndex = myArmie.FindIndex(x => x == unit);//find index unitSA in myArmie
            var buf = unit.IsSpecialAbility();
            if (myArmie[findIndex - buf.SpecialAbilityRange].IsSpecialAbility() == null && myArmie[findIndex - buf.SpecialAbilityRange].HitPoints > 0)
            {
                //if ( hasBuf.CanWearBuf())
                //{
                var heavyBuf = buf.DoAction(myArmie[findIndex - buf.SpecialAbilityRange]);
                //var hit = new Hit(buf, myArmie[findIndex - buf.SpecialAbilityRange]);
                //var heavyBuf = hit.UnitSATryAction();
                if (heavyBuf != null) myArmie[findIndex - buf.SpecialAbilityRange] = heavyBuf;
                //}

            }
        }
        public void ArcherTryShoot(IUnit unit, List<IUnit> myArmie, List<IUnit> enemyArmie)
        {
            var findIndex = myArmie.FindIndex(x => x == unit);//find index unitSA in myArmie
            var archer = unit.IsSpecialAbility();
            for (var i = findIndex -archer.SpecialAbilityRange; i < findIndex + archer.SpecialAbilityRange && i < enemyArmie.Count && i>-1; i++)//TODO
            {
                if (/*i>-1 &&*/ enemyArmie[i].HitPoints > 0 )
                {
                    /*Skipped*/
      
                    archer.DoAction(enemyArmie[i]);
                    break;
                }

            }
        }
        public void HealerTryHeal(IUnit unit, List<IUnit> myArmie)
        {
            var positionHealer = myArmie.FindIndex(x => x == unit);
            var healer = unit.IsSpecialAbility();
            //for (var i = positionHealer + 1; i <= positionHealer + healer.SpecialAbilityRange && i<myArmie.Count; i++)//TODO//если он лечит тех кто перед ним
            for (var i = positionHealer - healer.SpecialAbilityRange; i < positionHealer+healer.SpecialAbilityRange && i<myArmie.Count; i++)
            {

                if (i >= 0 && myArmie[i].HitPoints > 0 && myArmie[i] != unit)
                {
                    // var hit = new Hit(healer, myArmie[i]);
                    //hit.UnitSATryAction();

                    var healerable = healer.DoAction(myArmie[i]);
                    if (healerable != null) break;
                    //break;
                }
            }
        }
        public void WitcherTryClone(IUnit unit, List<IUnit> myArmie)
        {
            var positionWitcher = myArmie.FindIndex(x => x == unit);
            var witcher = unit.IsSpecialAbility();
            for (var i = positionWitcher - witcher.SpecialAbilityRange; i < positionWitcher + witcher.SpecialAbilityRange; i++)//TODO//Strength??
            {
                if (i > -1 && i < myArmie.Count)
                {
                    if (myArmie[i] != unit && myArmie[i].HitPoints > 0)
                    {
                        //var hit = new Hit(witcher, myArmie[i]);
                        //var unitClone = hit.UnitSATryAction();
                        var unitClone = witcher.DoAction(myArmie[i]);
                        if (unitClone != null)
                        {
                            myArmie.Insert(positionWitcher - 1, unitClone);//перед ним
                            break;
                        }
                    }
                }
            }
        }
        public override string ToString()
        {
            return "вертикальная";
        }

    }
}

