using AutoMapper;
using GameAboutBattlesOfArmies.BL.Contracts;
using System.Runtime.CompilerServices;

namespace GameAboutBattlesOfArmies.Settings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<IUnit, UnitModel>()
                .ForMember(dst => dst.FullName, opt => opt.MapFrom(src => src.UnitName + " " + src.MyArmie.TeamName));
            CreateMap<UnitModel, IUnit>();
        }
      
    }
}
