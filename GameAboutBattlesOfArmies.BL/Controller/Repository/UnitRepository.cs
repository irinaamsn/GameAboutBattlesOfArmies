using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.DecoratorBuf;
using GameAboutBattlesOfArmies.BL.Controller.Prototype;
using GameAboutBattlesOfArmies.BL.Controller.Proxy;

#nullable disable
namespace GameAboutBattlesOfArmies.BL.Models.Repository
{
    public class UnitRepository : IUnit
    {
        public  int UnitDescriptionId { get; set; }
        public virtual string UnitName { get; set; }
        public  int Attack { get; set; }
        public  int Defence { get; set; }
        public int HitPoints { get ; set ; }
        public Armie MyArmie { get; set; }

        //public event Action<int, IUnit> HitPointsChanged;
        public (bool, IUnit, int) TryingKill(IUnit unit)//unit - killer
        {
            //var unitt = (UnitLoggingProxy)unit;
           // unit.HitPointsChanged += Unitt_HitPointsChanged;
            int minus = Convert.ToInt32(Math.Round((double)((unit?.MyArmie.ArmiePrice - Defence) * unit.Attack / 100), 1, MidpointRounding.AwayFromZero));
            HitPoints -= minus;
            if (this is BufDecorator heavyBuf)
            {
                var rnd = new Random(); 
                var num = rnd.Next(0, 100);
                if (num < 10 && num > 0)
                    return (true,new UnitLoggingProxy(heavyBuf.GetOriginalHeavy()) ,minus);
            }
            return (false, this, minus);
        }

        private void Unitt_HitPointsChanged(int arg1, IUnit arg2)
        {
           arg2.HitPoints = arg1;
        }

        public virtual int UnitPrice => Attack + Defence + HitPoints;

        public IClone Clone()
        {
            return (IClone)MemberwiseClone();  
        } 

        //public object DeepCopy()
        //{
        //    object figure = null;
        //    using (MemoryStream tempStream = new MemoryStream())
        //    {
        //        BinaryFormatter binFormatter = new BinaryFormatter(null,
        //            new StreamingContext(StreamingContextStates.Clone));

        //        binFormatter.Serialize(tempStream, this);
        //        tempStream.Seek(0, SeekOrigin.Begin);

        //        figure = binFormatter.Deserialize(tempStream);
        //    }
        //    return figure;
        //}
    }
}
