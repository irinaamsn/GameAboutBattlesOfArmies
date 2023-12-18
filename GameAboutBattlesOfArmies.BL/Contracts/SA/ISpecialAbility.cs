using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAboutBattlesOfArmies.BL.Contracts.SA
{
    public interface ISpecialAbility
    {
        public int SpecialAbilityType { get; }
        public int SpecialAbilityRange { get; }
        public int SpecialAbilityStrength { get; }
        public IUnit DoAction(IUnit unit);

    }
}
