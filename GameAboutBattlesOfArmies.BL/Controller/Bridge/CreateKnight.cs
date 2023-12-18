using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Enums;
using GameAboutBattlesOfArmies.BL.Models;
using GameAboutBattlesOfArmies.BL.Models.Unit;


namespace GameAboutBattlesOfArmies.BL.Bridge
{
    public class CreateKnight:CreatorUnit
    {
        public CreateKnight(IFactory factory) : base(factory) { }
        public override IUnit GetUnit(Armie armie)
        {
            var knight = new Knight();
            knight.MyArmie = armie;
            return factory.CreateUnit(knight);
        }
    }
}
