using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Enums;


namespace GameAboutBattlesOfArmies.BL.Controller.Decorator.DecoratorBuf
{
    public class BufDecorator:BufDecoratorBase
    {
        public BufDecorator(IUnit component) : base(component) { }
        public int MyBuf { get; set; }
        public int GetBuf(int countBufs)
        {
            var rnd = new Random();
            var num = rnd.Next(1,countBufs+1);
            if (num == 1) MyBuf = (int)EnumBufes.Helmet;
            else if (num == 2) MyBuf = (int)EnumBufes.Shield;
            else if (num == 3) MyBuf = (int)EnumBufes.Hourse;
            return MyBuf;
        }
        public override string ToString()
        {
            return UnitName;
        }
    }
}
