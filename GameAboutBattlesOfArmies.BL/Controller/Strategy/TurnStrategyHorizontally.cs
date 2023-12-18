using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller;
using GameAboutBattlesOfArmies.BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Strategy
{
    public class TurnStrategyHorizontally:ITurnStrategy
    {
      
        public List<IUnit> listArmie1 { get; set; }
        public List<IUnit> listArmie2 { get; set; }        
        public bool chet { get; set; }
        public TurnStrategyHorizontally(Fight fight)
        {
            listArmie1 = fight.listArmie1;
            listArmie2 = fight.listArmie2;
            chet = fight._countMoves%2==0;
        }

        public void TurnArmies()
        {
            var listUnitSA1 = FindAllUnitSA(listArmie1); var listUnitSA2 = FindAllUnitSA(listArmie2);
            if (chet)
            {
                //var hit = new Hit(unit2, unit1);
                //hit.UnitTryKill();//trykill
                //var hit2 = new Hit(unit1, unit2);
                //hit2.UnitTryKill();//trykill
                var unitRes = listArmie2[0].TryingKill(listArmie1[0]);
                if (unitRes.Item1) listArmie2[0] = unitRes.Item2;
                if (unitRes.Item2.HitPoints > 0)//
                {
                    unitRes = listArmie1[0].TryingKill(listArmie2[0]);
                    if (unitRes.Item1) listArmie1[0] = unitRes.Item2;
                }
                for (int j = 0, i = 0; j < listUnitSA2.ToList().Count || i < listUnitSA1.ToList().Count; j++, i++)
                {
                    if (i < listUnitSA1.ToList().Count) UnitSATryDoAction(listUnitSA1.ToList()[i], listArmie1, true);
                    if (j < listUnitSA2.ToList().Count) UnitSATryDoAction(listUnitSA2.ToList()[j], listArmie2, false);
                }
            }
            else
            {
                var unitRes = listArmie1[0].TryingKill(listArmie2[0]);
                if (unitRes.Item1) listArmie2[0] = unitRes.Item2;
                if (unitRes.Item2.HitPoints > 0)
                {
                    unitRes = listArmie2[0].TryingKill(listArmie1[0]);
                    if (unitRes.Item1) listArmie1[0] = unitRes.Item2;
                }
                //var hit = new Hit(unit2, unit1);
                //hit.UnitTryKill();//trykill
                //var hit2 = new Hit(unit1, unit2);
                //hit2.UnitTryKill();//trykill
                for (int j = 0, i = 0; j < listUnitSA2.ToList().Count || i < listUnitSA1.ToList().Count; j++, i++)
                {
                    if (j < listUnitSA2.ToList().Count) UnitSATryDoAction(listUnitSA2.ToList()[j], listArmie2, false);
                    if (i < listUnitSA1.ToList().Count) UnitSATryDoAction(listUnitSA1.ToList()[i], listArmie1, true);
                }
            }           
        }
       
        public void UnitSATryDoAction(IUnit unit, List<IUnit> myArmie, bool isEven)
        {
            var unitSA = unit.IsSpecialAbility();
            if (unitSA.SpecialAbilityType == (int)EnumSAType.Archer)
            {
                ArcherTryShoot(unit, myArmie, CreateAllArmies(isEven, listArmie1, listArmie2).ToList());
            }
            else if (unitSA.SpecialAbilityType == (int)EnumSAType.Healer)
            {
                HealerTryHeal(unit, myArmie);
            }
            else if (unitSA.SpecialAbilityType == (int)EnumSAType.Witcher)
            {
                WitcherTryClone(unit, myArmie);
            }
            else if (unitSA.SpecialAbilityType == (int)EnumSAType.Buf)
            {
                BufTryWear(unit, myArmie);
            }
        }

        public IEnumerable<IUnit> CreateAllArmies(bool isEven, List<IUnit> listArmie1, List<IUnit> listArmie2)
        {
            listArmie1.Reverse();
            var allMembers = listArmie1.Concat(listArmie2).ToList();//union armie1 and armie2
            if (!isEven) allMembers.Reverse();
            listArmie1.Reverse();
            return allMembers;
        }
        public void BufTryWear(IUnit unit, List<IUnit> myArmie)
        {
            var findIndex = myArmie.FindIndex(x => x == unit);//find index unitSA in myArmie
            var buf = unit.IsSpecialAbility();
            if (myArmie[findIndex - buf.SpecialAbilityRange].IsSpecialAbility() == null && myArmie[findIndex - buf.SpecialAbilityRange].HitPoints > 0)
            {
                var heavyBuf = buf.DoAction(myArmie[findIndex - buf.SpecialAbilityRange]);
                if (heavyBuf != null) myArmie[findIndex - buf.SpecialAbilityRange] = heavyBuf;             
            }
        }
        public void ArcherTryShoot(IUnit unit, List<IUnit> myArmie, List<IUnit> allMembers)
        {
            var findIndex = allMembers.FindIndex(x => x == unit);//find index unitSA in allMembers
            var archer = unit.IsSpecialAbility();
            for (var i = findIndex + 1; i <= findIndex + archer.SpecialAbilityRange && i < allMembers.Count; i++)//TODO
            {
                if (myArmie.SingleOrDefault(x => x == allMembers[i]) == null && allMembers[i].HitPoints > 0)
                {
                    //var hit = new Hit(archer, allMembers[i] );
                    //hit.UnitSATryAction();
                    archer.DoAction(allMembers[i]);
                    break;
                }
            }
        }
        public void HealerTryHeal(IUnit unit, List<IUnit> myArmie)
        {
            var positionHealer = myArmie.FindIndex(x => x == unit);
            var healer = unit.IsSpecialAbility();
            //for (var i = positionHealer + 1; i <= positionHealer + healer.SpecialAbilityRange && i<myArmie.Count; i++)//TODO//если он лечит тех кто перед ним
            for (var i = positionHealer - healer.SpecialAbilityRange; i < positionHealer; i++)//TODO//если он лечит тех кто за ним
            {
                if (i >= 0 && myArmie[i].HitPoints > 0)
                {
                    // var hit = new Hit(healer, myArmie[i]);
                    //hit.UnitSATryAction();
                    var healerable = healer.DoAction(myArmie[i]);
                    if (healerable != null) break;
                }
            }
        }
        public void WitcherTryClone(IUnit unit, List<IUnit> myArmie)
        {
            var positionWitcher = myArmie.FindIndex(x => x == unit);
            var witcher = unit.IsSpecialAbility();
            for (var i = positionWitcher - witcher.SpecialAbilityStrength; i <= positionWitcher + witcher.SpecialAbilityStrength; i++)//TODO//Strength??
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
                            myArmie.Insert(positionWitcher, unitClone);//перед ним
                            break;
                        }
                    }
                }
            }
        }
        public IEnumerable<IUnit> FindAllUnitSA(List<IUnit> listArmie)
        {
            var list = new List<IUnit>();
            for (var i = 1; i < listArmie.Count; i++)
            {
                var unitSA = listArmie[i].IsSpecialAbility();
                if (unitSA != null)
                    list.Add(listArmie[i]);
            }
            return list;
        }
        public override string ToString()
        {
            return "горизонтальная";
        }
    }
}

