using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller;
using GameAboutBattlesOfArmies.BL.Enums;
using System.Security.Cryptography.X509Certificates;

namespace GameAboutBattlesOfArmies.BL.Strategy
{
    public class TurnStrategyRows:ITurnStrategy
    {
        public Stack<(List<(IUnit, int)>[], List<IUnit>, List<IUnit>)> history1 =new Stack<(List<(IUnit, int)>[], List<IUnit>, List<IUnit>)>();
        public Stack<(List<(IUnit, int)>[], List<IUnit>, List<IUnit>)> history2 = new Stack<(List<(IUnit, int)>[], List<IUnit>, List<IUnit>)>();
        public List<IUnit> listArmie1 { get; set; }
        public List<IUnit> listArmie2 { get; set; }
        List<(IUnit, int)>[] myArr1;// = new List<(IUnit, int)>[3];
        List<(IUnit, int)>[] myArr2;// = new List<(IUnit, int)>[3];
        public bool chet { get; set; }
        public TurnStrategyRows(Fight fight)
        {
            myArr1 = new List<(IUnit, int)>[3];
            myArr2 = new List<(IUnit, int)>[3];
            listArmie1 = fight.listArmie1;
            listArmie2 = fight.listArmie2;
            chet = fight._countMoves % 2 == 0;
            myArr1 = BuildArmie(listArmie1, true);
            myArr2 = BuildArmie(listArmie2, false);

            PushStack();
        }
        public void PushStack()
        {
            List<IUnit> list1 = new List<IUnit>();
            List<IUnit> list2 = new List<IUnit>();
            List<(IUnit, int)>[] arr1 = new List<(IUnit, int)>[3];
            List<(IUnit, int)>[] arr2 = new List<(IUnit, int)>[3];
            //listArmie1.ForEach(x => list1.Add((IUnit)x.Clone()));
            //listArmie2.ForEach(x => list2.Add((IUnit)x.Clone()));
            arr1[0] = new List<(IUnit, int)>();
            arr1[1] = new List<(IUnit, int)>();
            arr1[2] = new List<(IUnit, int)>();
            arr2[0] = new List<(IUnit, int)>();
            arr2[1] = new List<(IUnit, int)>();
            arr2[2] = new List<(IUnit, int)>();
         
           
            for (int i = 0; i < 3; i++)
            {
                myArr1[i].ForEach(x => {
                    if (x != (null, 0))
                    {
                        var u = (IUnit)x.Item1;
                        arr1[i].Add((u, 0));
                        list1.Add(u);
                    }
                    else arr1[i].Add((null, 0));
                    
                });
                myArr2[i].ForEach(x => {
                    if (x != (null, 0))
                    {
                        var u = (IUnit)x.Item1;
                        arr2[i].Add((u, 0));
                        list2.Add(u);
                    }
                    else arr2[i].Add((null, 0));
                });
            }
            history1.Push((arr1, list1,listArmie1));
            history2.Push((arr2,list2, listArmie2));
        }
    
        public void ShiftArmies(List<(IUnit, int)>[] armie, int row )        
        {
            List<(IUnit,int)> temp;
                       
            for (int i = row; i < 2; i++)
            {
                temp=armie[i];
                armie[i] = armie[i + 1];
                armie[i + 1] = temp;
                //for (int j = 0; j < armie[row].Count; j++)
                //{
                //    armie[row][j] = armie[row + 1][j];
                //}
            }

        }
        public List<(IUnit, int)>[] BuildArmie(List<IUnit> armie, bool Isarmie)
        {
            List<(IUnit, int)>[] arr = new List<(IUnit, int)>[3];
            var count = 0; 

            var list1 = new List<(IUnit, int)>();
            var list2 = new List<(IUnit, int)>();
            var list3 = new List<(IUnit, int)>();
            int num = 3;

            while(count<armie.Count-2)
            {
                list1.Add((armie[count],0));
                list2.Add((armie[count+1],1));
                list3.Add((armie[count+2],2));
                count+=3;
            }
            while (count < armie.Count - 1)
            {
                list1.Add((armie[count], 0));
                list2.Add((armie[count+1], 1));
                count += 2;
            }
            while (count < armie.Count)
            {
                list1.Add((armie[count], 0));
                count ++;
            }
            arr[0] =new List<(IUnit, int)>();
            arr[1] = new List<(IUnit, int)>();
            arr[2] = new List<(IUnit, int)>();

            for (int i=0;i<list1.Count;i++) arr[0].Add(list1[i]);
            for (int i = 0; i < list2.Count; i++) arr[1].Add(list2[i]);
            for (int i = 0; i < list3.Count; i++) arr[2].Add(list3[i]);
       
            if (Isarmie)
            {
                arr[0].Reverse(); arr[1].Reverse(); arr[2].Reverse();
            }
            if (arr[0].Count == 0) arr[0].Add((null, 0)); if (arr[1].Count == 0) arr[1].Add((null, 0)); if (arr[2].Count == 0) arr[2].Add((null, 0));
            AddRow(arr, Isarmie);
            return arr;
        }
        public void AddRow(List<(IUnit,int)>[] arr, bool armie)
        {
            var countArr1 = arr[0].Count; var countArr2 = arr[1].Count; var countArr3 = arr[2].Count; int maxCountArr = 0; int maxRow = -1;
            if (countArr1 > maxCountArr) {
                maxCountArr = countArr1;
                maxRow = 0;
            }
            if (countArr2 > maxCountArr) {
                maxCountArr = countArr2;
                maxRow = 1;
            }
            if (countArr3 > maxCountArr) {
                maxCountArr = countArr3;
                maxRow = 2;
            }
            if (arr[maxRow][maxCountArr - 1].Item1 == null)
            {
                arr[maxRow].Remove(arr[maxRow][maxCountArr - 1]);
                maxCountArr --;
            }
            if (armie)
            {
                while (arr[0].Count < maxCountArr) arr[0].Insert(0,(null, 0));
                while (arr[1].Count < maxCountArr) arr[1].Insert(0,(null, 0));
                while (arr[2].Count < maxCountArr) arr[2].Insert(0,(null, 0));
            }
            else
            {
                while (arr[0].Count < maxCountArr) arr[0].Add((null, 0));
                while (arr[1].Count < maxCountArr) arr[1].Add((null, 0));
                while (arr[2].Count < maxCountArr) arr[2].Add((null, 0));
            }
        }

        public void FightFirstUnits( (IUnit,int) unit1,  (IUnit,int) unit2, bool isArmie)
        {
            (bool, IUnit,int) unitRes;
            if (unit1.Item1?.HitPoints>0)
            {
                if (unit2.Item1?.HitPoints > 0)
                {
                    unitRes = unit2.Item1.TryingKill(unit1.Item1);
                    if (unitRes.Item1)
                    {
                        if (listArmie1.FindIndex(x => x == unit2.Item1) != -1)
                        {
                           
                            try
                            {
                                listArmie1[listArmie1.FindIndex(x => x == unit2.Item1)] = unitRes.Item2;
                                myArr1[unit2.Item2][myArr1[unit2.Item2].FindIndex(X => X.Item1 == unit2.Item1)] = (unitRes.Item2,unit2.Item2);
                            }
                            catch(Exception ex) { }
                           
                        }
                        else
                        {
                            try
                            {
                                listArmie2[listArmie2.FindIndex(x => x == unit2.Item1)] = unitRes.Item2;
                                myArr2[unit2.Item2][myArr2[unit2.Item2].FindIndex(X => X.Item1 == unit2.Item1)] = (unitRes.Item2,unit2.Item2);
                            }
                            catch (Exception ex) { }
                        }
                        // unit2 = unitRes.Item2;
                    }
                }
                else
                {
                    if (isArmie) UnitTryDoAction(unit1, myArr1, myArr2, isArmie);
                    else UnitTryDoAction(unit1, myArr2, myArr1, isArmie);
                }
            }             
        }
        public bool Check()
        {
            var h1 = history1.Peek(); var h2 = history2.Peek();
            for (int i = 0, j = 0; j < listArmie1.ToList().Count || i < h1.Item3.Count; j++, i++)
            {
                if (listArmie1[i] != h1.Item3[j]) return false;
            }
            for (int i = 0, j = 0; j < listArmie2.ToList().Count || i < h2.Item3.Count; j++, i++)
            {
                if (listArmie2[i] != h2.Item3[j]) return false;
            }
            return true;
        }
        public void TurnArmies()
        {
            if (!Check())
            {
                // var p1 = history1.Pop(); var p2 = history2.Pop();
                myArr1 = BuildArmie(listArmie1, true);
                myArr2 = BuildArmie(listArmie2, false);
                //var h1 = history1.Peek(); var h2 = history2.Peek();
                //myArr1 = h1.Item1; myArr2 = h2.Item1;
                //listArmie1 = h1.Item2;
                //listArmie2 = h2.Item2;
            }

            var count1 = myArr1[0].Count; var count2 = myArr1[1].Count; var count3 = myArr1[2].Count; var count11 = myArr2[0].Count; var count22 = myArr2[1].Count; var count33 = myArr2[2].Count;
            var listMyArmie = FindAllUnitSA(myArr1, true); var listEnemyArmie = FindAllUnitSA(myArr2, false);
            (bool, IUnit) unitRes;
            if (chet)
            {
                FightFirstUnits( myArr1[0][count1 - 1], myArr2[0][0], true); FightFirstUnits(myArr2[0][0], myArr1[0][count1 - 1], false);
                FightFirstUnits(myArr1[1][count2 - 1], myArr2[1][0], true); FightFirstUnits(myArr2[1][0], myArr1[1][count2 - 1], false);
                FightFirstUnits(myArr1[2][count3 - 1], myArr2[2][0], true); FightFirstUnits(myArr2[2][0], myArr1[2][count3 - 1], false);
                for (int j = 0, i = 0; j < listEnemyArmie.ToList().Count || i < listMyArmie.ToList().Count; j++, i++)
                {
                    if (i < listMyArmie.ToList().Count) UnitTryDoAction(listMyArmie.ToList()[i], myArr1, myArr2, true);
                    if (j < listEnemyArmie.ToList().Count) UnitTryDoAction(listEnemyArmie.ToList()[j], myArr2, myArr1, false);
                }            
            }
            else
            {
                FightFirstUnits(myArr2[0][0], myArr1[0][count1 - 1], false); FightFirstUnits(myArr1[0][count1 - 1], myArr2[0][0], true);
                FightFirstUnits(myArr2[1][0], myArr1[1][count2 - 1], false); FightFirstUnits(myArr1[1][count2 - 1], myArr2[1][0], true);
                FightFirstUnits(myArr2[2][0], myArr1[2][count3 - 1], false); FightFirstUnits(myArr1[2][count3 - 1], myArr2[2][0], true);
                for (int j = 0, i = 0; j < listEnemyArmie.ToList().Count || i < listMyArmie.ToList().Count; j++, i++)
                {                    
                    if (j < listEnemyArmie.ToList().Count) UnitTryDoAction(listEnemyArmie.ToList()[j], myArr2, myArr1, false);
                    if (i < listMyArmie.ToList().Count) UnitTryDoAction(listMyArmie.ToList()[i], myArr1, myArr2, true);
                }             
            }
            UpdateArmie(myArr1, true);
            UpdateArmie(myArr2, false);
            PushStack();
        }
        public IEnumerable<(IUnit, int)> FindAllUnitSA(List<(IUnit,int)>[] listArmie, bool IsArmie)
        {
            var list = new List<(IUnit,int)>();
            if (IsArmie)
            {
                listArmie[0].Reverse(); listArmie[1].Reverse(); listArmie[2].Reverse();
            }
            for (int i=1; i < listArmie[0].Count; i++)
            {
                var unitSA = listArmie[0][i].Item1?.IsSpecialAbility();
                if (unitSA != null)
                    list.Add(listArmie[0][i]);
            }
            for (int j = 1; j < listArmie[1].Count; j++)
            {
                var unitSA = listArmie[1][j].Item1?.IsSpecialAbility();
                if (unitSA != null)
                    list.Add(listArmie[1][j]);
            }
            for (int l = 1; l < listArmie[2].Count; l++)
            {
                var unitSA = listArmie[2][l].Item1?.IsSpecialAbility();
                if (unitSA != null)
                    list.Add(listArmie[2][l]);
            }
            //for (int i = 1, j = 1, l = 1; i < listArmie[0].Count || j < listArmie[1].Count || l < listArmie[2].Count; i++, j++, l++)
            //{
               
            //    var unitSA = listArmie[0][i].Item1?.IsSpecialAbility();
            //    if (unitSA != null)
            //        list.Add(listArmie[0][i]);
            //    unitSA = listArmie[1][j].Item1?.IsSpecialAbility();
            //    if (unitSA != null)
            //        list.Add(listArmie[1][j]);
            //    unitSA = listArmie[2][l].Item1?.IsSpecialAbility();
            //    if (unitSA != null)
            //        list.Add(listArmie[2][l]);
            //}
            if (IsArmie)
            {
                listArmie[0].Reverse(); listArmie[1].Reverse(); listArmie[2].Reverse();
            }
            return list;
        }
        public void UpdateArmie(List<(IUnit, int)>[] armie, bool Isarmie)
        {
            int count1 = 0; int count2 = 0; int count3 = 0;
            //armie[0].ForEach(x => { if (x.Item1 == null) count1++; });
            //armie[1].ForEach(x => { if (x.Item1 == null) count2++; });
            //armie[2].ForEach(x => { if (x.Item1 == null) count3++; });
            var countArmie1 = armie[0].Count; var countArmie2 = armie[1].Count; var countArmie3 = armie[2].Count;
            for (int i =0, j = 0, l = 0; i < armie[0].Count || j < armie[1].Count || l < armie[2].Count; i++, j++, l++)
            {
                // if (armie[0][i].Item1?.HitPoints < 1 || armie[0][i] == (null,0))

                if (i<armie[0].Count() && (armie[0][i].Item1?.HitPoints < 1 || armie[0][i] == (null, 0)))
                {
                    armie[0].Remove(armie[0][i]); 
                    if (armie[0].Count==0) armie[0].Add((null, 0));
                    // if (!Isarmie) armie[0].Add((null, 0)); else armie[0].Insert(0,(null, 0));
                    count1++;
                }
                if (j < armie[1].Count() && (armie[1][j].Item1?.HitPoints < 1 || armie[1][j] == (null, 0)))
                {
                
                    armie[1].Remove(armie[1][j]);
                    if (armie[1].Count == 0) armie[1].Add((null, 0));
                    //if (!Isarmie) armie[1].Add((null, 0)); else armie[1].Insert(0, (null, 0));
                    count2++;
                }
                if  (l < armie[2].Count() && (armie[2][l].Item1?.HitPoints < 1 || armie[2][l] == (null, 0)))
                {
                    armie[2].Remove(armie[2][l]);
                    if (armie[2].Count == 0) armie[2].Add((null, 0));
                    // if (!Isarmie) armie[2].Add((null, 0)); else armie[2].Insert(0, (null, 0));
                    count3++;
                }
            }
            //var countNull1 = 0;var countNull2 = 0;  var countNull3 = 0;
            
            if (count3 == countArmie3) ShiftArmies(armie, 2);
            if (count2 == countArmie2) ShiftArmies(armie, 1);
            if (count1 == countArmie1) ShiftArmies(armie, 0);  
        }
        public void UnitTryDoAction((IUnit, int) unit, List<(IUnit, int)>[] myArmie, List<(IUnit, int)>[] enemyArmie, bool isEven)
        {
            var unitSA = unit.Item1?.IsSpecialAbility();
            if (unitSA?.SpecialAbilityType == (int)EnumSAType.Archer)
            {
                ArcherTryShoot(unit, myArmie, CreateAllArmies(isEven, myArmie, enemyArmie));
            }
            else if (unitSA?.SpecialAbilityType == (int)EnumSAType.Healer)
            {
                HealerTryHeal(unit, myArmie);
            }
            else if (unitSA?.SpecialAbilityType == (int)EnumSAType.Witcher)
            {
                WitcherTryClone(unit, myArmie,isEven );
            }
            else if (unitSA?.SpecialAbilityType == (int)EnumSAType.Buf)
            {
                BufTryWear(unit, myArmie, isEven);
            }
        }
        public List<(IUnit, int)>[] CreateAllArmies(bool isEven, List<(IUnit, int)>[] listArmie1, List<(IUnit, int)>[] listArmie2)
        {
            List<(IUnit, int)>[] allmembers = new List<(IUnit, int)>[3];
            allmembers[0] = new List<(IUnit, int)>();
            allmembers[1] = new List<(IUnit, int)>();
            allmembers[2] = new List<(IUnit, int)>();
            if (!isEven)
            {
                myArr1[0].Reverse(); myArr1[1].Reverse(); myArr1[2].Reverse();
                myArr2[0].Reverse(); myArr2[1].Reverse(); myArr2[2].Reverse();
            }

            listArmie1[0].ForEach(x => allmembers[0].Add(x));
            listArmie1[1].ForEach(x => allmembers[1].Add(x));
            listArmie1[2].ForEach(x => allmembers[2].Add(x));

            listArmie2[0].ForEach(x => allmembers[0].Add(x));
            listArmie2[1].ForEach(x => allmembers[1].Add(x));
            listArmie2[2].ForEach(x => allmembers[2].Add(x));

            if (!isEven)
            {
                myArr1[0].Reverse(); myArr1[1].Reverse(); myArr1[2].Reverse();
                myArr2[0].Reverse(); myArr2[1].Reverse(); myArr2[2].Reverse();
            }
            return allmembers;
        }
        public void ReplaceUnit((IUnit, int) unitHeavy, IUnit heavyBuf,  bool armie)
        {
            if (armie)
            {
                var positionheavyBuf = listArmie1.FindIndex(x => x == unitHeavy.Item1);
                listArmie1[positionheavyBuf] = heavyBuf;
            }
            else
            {
                var positionheavyBuf = listArmie2.FindIndex(x => x == unitHeavy.Item1);
                listArmie2[positionheavyBuf] = heavyBuf;
            }
        }
        public void BufTryWear((IUnit,int) unit, List<(IUnit, int)>[] myArmie, bool armie)
        {
            bool stop = false;
            var position = myArmie[unit.Item2].FindIndex(x => x.Item1 == unit.Item1);
            var buf = unit.Item1.IsSpecialAbility();
            if (!armie)
            {
                myArmie[0].Reverse(); myArmie[1].Reverse(); myArmie[2].Reverse();
                position = myArmie[unit.Item2].FindIndex(x => x.Item1 == unit.Item1);
            }
            for (int i = position + 1, j = position + 1, l = position + 1; 
                i <= position + buf.SpecialAbilityRange &&
                     j <= position + buf.SpecialAbilityRange && l <= position + buf.SpecialAbilityRange && !stop; i++, j++, l++)
            {
                if (!stop && unit.Item2 != 2 &&  i > -1 && i < myArmie[0].Count && myArmie[0][i].Item1?.HitPoints > 0)
                {
                    var heavyBuf = buf.DoAction(myArmie[0][i].Item1);
                    if (heavyBuf != null)
                    {                       
                        ReplaceUnit(myArmie[0][i], heavyBuf, armie);
                        myArmie[0][i] = (heavyBuf, 0);
                        stop = true;
                    }                            
                }
                if (!stop && j > -1 && j < myArmie[1].Count && myArmie[1][j].Item1?.HitPoints > 0)
                {
                    var heavyBuf = buf.DoAction(myArmie[1][j].Item1);
                    if (heavyBuf != null)
                    {                       
                        ReplaceUnit(myArmie[1][j], heavyBuf, armie);
                        myArmie[1][j] = (heavyBuf, 1);
                        stop = true;
                    }
                }
                if (!stop && unit.Item2 != 0 && l > -1 && l < myArmie[2].Count && myArmie[2][l].Item1?.HitPoints > 0)
                {
                    var heavyBuf = buf.DoAction(myArmie[2][l].Item1);
                    if (heavyBuf != null)
                    {                        
                        ReplaceUnit(myArmie[2][l], heavyBuf, armie);
                        myArmie[2][l] = (heavyBuf, 2);
                        stop = true;
                    }
                }                                  
            }
            if (!armie)
            {
                myArmie[0].Reverse(); myArmie[1].Reverse(); myArmie[2].Reverse();
            }
        }
        public List<IUnit> ArcherTryShoot((IUnit,int) unit, List<(IUnit, int)>[] myArmie, List<(IUnit, int)>[] allMembers)
        {
            bool stop = false; var list = new List<IUnit>();
            var position = allMembers[unit.Item2].FindIndex(x => x.Item1 == unit.Item1);
            var archer = unit.Item1.IsSpecialAbility();

            for (int i = position +1, j = position +1, l = position +1; i <= position + archer.SpecialAbilityRange &&
                     j <= position + archer.SpecialAbilityRange && l <= position + archer.SpecialAbilityRange && !stop; i++, j++, l++)                 
            {
                if (!stop && unit.Item2 != 2 && i < allMembers[0].Count && allMembers[0][i].Item1?.HitPoints>0 && myArmie[0].SingleOrDefault(x => x.Item1 == allMembers[0][i].Item1)==(null, 0) )
                {
                    archer.DoAction(allMembers[0][i].Item1);
                    stop=true;
                   // list.Add(allMembers[0][i].Item1);
                }
                if (!stop && j < allMembers[1].Count && allMembers[1][j].Item1?.HitPoints > 0 && myArmie[1].SingleOrDefault(x => x.Item1 == allMembers[1][j].Item1) == (null, 0))
                {
                    archer.DoAction(allMembers[1][j].Item1);
                    stop = true; 
                    //list.Add(allMembers[1][j].Item1);
                }
                if (!stop && unit.Item2 != 0 && l < allMembers[2].Count && allMembers[2][l].Item1?.HitPoints > 0 && myArmie[2].SingleOrDefault(x => x.Item1 == allMembers[2][l].Item1) == (null, 0))
                {
                    archer.DoAction(allMembers[2][l].Item1);
                    stop = true; 
                    //list.Add(allMembers[2][l].Item1);
                }               
            }
            return list;
        }
        public void HealerTryHeal((IUnit,int) unit, List<(IUnit, int)>[] myArmie)
        {
            bool stop = false;
            var position = myArmie[unit.Item2].FindIndex(x => x.Item1 == unit.Item1);                       
            var healer = unit.Item1.IsSpecialAbility();

            for (int i = position - healer.SpecialAbilityRange, j = position - healer.SpecialAbilityRange, l = position - healer.SpecialAbilityRange;
                i <= position + healer.SpecialAbilityRange && j <= position + healer.SpecialAbilityRange && l <= position + healer.SpecialAbilityRange && !stop; i++, j++, l++)                
            { 
                if (!stop && unit.Item2 != 2 && i > -1 && i < myArmie[0].Count && myArmie[0][i].Item1?.HitPoints > 0 && myArmie[0][i] != unit)
                {
                    var healerable = healer.DoAction(myArmie[0][i].Item1);
                    if (healerable != null) stop = true;
                }
                if (!stop && j > -1 && j < myArmie[1].Count && myArmie[1][j].Item1?.HitPoints > 0 && myArmie[1][j] != unit)
                {
                    var healerable = healer.DoAction(myArmie[1][j].Item1);
                    if (healerable != null) stop = true;
                }
                if (!stop && unit.Item2 != 0 && l > -1 && l < myArmie[2].Count && myArmie[2][l].Item1?.HitPoints > 0 && myArmie[2][l] != unit)
                {
                    var healerable = healer.DoAction(myArmie[2][l].Item1);
                    if (healerable != null) stop = true;
                }                                                 
            }        
        }
        public void InsertUnit((IUnit,int) unit, IUnit unitClone, List<(IUnit, int)>[] myArmie, bool armie)
        {
            var positionWitcherArr = myArmie[unit.Item2].FindIndex(x => x.Item1 == unit.Item1);
            if (armie)
            {
                try
                {
                    var positionWitcher = listArmie1.FindIndex(x => x == unit.Item1);
                    listArmie1.Insert(positionWitcher, unitClone);//перед ним
                    myArmie[unit.Item2].Insert(positionWitcherArr + 1, (unitClone, unit.Item2));
                    AddRow(myArmie, armie);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {          
                try
                {
                    var positionWitcher = listArmie2.FindIndex(x => x == unit.Item1);
                    listArmie2.Insert(positionWitcher, unitClone);//перед ним
                    myArmie[unit.Item2].Insert(positionWitcherArr, (unitClone, unit.Item2));
                    AddRow(myArmie, armie);
                }
                catch (Exception ex)
                {

                }
               
            }
        }
        public void WitcherTryClone((IUnit,int) unit, List<(IUnit, int)>[] myArmie, bool armie)
        {
            bool stop = false;
            var position = myArmie[unit.Item2].FindIndex(x => x.Item1 == unit.Item1);
            var witcher = unit.Item1.IsSpecialAbility();
            
            for (int i = position - witcher.SpecialAbilityRange, j = position - witcher.SpecialAbilityRange, l = position - witcher.SpecialAbilityRange;
                   i < position + witcher.SpecialAbilityRange && j < position + witcher.SpecialAbilityRange && l < position + witcher.SpecialAbilityRange && !stop;i++, j++, l++)                  
            {
      
                if (!stop && unit.Item2!=2 && i > -1 && i < myArmie[0].Count && myArmie[0][i].Item1?.HitPoints > 0 && myArmie[0][i] != unit)
                {
                    var unitClone = witcher.DoAction(myArmie[0][i].Item1);
                    if (unitClone != null)
                    {
                        InsertUnit(unit, unitClone, myArmie, armie);                       
                        stop =true;
                    }
                }
                if (!stop  && j > -1 && j < myArmie[1].Count && myArmie[1][j].Item1?.HitPoints > 0 && myArmie[1][j] != unit)
                {
                    var unitClone = witcher.DoAction(myArmie[1][j].Item1);
                    if (unitClone != null)
                    {
                        InsertUnit(unit, unitClone, myArmie, armie);
                        stop = true;
                    }
                }
                    if (!stop && unit.Item2 != 0 && l > -1 && l < myArmie[2].Count && myArmie[2][l].Item1?.HitPoints > 0 && myArmie[2][l] != unit)
                {
                    var unitClone = witcher.DoAction(myArmie[2][l].Item1);
                    if (unitClone != null)
                    {
                        InsertUnit(unit, unitClone, myArmie, armie);
                        stop = true;
                    }
                }                                 
            }

        }
        public override string ToString()
        {
            return "3х3";
        }
    }
}

